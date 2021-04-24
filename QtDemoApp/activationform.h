#pragma once
#include <windows.h>
#include <processthreadsapi.h>
#include <QWidget>
#include <QMessageBox>
#include <QSettings>
#include <QDebug>
#include "ui_activationform.h"

class ActivationForm : public QWidget
{
  Q_OBJECT

 public:
  ActivationForm(QWidget *parent = Q_NULLPTR);
  ~ActivationForm();

  void ActivateLicense();
  Ui::ActivationForm ui;
 private slots:
  void on_push_signIn_clicked();
  void on_push_exit_clicked();
};
