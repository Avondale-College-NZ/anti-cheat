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
            this.Chkautokill = new System.Windows.Forms.CheckBox();
            this.lbllogfiledir = new System.Windows.Forms.Label();
            this.lblautokill = new System.Windows.Forms.Label();
            this.pnlsettings = new System.Windows.Forms.Panel();
            this.Btnfiledir = new System.Windows.Forms.Button();
            this.TxtLogfiledir = new System.Windows.Forms.TextBox();
            this.lblauthoption = new System.Windows.Forms.Label();
            this.lblsqlpass = new System.Windows.Forms.Label();
            this.lblsqluser = new System.Windows.Forms.Label();
            this.txtsqluser = new System.Windows.Forms.TextBox();
            this.txtsqlpass = new System.Windows.Forms.TextBox();
            this.Cmbsqlauth = new System.Windows.Forms.ComboBox();
            this.pnlsql = new System.Windows.Forms.Panel();
            this.txtsqldatabase = new System.Windows.Forms.TextBox();
            this.txtsqlserver = new System.Windows.Forms.TextBox();
            this.lblsqldatabase = new System.Windows.Forms.Label();
            this.lblsqlserver = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlsettings.SuspendLayout();
            this.pnlsql.SuspendLayout();
            this.SuspendLayout();
            // 
            // Chkautokill
            // 
            this.Chkautokill.AutoSize = true;
            this.Chkautokill.Location = new System.Drawing.Point(106, 29);
            this.Chkautokill.Name = "Chkautokill";
            this.Chkautokill.Size = new System.Drawing.Size(15, 14);
            this.Chkautokill.TabIndex = 6;
            this.Chkautokill.UseVisualStyleBackColor = true;
            // 
            // lbllogfiledir
            // 
            this.lbllogfiledir.AutoSize = true;
            this.lbllogfiledir.Location = new System.Drawing.Point(9, 8);
            this.lbllogfiledir.Name = "lbllogfiledir";
            this.lbllogfiledir.Size = new System.Drawing.Size(95, 13);
            this.lbllogfiledir.TabIndex = 10;
            this.lbllogfiledir.Text = "Log File Directory: ";
            // 
            // lblautokill
            // 
            this.lblautokill.AutoSize = true;
            this.lblautokill.Location = new System.Drawing.Point(56, 30);
            this.lblautokill.Name = "lblautokill";
            this.lblautokill.Size = new System.Drawing.Size(44, 13);
            this.lblautokill.TabIndex = 11;
            this.lblautokill.Text = "Autokill:";
            // 
            // pnlsettings
            // 
            this.pnlsettings.Controls.Add(this.Btnfiledir);
            this.pnlsettings.Controls.Add(this.TxtLogfiledir);
            this.pnlsettings.Controls.Add(this.lblautokill);
            this.pnlsettings.Controls.Add(this.lbllogfiledir);
            this.pnlsettings.Controls.Add(this.Chkautokill);
            this.pnlsettings.Location = new System.Drawing.Point(12, 10);
            this.pnlsettings.Name = "pnlsettings";
            this.pnlsettings.Size = new System.Drawing.Size(430, 53);
            this.pnlsettings.TabIndex = 12;
            // 
            // Btnfiledir
            // 
            this.Btnfiledir.Location = new System.Drawing.Point(323, 3);
            this.Btnfiledir.Name = "Btnfiledir";
            this.Btnfiledir.Size = new System.Drawing.Size(75, 23);
            this.Btnfiledir.TabIndex = 13;
            this.Btnfiledir.Text = "Browse";
            this.Btnfiledir.UseVisualStyleBackColor = true;
            this.Btnfiledir.Click += new System.EventHandler(this.Btnfiledir_Click);
            // 
            // TxtLogfiledir
            // 
            this.TxtLogfiledir.Location = new System.Drawing.Point(106, 5);
            this.TxtLogfiledir.Name = "TxtLogfiledir";
            this.TxtLogfiledir.Size = new System.Drawing.Size(211, 20);
            this.TxtLogfiledir.TabIndex = 12;
            // 
            // lblauthoption
            // 
            this.lblauthoption.AutoSize = true;
            this.lblauthoption.Location = new System.Drawing.Point(44, 71);
            this.lblauthoption.Name = "lblauthoption";
            this.lblauthoption.Size = new System.Drawing.Size(56, 13);
            this.lblauthoption.TabIndex = 15;
            this.lblauthoption.Text = "SQL Auth:";
            // 
            // lblsqlpass
            // 
            this.lblsqlpass.AutoSize = true;
            this.lblsqlpass.Location = new System.Drawing.Point(20, 124);
            this.lblsqlpass.Name = "lblsqlpass";
            this.lblsqlpass.Size = new System.Drawing.Size(80, 13);
            this.lblsqlpass.TabIndex = 16;
            this.lblsqlpass.Text = "SQL Password:";
            this.lblsqlpass.Visible = false;
            // 
            // lblsqluser
            // 
            this.lblsqluser.AutoSize = true;
            this.lblsqluser.Location = new System.Drawing.Point(18, 98);
            this.lblsqluser.Name = "lblsqluser";
            this.lblsqluser.Size = new System.Drawing.Size(82, 13);
            this.lblsqluser.TabIndex = 17;
            this.lblsqluser.Text = "SQL Username:";
            this.lblsqluser.Visible = false;
            // 
            // txtsqluser
            // 
            this.txtsqluser.Location = new System.Drawing.Point(106, 95);
            this.txtsqluser.Name = "txtsqluser";
            this.txtsqluser.Size = new System.Drawing.Size(211, 20);
            this.txtsqluser.TabIndex = 18;
            this.txtsqluser.Visible = false;
            // 
            // txtsqlpass
            // 
            this.txtsqlpass.Location = new System.Drawing.Point(106, 121);
            this.txtsqlpass.Name = "txtsqlpass";
            this.txtsqlpass.Size = new System.Drawing.Size(211, 20);
            this.txtsqlpass.TabIndex = 19;
            this.txtsqlpass.UseSystemPasswordChar = true;
            this.txtsqlpass.Visible = false;
            // 
            // Cmbsqlauth
            // 
            this.Cmbsqlauth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmbsqlauth.FormattingEnabled = true;
            this.Cmbsqlauth.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Authentication"});
            this.Cmbsqlauth.Location = new System.Drawing.Point(106, 68);
            this.Cmbsqlauth.Name = "Cmbsqlauth";
            this.Cmbsqlauth.Size = new System.Drawing.Size(211, 21);
            this.Cmbsqlauth.TabIndex = 20;
            this.Cmbsqlauth.SelectedIndexChanged += new System.EventHandler(this.Cmbsqlauth_SelectedIndexChanged);
            // 
            // pnlsql
            // 
            this.pnlsql.Controls.Add(this.txtsqldatabase);
            this.pnlsql.Controls.Add(this.txtsqlserver);
            this.pnlsql.Controls.Add(this.lblsqldatabase);
            this.pnlsql.Controls.Add(this.lblsqlserver);
            this.pnlsql.Controls.Add(this.lblsqluser);
            this.pnlsql.Controls.Add(this.Cmbsqlauth);
            this.pnlsql.Controls.Add(this.lblauthoption);
            this.pnlsql.Controls.Add(this.txtsqluser);
            this.pnlsql.Controls.Add(this.txtsqlpass);
            this.pnlsql.Controls.Add(this.lblsqlpass);
            this.pnlsql.Location = new System.Drawing.Point(12, 85);
            this.pnlsql.Name = "pnlsql";
            this.pnlsql.Size = new System.Drawing.Size(430, 166);
            this.pnlsql.TabIndex = 21;
            // 
            // txtsqldatabase
            // 
            this.txtsqldatabase.Location = new System.Drawing.Point(106, 35);
            this.txtsqldatabase.Name = "txtsqldatabase";
            this.txtsqldatabase.Size = new System.Drawing.Size(211, 20);
            this.txtsqldatabase.TabIndex = 24;
            // 
            // txtsqlserver
            // 
            this.txtsqlserver.Location = new System.Drawing.Point(106, 9);
            this.txtsqlserver.Name = "txtsqlserver";
            this.txtsqlserver.Size = new System.Drawing.Size(211, 20);
            this.txtsqlserver.TabIndex = 23;
            // 
            // lblsqldatabase
            // 
            this.lblsqldatabase.AutoSize = true;
            this.lblsqldatabase.Location = new System.Drawing.Point(23, 38);
            this.lblsqldatabase.Name = "lblsqldatabase";
            this.lblsqldatabase.Size = new System.Drawing.Size(80, 13);
            this.lblsqldatabase.TabIndex = 22;
            this.lblsqldatabase.Text = "SQL Database:";
            // 
            // lblsqlserver
            // 
            this.lblsqlserver.AutoSize = true;
            this.lblsqlserver.Location = new System.Drawing.Point(35, 12);
            this.lblsqlserver.Name = "lblsqlserver";
            this.lblsqlserver.Size = new System.Drawing.Size(65, 13);
            this.lblsqlserver.TabIndex = 21;
            this.lblsqlserver.Text = "SQL Server:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(367, 276);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "Reset Settings";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(286, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 309);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pnlsql);
            this.Controls.Add(this.pnlsettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.pnlsettings.ResumeLayout(false);
            this.pnlsettings.PerformLayout();
            this.pnlsql.ResumeLayout(false);
            this.pnlsql.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox Chkautokill;
        private System.Windows.Forms.Label lbllogfiledir;
        private System.Windows.Forms.Label lblautokill;
        private System.Windows.Forms.Panel pnlsettings;
        private System.Windows.Forms.Button Btnfiledir;
        private System.Windows.Forms.TextBox TxtLogfiledir;
        private System.Windows.Forms.Label lblauthoption;
        private System.Windows.Forms.ComboBox Cmbsqlauth;
        private System.Windows.Forms.TextBox txtsqlpass;
        private System.Windows.Forms.TextBox txtsqluser;
        private System.Windows.Forms.Label lblsqluser;
        private System.Windows.Forms.Label lblsqlpass;
        private System.Windows.Forms.Panel pnlsql;
        private System.Windows.Forms.Label lblsqldatabase;
        private System.Windows.Forms.Label lblsqlserver;
        private System.Windows.Forms.TextBox txtsqldatabase;
        private System.Windows.Forms.TextBox txtsqlserver;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
    }
}