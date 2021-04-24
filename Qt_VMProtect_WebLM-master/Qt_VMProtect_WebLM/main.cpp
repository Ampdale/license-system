#include "qt_vmprotect_weblm.h"
#include "activationform.h"
#include <QtWidgets/QApplication>

bool activate()
{
  // QtVMP_Demo folder in %AppData%
  // Config filename
  QSettings settings(QSettings::IniFormat, QSettings::UserScope, "QtVMP_Demo", "Config");
  struct Settings {
    QString key;
    QString serial;
  };
  Settings settings_;
  settings.beginGroup("Settings");
  settings_.key = settings.value("key", "").toString();
  settings_.serial = settings.value("serial", "").toString();
  settings.endGroup();
  QString serial = settings_.serial;
  QString activationKey = settings_.key;
  DWORD result = 0;
  if (!activationKey.isEmpty() && !serial.isEmpty())
  {
    if ((result = VMProtectSetSerialNumber(serial.toLocal8Bit().data())) != 0)
    {
      return false;
    }
    return true;
  }
  return false;
}

int main(int argc, char *argv[])
{
  QApplication a(argc, argv);
  if (activate() == true)
  {
    // main window
    Qt_VMProtect_WebLM w;
    w.show();
    return a.exec();
  }
  else {
    // activation window
    ActivationForm activate;
    activate.show();
    return a.exec();
  }
}
