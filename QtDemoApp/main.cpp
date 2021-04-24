#include "QtDemoApp.h"
#include "stdafx.h"
#include "activationform.h"

#include <QtWidgets/QApplication>

#include "crypto/sealedbox.hpp"
#include "http/http.hpp"
#include "auth/hwid.hpp"
#include "auth/validation.hpp"

bool checkLic(QString username) {
    sodium_init();

    ls::validation v("localhost:8001", "DUx1Laid4QYY2IhUl0jg9JyP74y7esKDCSVn49Ix6Fc=");

    if (!v.login(username.toLocal8Bit().data())) {
        return false;
    }

    std::vector<ls::validation::subscription_type> subs;
    if (!v.get_subscriptions(subs)) {
        return false;
    }

    return true;
}

bool activate()
{
    // folder in %AppData%
    // Config filename
    QSettings settings(QSettings::IniFormat, QSettings::UserScope, "QtAppDemo", "Config");
    struct Settings {
        QString username;
    };
    Settings settings_;
    settings.beginGroup("Settings");
    settings_.username = settings.value("username", "").toString();
    settings.endGroup();
    QString username = settings_.username;
    if (!username.isEmpty())
    {
        // check username
        if (!checkLic(username))
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
        QtDemoApp w;
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
