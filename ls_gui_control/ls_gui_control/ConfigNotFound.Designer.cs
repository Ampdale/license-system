namespace ls_gui_control
{
    partial class ConfigNotFound
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hr = new System.Windows.Forms.Label();
            this.hostname_ = new System.Windows.Forms.Label();
            this.masterToken_ = new System.Windows.Forms.Label();
            this.hostname = new System.Windows.Forms.TextBox();
            this.masterToken = new System.Windows.Forms.TextBox();
            this.add_config = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ls_gui_control.Properties.Resources.error;
            this.pictureBox1.Location = new System.Drawing.Point(342, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сервер лицензии и мастер токен не найдены в файле конфигурации.\n\nДобавьте их, что" +
    "бы продолжить работу.";
            // 
            // hr
            // 
            this.hr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hr.Location = new System.Drawing.Point(-8, 213);
            this.hr.Name = "hr";
            this.hr.Size = new System.Drawing.Size(807, 2);
            this.hr.TabIndex = 2;
            // 
            // hostname_
            // 
            this.hostname_.AutoSize = true;
            this.hostname_.Location = new System.Drawing.Point(306, 233);
            this.hostname_.Name = "hostname_";
            this.hostname_.Size = new System.Drawing.Size(58, 13);
            this.hostname_.TabIndex = 3;
            this.hostname_.Text = "Hostname:";
            // 
            // masterToken_
            // 
            this.masterToken_.AutoSize = true;
            this.masterToken_.Location = new System.Drawing.Point(306, 271);
            this.masterToken_.Name = "masterToken_";
            this.masterToken_.Size = new System.Drawing.Size(72, 13);
            this.masterToken_.TabIndex = 3;
            this.masterToken_.Text = "Master token:";
            // 
            // hostname
            // 
            this.hostname.Location = new System.Drawing.Point(309, 250);
            this.hostname.Name = "hostname";
            this.hostname.Size = new System.Drawing.Size(237, 20);
            this.hostname.TabIndex = 4;
            // 
            // masterToken
            // 
            this.masterToken.Location = new System.Drawing.Point(309, 287);
            this.masterToken.Name = "masterToken";
            this.masterToken.Size = new System.Drawing.Size(237, 20);
            this.masterToken.TabIndex = 4;
            // 
            // add_config
            // 
            this.add_config.Location = new System.Drawing.Point(309, 314);
            this.add_config.Name = "add_config";
            this.add_config.Size = new System.Drawing.Size(75, 23);
            this.add_config.TabIndex = 5;
            this.add_config.Text = "Add";
            this.add_config.UseVisualStyleBackColor = true;
            this.add_config.Click += new System.EventHandler(this.add_config_Click);
            // 
            // ConfigNotFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.add_config);
            this.Controls.Add(this.masterToken);
            this.Controls.Add(this.hostname);
            this.Controls.Add(this.masterToken_);
            this.Controls.Add(this.hostname_);
            this.Controls.Add(this.hr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConfigNotFound";
            this.Text = "Config not found";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label hr;
        private System.Windows.Forms.Label hostname_;
        private System.Windows.Forms.Label masterToken_;
        private System.Windows.Forms.TextBox hostname;
        private System.Windows.Forms.TextBox masterToken;
        private System.Windows.Forms.Button add_config;
    }
}

