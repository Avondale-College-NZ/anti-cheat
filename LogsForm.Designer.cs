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
            this.logsList = new System.Windows.Forms.ListView();
            this.databaseID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processHandle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateFound = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlLogs = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlLogs.SuspendLayout();
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
            this.btnRefresh.Location = new System.Drawing.Point(612, 429);
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
            this.pnlLogs.Location = new System.Drawing.Point(12, 12);
            this.pnlLogs.Name = "pnlLogs";
            this.pnlLogs.Size = new System.Drawing.Size(646, 396);
            this.pnlLogs.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClear.Location = new System.Drawing.Point(12, 429);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear Database";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // LogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 464);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pnlLogs);
            this.Controls.Add(this.btnRefresh);
            this.Name = "LogsForm";
            this.Text = "Log File";
            this.Load += new System.EventHandler(this.Logs_Load);
            this.pnlLogs.ResumeLayout(false);
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
    }
}