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

bool ActivationForm::ActivateLicense()
{
	// check license

    sodium_init();

    ls::validation v("localhost:8001", "DUx1Laid4QYY2IhUl0jg9JyP74y7esKDCSVn49Ix6Fc=");

    if (!v.login(ui.textEdit_username->toPlainText().toLocal8Bit().data())) {
        QMessageBox::information(this, "ACTIVATION_ERROR", "Login Error");
        return false;
    }

    std::vector<ls::validation::subscription_type> subs;
    if (!v.get_subscriptions(subs)) {
        QMessageBox::information(this, "ACTIVATION_ERROR", "Wrong subs");
        return false;
    }

    //std::string file;
    //if( !v.get_product( std::get<1>( subs.front() ), file ) ) {
    //   return -1;
    //}

    QMessageBox::information(this, "ACTIVATION_OK", "ACTIVATION OK");

    return true;
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
