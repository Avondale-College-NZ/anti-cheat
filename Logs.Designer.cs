namespace anti_cheat
{
    partial class Logs
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
            this.LogsList = new System.Windows.Forms.ListView();
            this.databaseID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processHandle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateFound = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogsList
            // 
            this.LogsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.databaseID,
            this.processName,
            this.processID,
            this.processHandle,
            this.dateFound});
            this.LogsList.GridLines = true;
            this.LogsList.HideSelection = false;
            this.LogsList.Location = new System.Drawing.Point(0, 0);
            this.LogsList.MultiSelect = false;
            this.LogsList.Name = "LogsList";
            this.LogsList.Size = new System.Drawing.Size(565, 402);
            this.LogsList.TabIndex = 1;
            this.LogsList.UseCompatibleStateImageBehavior = false;
            this.LogsList.View = System.Windows.Forms.View.Details;
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
            this.dateFound.Width = 100;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(478, 408);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 443);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.LogsList);
            this.Name = "Logs";
            this.Text = "Log File";
            this.Load += new System.EventHandler(this.Logs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LogsList;
        private System.Windows.Forms.ColumnHeader databaseID;
        private System.Windows.Forms.ColumnHeader processName;
        private System.Windows.Forms.ColumnHeader processHandle;
        private System.Windows.Forms.ColumnHeader processID;
        private System.Windows.Forms.ColumnHeader dateFound;
        private System.Windows.Forms.Button btnRefresh;
    }
}