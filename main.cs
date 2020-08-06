using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ProcessCheck;
using System.Threading;

namespace anti_cheat
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        
        private void Main_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;

        }

        private void Controlbtn_Click(object sender, EventArgs e)
        {
            Program.Globals.count++;
            int count = Program.Globals.count % 2;
            if (count != 0) 
            {
                Program.Globals.status = true;
                lblstatus.Text = "Running...";
                lblstatus.ForeColor = Color.Lime;
                Controlbtn.Text = "Stop";
            } else {
                Program.Globals.status = false;
                lblstatus.Text = "Stopped.";
                lblstatus.ForeColor = Color.Red;
                Controlbtn.Text = "Start";
            }
                      
        }

        private void Toolbarbtnset_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
           set.Show(); 
        }

        private void Toolbarbtnlog_Click(object sender, EventArgs e)
        {
            Logs log = new Logs();
           log.Show();
        }

        private void ToolBarbtncld_Click(object sender, EventArgs e)
        {
            Cloud cld = new Cloud();
           cld.Show();
        }
    }
}
