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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("a");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("b");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("c");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("d");
            this.logsList = new System.Windows.Forms.ListView();
            this.databaseID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processHandle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateFound = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.logsList.HideSelection = false;
            this.logsList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.logsList.Location = new System.Drawing.Point(0, 0);
            this.logsList.Name = "logsList";
            this.logsList.Size = new System.Drawing.Size(800, 450);
            this.logsList.TabIndex = 1;
            this.logsList.UseCompatibleStateImageBehavior = false;
            this.logsList.View = System.Windows.Forms.View.Details;
            // 
            // databaseID
            // 
            this.databaseID.Text = "Database ID";
            this.databaseID.Width = 79;
            // 
            // processName
            // 
            this.processName.Text = "Process Name";
            this.processName.Width = 157;
            // 
            // processID
            // 
            this.processID.DisplayIndex = 4;
            this.processID.Text = "Process ID";
            this.processID.Width = 116;
            // 
            // processHandle
            // 
            this.processHandle.DisplayIndex = 2;
            this.processHandle.Text = "Process Handle";
            this.processHandle.Width = 146;
            // 
            // dateFound
            // 
            this.dateFound.DisplayIndex = 3;
            this.dateFound.Text = "Date Found";
            this.dateFound.Width = 85;
            // 
            // Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logsList);
            this.Name = "Logs";
            this.Text = "Log File";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView logsList;
        private System.Windows.Forms.ColumnHeader databaseID;
        private System.Windows.Forms.ColumnHeader processName;
        private System.Windows.Forms.ColumnHeader processHandle;
        private System.Windows.Forms.ColumnHeader processID;
        private System.Windows.Forms.ColumnHeader dateFound;
    }
}