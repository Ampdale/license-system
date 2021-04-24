#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_qt_vmprotect_weblm.h"

class Qt_VMProtect_WebLM : public QMainWindow
{
  Q_OBJECT

 public:
  Qt_VMProtect_WebLM(QWidget *parent = Q_NULLPTR);

 private:
  Ui::Qt_VMProtect_WebLMClass ui;

};
