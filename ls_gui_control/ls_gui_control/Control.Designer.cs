namespace ls_gui_control
{
    partial class Control
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hostname_ = new System.Windows.Forms.Label();
            this.mastertoken_ = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.getUsers = new System.Windows.Forms.TabPage();
            this.getUser = new System.Windows.Forms.TabPage();
            this.getUsersGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hwid_hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_added = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ban_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.api_access = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.api_token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.getUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getUsersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ls_gui_control.Properties.Resources.sound_control;
            this.pictureBox1.Location = new System.Drawing.Point(15, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Файл конфигурации найден и программа готова к работе.";
            // 
            // hr
            // 
            this.hr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hr.Location = new System.Drawing.Point(3, 114);
            this.hr.Name = "hr";
            this.hr.Size = new System.Drawing.Size(807, 2);
            this.hr.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hostname: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Master token: ";
            // 
            // hostname_
            // 
            this.hostname_.AutoSize = true;
            this.hostname_.Location = new System.Drawing.Point(82, 120);
            this.hostname_.Name = "hostname_";
            this.hostname_.Size = new System.Drawing.Size(16, 13);
            this.hostname_.TabIndex = 4;
            this.hostname_.Text = "...";
            // 
            // mastertoken_
            // 
            this.mastertoken_.AutoSize = true;
            this.mastertoken_.Location = new System.Drawing.Point(96, 142);
            this.mastertoken_.Name = "mastertoken_";
            this.mastertoken_.Size = new System.Drawing.Size(16, 13);
            this.mastertoken_.TabIndex = 4;
            this.mastertoken_.Text = "...";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(3, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(807, 2);
            this.label4.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 307);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.getUsers);
            this.tabControl1.Controls.Add(this.getUser);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(654, 283);
            this.tabControl1.TabIndex = 0;
            // 
            // getUsers
            // 
            this.getUsers.Controls.Add(this.getUsersGrid);
            this.getUsers.Location = new System.Drawing.Point(4, 22);
            this.getUsers.Name = "getUsers";
            this.getUsers.Padding = new System.Windows.Forms.Padding(3);
            this.getUsers.Size = new System.Drawing.Size(646, 257);
            this.getUsers.TabIndex = 0;
            this.getUsers.Text = "getUsers";
            this.getUsers.UseVisualStyleBackColor = true;
            // 
            // getUser
            // 
            this.getUser.Location = new System.Drawing.Point(4, 22);
            this.getUser.Name = "getUser";
            this.getUser.Padding = new System.Windows.Forms.Padding(3);
            this.getUser.Size = new System.Drawing.Size(440, 242);
            this.getUser.TabIndex = 1;
            this.getUser.Text = "getUser";
            this.getUser.UseVisualStyleBackColor = true;
            // 
            // getUsersGrid
            // 
            this.getUsersGrid.AllowUserToAddRows = false;
            this.getUsersGrid.AllowUserToDeleteRows = false;
            this.getUsersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.getUsersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.username,
            this.hwid_hash,
            this.date_added,
            this.ban_date,
            this.api_access,
            this.api_token});
            this.getUsersGrid.Location = new System.Drawing.Point(-4, -3);
            this.getUsersGrid.Name = "getUsersGrid";
            this.getUsersGrid.Size = new System.Drawing.Size(654, 264);
            this.getUsersGrid.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            // 
            // username
            // 
            this.username.HeaderText = "username";
            this.username.Name = "username";
            // 
            // hwid_hash
            // 
            this.hwid_hash.HeaderText = "hwid_hash";
            this.hwid_hash.Name = "hwid_hash";
            // 
            // date_added
            // 
            this.date_added.HeaderText = "date_added";
            this.date_added.Name = "date_added";
            // 
            // ban_date
            // 
            this.ban_date.HeaderText = "ban_date";
            this.ban_date.Name = "ban_date";
            // 
            // api_access
            // 
            this.api_access.HeaderText = "api_access";
            this.api_access.Name = "api_access";
            // 
            // api_token
            // 
            this.api_token.HeaderText = "api_token";
            this.api_token.Name = "api_token";
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 984);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mastertoken_);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hostname_);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Control";
            this.Text = "ls control panel";
            this.Load += new System.EventHandler(this.Control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.getUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.getUsersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label hr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label hostname_;
        private System.Windows.Forms.Label mastertoken_;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage getUsers;
        private System.Windows.Forms.TabPage getUser;
        private System.Windows.Forms.DataGridView getUsersGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn hwid_hash;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_added;
        private System.Windows.Forms.DataGridViewTextBoxColumn ban_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn api_access;
        private System.Windows.Forms.DataGridViewTextBoxColumn api_token;
    }
}