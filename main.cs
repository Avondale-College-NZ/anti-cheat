using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace anti_cheat
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Main_FormClosing);
            this.Resize += new EventHandler(Main_Resize);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            notifyIcon.Visible = false;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine(e.CloseReason.ToString());
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Debug.WriteLine(e.CloseReason.ToString());
                e.Cancel = true;
                notifyIcon.Visible = true;
                Visible = false;
            }
            else { notifyIcon.Dispose(); }

        }



        private void Main_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
                Visible = false;

            }
        }

        private void Open()
        {
            Visible = true;
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Open();
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
            }
            else
            {
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

        private void tskBarMenuOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void tskBarMenuExit_Click(object sender, EventArgs e)
        {
            if (Application.MessageLoop)
            {
                //Application.Exit();
            }
        }
    }
}
