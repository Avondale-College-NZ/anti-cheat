namespace anti_cheat
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.chkAutoKill = new System.Windows.Forms.CheckBox();
            this.lblLogFileDir = new System.Windows.Forms.Label();
            this.lblAutoKill = new System.Windows.Forms.Label();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.Btnfiledir = new System.Windows.Forms.Button();
            this.txtLogFileDir = new System.Windows.Forms.TextBox();
            this.lblAuthOption = new System.Windows.Forms.Label();
            this.lblSqlPass = new System.Windows.Forms.Label();
            this.lblSqlUser = new System.Windows.Forms.Label();
            this.txtSqlUser = new System.Windows.Forms.TextBox();
            this.txtSqlPass = new System.Windows.Forms.TextBox();
            this.cmbSqlAuth = new System.Windows.Forms.ComboBox();
            this.pnlsql = new System.Windows.Forms.Panel();
            this.txtSqlDatabase = new System.Windows.Forms.TextBox();
            this.txtSqlServer = new System.Windows.Forms.TextBox();
            this.lblSqlDatabase = new System.Windows.Forms.Label();
            this.lblSqlServer = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlUserOptions = new System.Windows.Forms.Panel();
            this.chkStealth = new System.Windows.Forms.CheckBox();
            this.lblStealth = new System.Windows.Forms.Label();
            this.BtnFileBlist = new System.Windows.Forms.Button();
            this.txtBlacklist = new System.Windows.Forms.TextBox();
            this.lblBlackList = new System.Windows.Forms.Label();
            this.pnlLog.SuspendLayout();
            this.pnlsql.SuspendLayout();
            this.pnlUserOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAutoKill
            // 
            this.chkAutoKill.AutoSize = true;
            this.chkAutoKill.Location = new System.Drawing.Point(106, 38);
            this.chkAutoKill.Name = "chkAutoKill";
            this.chkAutoKill.Size = new System.Drawing.Size(15, 14);
            this.chkAutoKill.TabIndex = 6;
            this.chkAutoKill.UseVisualStyleBackColor = true;
            // 
            // lblLogFileDir
            // 
            this.lblLogFileDir.AutoSize = true;
            this.lblLogFileDir.Location = new System.Drawing.Point(8, 11);
            this.lblLogFileDir.Name = "lblLogFileDir";
            this.lblLogFileDir.Size = new System.Drawing.Size(95, 13);
            this.lblLogFileDir.TabIndex = 10;
            this.lblLogFileDir.Text = "Log File Directory: ";
            // 
            // lblAutoKill
            // 
            this.lblAutoKill.AutoSize = true;
            this.lblAutoKill.Location = new System.Drawing.Point(56, 39);
            this.lblAutoKill.Name = "lblAutoKill";
            this.lblAutoKill.Size = new System.Drawing.Size(44, 13);
            this.lblAutoKill.TabIndex = 11;
            this.lblAutoKill.Text = "Autokill:";
            // 
            // pnlLog
            // 
            this.pnlLog.Controls.Add(this.Btnfiledir);
            this.pnlLog.Controls.Add(this.txtLogFileDir);
            this.pnlLog.Controls.Add(this.lblLogFileDir);
            this.pnlLog.Location = new System.Drawing.Point(12, 149);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(435, 34);
            this.pnlLog.TabIndex = 12;
            // 
            // Btnfiledir
            // 
            this.Btnfiledir.Location = new System.Drawing.Point(352, 6);
            this.Btnfiledir.Name = "Btnfiledir";
            this.Btnfiledir.Size = new System.Drawing.Size(75, 23);
            this.Btnfiledir.TabIndex = 13;
            this.Btnfiledir.Text = "Browse";
            this.Btnfiledir.UseVisualStyleBackColor = true;
            this.Btnfiledir.Click += new System.EventHandler(this.Btnfiledir_Click);
            // 
            // txtLogFileDir
            // 
            this.txtLogFileDir.Location = new System.Drawing.Point(106, 8);
            this.txtLogFileDir.Name = "txtLogFileDir";
            this.txtLogFileDir.Size = new System.Drawing.Size(211, 20);
            this.txtLogFileDir.TabIndex = 12;
            // 
            // lblAuthOption
            // 
            this.lblAuthOption.AutoSize = true;
            this.lblAuthOption.Location = new System.Drawing.Point(44, 71);
            this.lblAuthOption.Name = "lblAuthOption";
            this.lblAuthOption.Size = new System.Drawing.Size(56, 13);
            this.lblAuthOption.TabIndex = 15;
            this.lblAuthOption.Text = "SQL Auth:";
            // 
            // lblSqlPass
            // 
            this.lblSqlPass.AutoSize = true;
            this.lblSqlPass.Location = new System.Drawing.Point(20, 124);
            this.lblSqlPass.Name = "lblSqlPass";
            this.lblSqlPass.Size = new System.Drawing.Size(80, 13);
            this.lblSqlPass.TabIndex = 16;
            this.lblSqlPass.Text = "SQL Password:";
            this.lblSqlPass.Visible = false;
            // 
            // lblSqlUser
            // 
            this.lblSqlUser.AutoSize = true;
            this.lblSqlUser.Location = new System.Drawing.Point(18, 98);
            this.lblSqlUser.Name = "lblSqlUser";
            this.lblSqlUser.Size = new System.Drawing.Size(82, 13);
            this.lblSqlUser.TabIndex = 17;
            this.lblSqlUser.Text = "SQL Username:";
            this.lblSqlUser.Visible = false;
            // 
            // txtSqlUser
            // 
            this.txtSqlUser.Location = new System.Drawing.Point(106, 95);
            this.txtSqlUser.Name = "txtSqlUser";
            this.txtSqlUser.Size = new System.Drawing.Size(211, 20);
            this.txtSqlUser.TabIndex = 18;
            this.txtSqlUser.Visible = false;
            // 
            // txtSqlPass
            // 
            this.txtSqlPass.Location = new System.Drawing.Point(106, 121);
            this.txtSqlPass.Name = "txtSqlPass";
            this.txtSqlPass.Size = new System.Drawing.Size(211, 20);
            this.txtSqlPass.TabIndex = 19;
            this.txtSqlPass.UseSystemPasswordChar = true;
            this.txtSqlPass.Visible = false;
            // 
            // cmbSqlAuth
            // 
            this.cmbSqlAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSqlAuth.FormattingEnabled = true;
            this.cmbSqlAuth.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Authentication"});
            this.cmbSqlAuth.Location = new System.Drawing.Point(106, 68);
            this.cmbSqlAuth.Name = "cmbSqlAuth";
            this.cmbSqlAuth.Size = new System.Drawing.Size(211, 21);
            this.cmbSqlAuth.TabIndex = 20;
            this.cmbSqlAuth.SelectedIndexChanged += new System.EventHandler(this.Cmbsqlauth_SelectedIndexChanged);
            // 
            // pnlsql
            // 
            this.pnlsql.Controls.Add(this.txtSqlDatabase);
            this.pnlsql.Controls.Add(this.txtSqlServer);
            this.pnlsql.Controls.Add(this.lblSqlDatabase);
            this.pnlsql.Controls.Add(this.lblSqlServer);
            this.pnlsql.Controls.Add(this.lblSqlUser);
            this.pnlsql.Controls.Add(this.cmbSqlAuth);
            this.pnlsql.Controls.Add(this.lblAuthOption);
            this.pnlsql.Controls.Add(this.txtSqlUser);
            this.pnlsql.Controls.Add(this.txtSqlPass);
            this.pnlsql.Controls.Add(this.lblSqlPass);
            this.pnlsql.Location = new System.Drawing.Point(12, 189);
            this.pnlsql.Name = "pnlsql";
            this.pnlsql.Size = new System.Drawing.Size(435, 166);
            this.pnlsql.TabIndex = 21;
            // 
            // txtSqlDatabase
            // 
            this.txtSqlDatabase.Location = new System.Drawing.Point(106, 35);
            this.txtSqlDatabase.Name = "txtSqlDatabase";
            this.txtSqlDatabase.Size = new System.Drawing.Size(211, 20);
            this.txtSqlDatabase.TabIndex = 24;
            // 
            // txtSqlServer
            // 
            this.txtSqlServer.Location = new System.Drawing.Point(106, 9);
            this.txtSqlServer.Name = "txtSqlServer";
            this.txtSqlServer.Size = new System.Drawing.Size(211, 20);
            this.txtSqlServer.TabIndex = 23;
            // 
            // lblSqlDatabase
            // 
            this.lblSqlDatabase.AutoSize = true;
            this.lblSqlDatabase.Location = new System.Drawing.Point(23, 38);
            this.lblSqlDatabase.Name = "lblSqlDatabase";
            this.lblSqlDatabase.Size = new System.Drawing.Size(80, 13);
            this.lblSqlDatabase.TabIndex = 22;
            this.lblSqlDatabase.Text = "SQL Database:";
            // 
            // lblSqlServer
            // 
            this.lblSqlServer.AutoSize = true;
            this.lblSqlServer.Location = new System.Drawing.Point(35, 12);
            this.lblSqlServer.Name = "lblSqlServer";
            this.lblSqlServer.Size = new System.Drawing.Size(65, 13);
            this.lblSqlServer.TabIndex = 21;
            this.lblSqlServer.Text = "SQL Server:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(367, 361);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "Reset Settings";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(286, 361);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlUserOptions
            // 
            this.pnlUserOptions.Controls.Add(this.chkStealth);
            this.pnlUserOptions.Controls.Add(this.lblStealth);
            this.pnlUserOptions.Controls.Add(this.BtnFileBlist);
            this.pnlUserOptions.Controls.Add(this.txtBlacklist);
            this.pnlUserOptions.Controls.Add(this.lblBlackList);
            this.pnlUserOptions.Controls.Add(this.lblAutoKill);
            this.pnlUserOptions.Controls.Add(this.chkAutoKill);
            this.pnlUserOptions.Location = new System.Drawing.Point(12, 12);
            this.pnlUserOptions.Name = "pnlUserOptions";
            this.pnlUserOptions.Size = new System.Drawing.Size(435, 131);
            this.pnlUserOptions.TabIndex = 24;
            // 
            // chkStealth
            // 
            this.chkStealth.AutoSize = true;
            this.chkStealth.Location = new System.Drawing.Point(106, 58);
            this.chkStealth.Name = "chkStealth";
            this.chkStealth.Size = new System.Drawing.Size(15, 14);
            this.chkStealth.TabIndex = 16;
            this.chkStealth.UseVisualStyleBackColor = true;
            // 
            // lblStealth
            // 
            this.lblStealth.AutoSize = true;
            this.lblStealth.Location = new System.Drawing.Point(27, 58);
            this.lblStealth.Name = "lblStealth";
            this.lblStealth.Size = new System.Drawing.Size(73, 13);
            this.lblStealth.TabIndex = 15;
            this.lblStealth.Text = "Stealth Mode:";
            // 
            // BtnFileBlist
            // 
            this.BtnFileBlist.Location = new System.Drawing.Point(352, 11);
            this.BtnFileBlist.Name = "BtnFileBlist";
            this.BtnFileBlist.Size = new System.Drawing.Size(75, 23);
            this.BtnFileBlist.TabIndex = 14;
            this.BtnFileBlist.Text = "Browse";
            this.BtnFileBlist.UseVisualStyleBackColor = true;
            // 
            // txtBlacklist
            // 
            this.txtBlacklist.Location = new System.Drawing.Point(106, 13);
            this.txtBlacklist.Name = "txtBlacklist";
            this.txtBlacklist.Size = new System.Drawing.Size(211, 20);
            this.txtBlacklist.TabIndex = 13;
            // 
            // lblBlackList
            // 
            this.lblBlackList.AutoSize = true;
            this.lblBlackList.Location = new System.Drawing.Point(44, 16);
            this.lblBlackList.Name = "lblBlackList";
            this.lblBlackList.Size = new System.Drawing.Size(56, 13);
            this.lblBlackList.TabIndex = 12;
            this.lblBlackList.Text = "Black List:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 396);
            this.Controls.Add(this.pnlUserOptions);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pnlsql);
            this.Controls.Add(this.pnlLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            this.pnlsql.ResumeLayout(false);
            this.pnlsql.PerformLayout();
            this.pnlUserOptions.ResumeLayout(false);
            this.pnlUserOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkAutoKill;
        private System.Windows.Forms.Label lblLogFileDir;
        private System.Windows.Forms.Label lblAutoKill;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Button Btnfiledir;
        private System.Windows.Forms.TextBox txtLogFileDir;
        private System.Windows.Forms.Label lblAuthOption;
        private System.Windows.Forms.ComboBox cmbSqlAuth;
        private System.Windows.Forms.TextBox txtSqlPass;
        private System.Windows.Forms.TextBox txtSqlUser;
        private System.Windows.Forms.Label lblSqlUser;
        private System.Windows.Forms.Label lblSqlPass;
        private System.Windows.Forms.Panel pnlsql;
        private System.Windows.Forms.Label lblSqlDatabase;
        private System.Windows.Forms.Label lblSqlServer;
        private System.Windows.Forms.TextBox txtSqlDatabase;
        private System.Windows.Forms.TextBox txtSqlServer;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlUserOptions;
        private System.Windows.Forms.Label lblBlackList;
        private System.Windows.Forms.TextBox txtBlacklist;
        private System.Windows.Forms.Button BtnFileBlist;
        private System.Windows.Forms.CheckBox chkStealth;
        private System.Windows.Forms.Label lblStealth;
    }
}