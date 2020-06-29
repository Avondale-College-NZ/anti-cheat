namespace anti_cheat
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.Chkautokill = new System.Windows.Forms.CheckBox();
            this.lbllogfiledir = new System.Windows.Forms.Label();
            this.lblautokill = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btnfiledir = new System.Windows.Forms.Button();
            this.TxtLogfiledir = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.Btnfiledir);
            this.panel1.Controls.Add(this.TxtLogfiledir);
            this.panel1.Controls.Add(this.lblautokill);
            this.panel1.Controls.Add(this.lbllogfiledir);
            this.panel1.Controls.Add(this.Chkautokill);
            this.panel1.Location = new System.Drawing.Point(195, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 363);
            this.panel1.TabIndex = 12;
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
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 540);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox Chkautokill;
        private System.Windows.Forms.Label lbllogfiledir;
        private System.Windows.Forms.Label lblautokill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btnfiledir;
        private System.Windows.Forms.TextBox TxtLogfiledir;
    }
}