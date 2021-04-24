#include "activationform.h"
#include <list>

#include "crypto/sealedbox.hpp"
#include "http/http.hpp"
#include "auth/hwid.hpp"
#include "auth/validation.hpp"


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
	// check license
}

void ActivationForm::on_push_signIn_clicked()
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
