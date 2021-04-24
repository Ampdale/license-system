#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_QtDemoApp.h"

class QtDemoApp : public QMainWindow
{
    Q_OBJECT

public:
    QtDemoApp(QWidget *parent = Q_NULLPTR);

private:
    Ui::QtDemoAppClass ui;
};
