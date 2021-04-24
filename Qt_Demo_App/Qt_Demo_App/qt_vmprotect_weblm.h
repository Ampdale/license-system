#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_Qt_Demo_App.h"

class Qt_Demo_App : public QMainWindow
{
  Q_OBJECT

 public:
  Qt_Demo_App(QWidget *parent = Q_NULLPTR);

 private:
  Ui::Qt_Demo_AppClass ui;
};
