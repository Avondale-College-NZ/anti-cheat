﻿namespace anti_cheat
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblstatustitle = new System.Windows.Forms.Label();
            this.lblstatus = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tskBarMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tskBarMenuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tskBarMenuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.tskBarMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tskBarMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tskBarMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.Controlbtn = new System.Windows.Forms.Button();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Toolbarbtnset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Toolbarbtnlog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolBarbtncld = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tskBarMenu.SuspendLayout();
            this.ToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblstatustitle
            // 
            this.lblstatustitle.AutoSize = true;
            this.lblstatustitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatustitle.Location = new System.Drawing.Point(12, 42);
            this.lblstatustitle.Name = "lblstatustitle";
            this.lblstatustitle.Size = new System.Drawing.Size(85, 29);
            this.lblstatustitle.TabIndex = 2;
            this.lblstatustitle.Text = "Status:";
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus.ForeColor = System.Drawing.Color.Red;
            this.lblstatus.Location = new System.Drawing.Point(90, 38);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(131, 31);
            this.lblstatus.TabIndex = 3;
            this.lblstatus.Text = "Stopped.";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.tskBarMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Anti-Cheat";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // tskBarMenu
            // 
            this.tskBarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.tskBarMenuOpen,
            this.tskBarMenuSettings,
            this.tskBarMenuExit});
            this.tskBarMenu.Name = "taskBarMenu";
            this.tskBarMenu.Size = new System.Drawing.Size(117, 92);
            this.tskBarMenu.Text = " ";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tskBarMenuStart,
            this.tskBarMenuStop});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.startToolStripMenuItem.Text = "Status";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // tskBarMenuStart
            // 
            this.tskBarMenuStart.Name = "tskBarMenuStart";
            this.tskBarMenuStart.Size = new System.Drawing.Size(180, 22);
            this.tskBarMenuStart.Text = "Start";
            this.tskBarMenuStart.Click += new System.EventHandler(this.tskBarMenuStart_Click);
            // 
            // tskBarMenuStop
            // 
            this.tskBarMenuStop.Name = "tskBarMenuStop";
            this.tskBarMenuStop.Size = new System.Drawing.Size(180, 22);
            this.tskBarMenuStop.Text = "Stop";
            this.tskBarMenuStop.Click += new System.EventHandler(this.tskBarMenuStop_Click);
            // 
            // tskBarMenuOpen
            // 
            this.tskBarMenuOpen.Name = "tskBarMenuOpen";
            this.tskBarMenuOpen.Size = new System.Drawing.Size(116, 22);
            this.tskBarMenuOpen.Text = "Open";
            this.tskBarMenuOpen.Click += new System.EventHandler(this.tskBarMenuOpen_Click);
            // 
            // tskBarMenuSettings
            // 
            this.tskBarMenuSettings.Name = "tskBarMenuSettings";
            this.tskBarMenuSettings.Size = new System.Drawing.Size(116, 22);
            this.tskBarMenuSettings.Text = "Settings";
            this.tskBarMenuSettings.Click += new System.EventHandler(this.tskBarMenuSettings_Click);
            // 
            // tskBarMenuExit
            // 
            this.tskBarMenuExit.Name = "tskBarMenuExit";
            this.tskBarMenuExit.Size = new System.Drawing.Size(116, 22);
            this.tskBarMenuExit.Text = "Exit";
            this.tskBarMenuExit.Click += new System.EventHandler(this.tskBarMenuExit_Click);
            // 
            // Controlbtn
            // 
            this.Controlbtn.Location = new System.Drawing.Point(17, 94);
            this.Controlbtn.Name = "Controlbtn";
            this.Controlbtn.Size = new System.Drawing.Size(75, 23);
            this.Controlbtn.TabIndex = 5;
            this.Controlbtn.Text = "Start";
            this.Controlbtn.UseVisualStyleBackColor = true;
            this.Controlbtn.Click += new System.EventHandler(this.Controlbtn_Click);
            // 
            // ToolBar
            // 
            this.ToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.Toolbarbtnset,
            this.toolStripSeparator2,
            this.Toolbarbtnlog,
            this.toolStripSeparator3,
            this.ToolBarbtncld,
            this.toolStripSeparator4});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolBar.Size = new System.Drawing.Size(430, 25);
            this.ToolBar.TabIndex = 6;
            this.ToolBar.Text = "ToolBar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Toolbarbtnset
            // 
            this.Toolbarbtnset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Toolbarbtnset.Image = ((System.Drawing.Image)(resources.GetObject("Toolbarbtnset.Image")));
            this.Toolbarbtnset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Toolbarbtnset.Name = "Toolbarbtnset";
            this.Toolbarbtnset.Size = new System.Drawing.Size(23, 22);
            this.Toolbarbtnset.Text = "Settings";
            this.Toolbarbtnset.Click += new System.EventHandler(this.Toolbarbtnset_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Toolbarbtnlog
            // 
            this.Toolbarbtnlog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Toolbarbtnlog.Image = ((System.Drawing.Image)(resources.GetObject("Toolbarbtnlog.Image")));
            this.Toolbarbtnlog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Toolbarbtnlog.Name = "Toolbarbtnlog";
            this.Toolbarbtnlog.Size = new System.Drawing.Size(23, 22);
            this.Toolbarbtnlog.Text = "Logs";
            this.Toolbarbtnlog.ToolTipText = "Logs";
            this.Toolbarbtnlog.Click += new System.EventHandler(this.Toolbarbtnlog_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolBarbtncld
            // 
            this.ToolBarbtncld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolBarbtncld.Image = ((System.Drawing.Image)(resources.GetObject("ToolBarbtncld.Image")));
            this.ToolBarbtncld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolBarbtncld.Name = "ToolBarbtncld";
            this.ToolBarbtncld.Size = new System.Drawing.Size(23, 22);
            this.ToolBarbtncld.Text = "Cloud Integration";
            this.ToolBarbtncld.ToolTipText = "Cloud Integration";
            this.ToolBarbtncld.Click += new System.EventHandler(this.ToolBarbtncld_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(430, 267);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.Controlbtn);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.lblstatustitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Anti-Cheat";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tskBarMenu.ResumeLayout(false);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblstatustitle;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button Controlbtn;
        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Toolbarbtnset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Toolbarbtnlog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ToolBarbtncld;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ContextMenuStrip tskBarMenu;
        private System.Windows.Forms.ToolStripMenuItem tskBarMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem tskBarMenuExit;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tskBarMenuStart;
        private System.Windows.Forms.ToolStripMenuItem tskBarMenuStop;
        private System.Windows.Forms.ToolStripMenuItem tskBarMenuSettings;
    }
}

