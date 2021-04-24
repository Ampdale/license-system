#include "activationform.h"
#include <list>

ActivationForm::ActivationForm(QWidget *parent)
  : QWidget(parent)
{
  ui.setupUi(this);
}

ActivationForm::~ActivationForm()
{
}

void ActivationForm::ActivateLicense()
{
  char serial[5000];
  int res = VMProtectActivateLicense(ui.textEdit_key->toPlainText().toLocal8Bit(), serial, sizeof(serial));
  // QtVMP_Demo folder in %AppData%
  // Config filename
  QSettings settings(QSettings::IniFormat, QSettings::UserScope, "QtVMP_Demo", "Config");
  settings.beginGroup("Settings");
  settings.setValue("key", ui.textEdit_key->toPlainText());
  settings.setValue("serial", QString::fromLocal8Bit(serial));
  settings.endGroup();
  //qDebug() << "Serial: " << QString::fromLocal8Bit(serial) << "\r\n";
  switch (res) {
    case ACTIVATION_OK:
      QMessageBox::information(this, "ACTIVATION_OK", "ACTIVATION OK");
      break;
    case ACTIVATION_SMALL_BUFFER:
      QMessageBox::information(this, "ACTIVATION_SMALL_BUFFER", "Activation Error");
      break;
    case ACTIVATION_NO_CONNECTION:
      QMessageBox::information(this, "ACTIVATION_NO_CONNECTION", "Activation Error");
      break;
    case ACTIVATION_BAD_REPLY:
      QMessageBox::information(this, "ACTIVATION_BAD_REPLY", "Activation Error");
      break;
    case ACTIVATION_BANNED:
      QMessageBox::information(this, "ACTIVATION_BANNED", "Activation Error");
      break;
    case ACTIVATION_CORRUPTED:
      QMessageBox::information(this, "ACTIVATION_CORRUPTED", "Activation Error");
      break;
    case ACTIVATION_BAD_CODE:
      QMessageBox::information(this, "ACTIVATION_BAD_CODE", "Activation Error");
      break;
    case ACTIVATION_ALREADY_USED:
      QMessageBox::information(this, "ACTIVATION_ALREADY_USED", "Activation Error");
      break;
    case ACTIVATION_SERIAL_UNKNOWN:
      QMessageBox::information(this, "ACTIVATION_SERIAL_UNKNOWN", "Activation Error");
      break;
    case ACTIVATION_EXPIRED:
      QMessageBox::information(this, "ACTIVATION_EXPIRED", "Activation Error");
      break;
    case ACTIVATION_NOT_AVAILABLE:
      QMessageBox::information(this, "ACTIVATION_NOT_AVAILABLE", "Activation Error");
      break;
  }
}

void ActivationForm::on_push_register_clicked()
{
  ActivateLicense();
}

void ActivationForm::on_push_exit_clicked()
{
#if defined(_WIN32)
  TerminateProcess(GetCurrentProcess(), 0);
#endif
#if defined(Q_OS_LINUX)
  qint64 pid = QCoreApplication::applicationPid();
  QProcess::startDetached("kill -9 " + QString::number(pid));
#endif
}
