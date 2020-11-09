namespace anti_cheat
{
    partial class LogsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogsForm));
            this.logsList = new System.Windows.Forms.ListView();
            this.databaseID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processHandle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateFound = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlLogs = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSmpLogs = new System.Windows.Forms.Button();
            this.tabLogs = new System.Windows.Forms.TabControl();
            this.tabSQL = new System.Windows.Forms.TabPage();
            this.tabApp = new System.Windows.Forms.TabPage();
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.lblLogFileTitle = new System.Windows.Forms.Label();
            this.lblAppLogTitle = new System.Windows.Forms.Label();
            this.pnlLogs.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.tabSQL.SuspendLayout();
            this.tabApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // logsList
            // 
            this.logsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.databaseID,
            this.processName,
            this.processID,
            this.processHandle,
            this.dateFound});
            this.logsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logsList.GridLines = true;
            this.logsList.HideSelection = false;
            this.logsList.Location = new System.Drawing.Point(0, 0);
            this.logsList.MultiSelect = false;
            this.logsList.Name = "logsList";
            this.logsList.Size = new System.Drawing.Size(646, 396);
            this.logsList.TabIndex = 1;
            this.logsList.UseCompatibleStateImageBehavior = false;
            this.logsList.View = System.Windows.Forms.View.Details;
            // 
            // databaseID
            // 
            this.databaseID.Text = "Database ID";
            this.databaseID.Width = 80;
            // 
            // processName
            // 
            this.processName.Text = "Process Name";
            this.processName.Width = 200;
            // 
            // processID
            // 
            this.processID.Text = "Process ID";
            this.processID.Width = 80;
            // 
            // processHandle
            // 
            this.processHandle.Text = "Process Handle";
            this.processHandle.Width = 100;
            // 
            // dateFound
            // 
            this.dateFound.Text = "Date Found";
            this.dateFound.Width = 180;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(574, 408);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlLogs
            // 
            this.pnlLogs.Controls.Add(this.logsList);
            this.pnlLogs.Location = new System.Drawing.Point(6, 6);
            this.pnlLogs.Name = "pnlLogs";
            this.pnlLogs.Size = new System.Drawing.Size(646, 396);
            this.pnlLogs.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClear.Location = new System.Drawing.Point(6, 408);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear Database";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSmpLogs
            // 
            this.btnSmpLogs.Location = new System.Drawing.Point(134, 48);
            this.btnSmpLogs.Name = "btnSmpLogs";
            this.btnSmpLogs.Size = new System.Drawing.Size(75, 23);
            this.btnSmpLogs.TabIndex = 5;
            this.btnSmpLogs.Text = "Open";
            this.btnSmpLogs.UseVisualStyleBackColor = true;
            this.btnSmpLogs.Click += new System.EventHandler(this.btnSmpLogs_Click);
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.tabSQL);
            this.tabLogs.Controls.Add(this.tabApp);
            this.tabLogs.Location = new System.Drawing.Point(12, 3);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.SelectedIndex = 0;
            this.tabLogs.Size = new System.Drawing.Size(663, 477);
            this.tabLogs.TabIndex = 6;
            // 
            // tabSQL
            // 
            this.tabSQL.Controls.Add(this.pnlLogs);
            this.tabSQL.Controls.Add(this.btnClear);
            this.tabSQL.Controls.Add(this.btnRefresh);
            this.tabSQL.Location = new System.Drawing.Point(4, 22);
            this.tabSQL.Name = "tabSQL";
            this.tabSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabSQL.Size = new System.Drawing.Size(655, 451);
            this.tabSQL.TabIndex = 0;
            this.tabSQL.Text = "Database Logs";
            this.tabSQL.UseVisualStyleBackColor = true;
            // 
            // tabApp
            // 
            this.tabApp.Controls.Add(this.txtLogFile);
            this.tabApp.Controls.Add(this.lblLogFileTitle);
            this.tabApp.Controls.Add(this.lblAppLogTitle);
            this.tabApp.Controls.Add(this.btnSmpLogs);
            this.tabApp.Location = new System.Drawing.Point(4, 22);
            this.tabApp.Name = "tabApp";
            this.tabApp.Padding = new System.Windows.Forms.Padding(3);
            this.tabApp.Size = new System.Drawing.Size(655, 451);
            this.tabApp.TabIndex = 1;
            this.tabApp.Text = "Application Logs";
            this.tabApp.UseVisualStyleBackColor = true;
            this.tabApp.Click += new System.EventHandler(this.tabApp_Click);
            // 
            // txtLogFile
            // 
            this.txtLogFile.Location = new System.Drawing.Point(134, 22);
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.Size = new System.Drawing.Size(302, 20);
            this.txtLogFile.TabIndex = 11;
            // 
            // lblLogFileTitle
            // 
            this.lblLogFileTitle.AutoSize = true;
            this.lblLogFileTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogFileTitle.Location = new System.Drawing.Point(68, 21);
            this.lblLogFileTitle.Name = "lblLogFileTitle";
            this.lblLogFileTitle.Size = new System.Drawing.Size(60, 18);
            this.lblLogFileTitle.TabIndex = 10;
            this.lblLogFileTitle.Text = "LogFile:";
            // 
            // lblAppLogTitle
            // 
            this.lblAppLogTitle.AutoSize = true;
            this.lblAppLogTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppLogTitle.Location = new System.Drawing.Point(16, 49);
            this.lblAppLogTitle.Name = "lblAppLogTitle";
            this.lblAppLogTitle.Size = new System.Drawing.Size(112, 18);
            this.lblAppLogTitle.TabIndex = 8;
            this.lblAppLogTitle.Text = "Application Log:";
            // 
            // LogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 483);
            this.Controls.Add(this.tabLogs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogsForm";
            this.Text = "Log File";
            this.Load += new System.EventHandler(this.Logs_Load);
            this.pnlLogs.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabSQL.ResumeLayout(false);
            this.tabApp.ResumeLayout(false);
            this.tabApp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView logsList;
        private System.Windows.Forms.ColumnHeader databaseID;
        private System.Windows.Forms.ColumnHeader processName;
        private System.Windows.Forms.ColumnHeader processHandle;
        private System.Windows.Forms.ColumnHeader processID;
        private System.Windows.Forms.ColumnHeader dateFound;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlLogs;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSmpLogs;
        private System.Windows.Forms.TabControl tabLogs;
        private System.Windows.Forms.TabPage tabSQL;
        private System.Windows.Forms.TabPage tabApp;
        private System.Windows.Forms.Label lblAppLogTitle;
        private System.Windows.Forms.Label lblLogFileTitle;
        private System.Windows.Forms.TextBox txtLogFile;
    }
}