using SimpleLogger;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace anti_cheat
{

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // Event Handlers for Form Events.
            this.FormClosing += new FormClosingEventHandler(Main_FormClosing);
            this.Resize += new EventHandler(Main_Resize);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            notifyIcon.Visible = true;
        }
        private void setClosed(object sender, FormClosedEventArgs e)
        {
            globals.set = null;
        }
        private void logClosed(object sender, FormClosedEventArgs e)
        {
            globals.log = null;
        }
        private void cldClosed(object sender, FormClosedEventArgs e)
        {
            globals.cld = null;
        }

        private void ToggleState()
        {
            Program.InitSettings();
            Program.Globals.count++;
            int count = Program.Globals.count % 2;
            if (count != 0)
            {
                Program.Globals.status = true;
                lblstatus.Text = "Running...";
                notifyIcon.ShowBalloonTip(50, "Anticheat has been Started", "Successfully Started Anticheat process.", ToolTipIcon.Info);
                lblstatus.ForeColor = Color.Lime;
                Controlbtn.Text = "Stop";
            }
            else
            {
                Program.Globals.status = false;
                lblstatus.Text = "Stopped.";
                notifyIcon.ShowBalloonTip(50, "Anticheat has been Stopped", "Successfully Stopped Anticheat process.", ToolTipIcon.Info);
                lblstatus.ForeColor = Color.Red;
                Controlbtn.Text = "Start";
            }
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

                // Creates a list of open forms and then closes all open forms.
                FormCollection fc = Application.OpenForms;
                try {
                    foreach (Form form in fc.Cast<Form>().ToList())
                    {
                        //iterate through
                        if (form.Name == "Settings")
                        {
                            globals.set.Close();
                        }
                        else if (form.Name == "Logs")
                        {
                            globals.log.Close();

                        }
                        else if (form.Name == "Cloud")
                        {
                            globals.cld.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    SimpleLog.Log(ex);
                }

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
                ShowInTaskbar = true; // When set to false wont be included in Application.Openforms
                notifyIcon.Visible = true;
                Visible = true;

                // Creates a list of open forms and then minimizes all open forms.
                FormCollection fc = Application.OpenForms;
                try
                {
                    foreach (Form form in fc.Cast<Form>().ToList())
                    {
                        //iterate through
                        if (form.Name == "Settings")
                        {
                            globals.set.WindowState = FormWindowState.Minimized;
                        }
                        else if (form.Name == "Logs")
                        {
                            globals.log.WindowState = FormWindowState.Minimized;

                        }
                        else if (form.Name == "Cloud")
                        {
                            globals.cld.WindowState = FormWindowState.Minimized;
                        }
                    }
                }
                catch (Exception ex)
                {
                    SimpleLog.Log(ex);
                }
            }
        }

        private void Open()
        {
            Visible = true;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Open();
        }

        private void Controlbtn_Click(object sender, EventArgs e)
        {
            ToggleState();
        }

        private void Toolbarbtnset_Click(object sender, EventArgs e)
        {
            if (globals.set == null)
            {
                globals.set = new SettingsForm();
                globals.set.FormClosed += setClosed;
            }

            globals.set.Show();
        }

        private void Toolbarbtnlog_Click(object sender, EventArgs e)
        {
            if (globals.log == null)
            {
                globals.log = new LogsForm();
                globals.log.FormClosed += logClosed;
            }
            globals.log.Show();
        }

        private void ToolBarbtncld_Click(object sender, EventArgs e)
        {
            if (globals.cld == null)
            {
                globals.cld = new CloudForm();
                globals.cld.FormClosed += cldClosed;
            }
            globals.cld.Show();
        }

        private void tskBarMenuOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void tskBarMenuExit_Click(object sender, EventArgs e)
        {
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
        }

        private void tskBarMenuStart_Click(object sender, EventArgs e)
        {

            if (Program.Globals.status == false)
            {
                ToggleState();
            }
            else
            {
                notifyIcon.ShowBalloonTip(100, "Anticheat Start Failed", "Failed to start Anticheat as it is already Running.", ToolTipIcon.Warning);
            }
        }

        private void tskBarMenuStop_Click(object sender, EventArgs e)
        {
            if (Program.Globals.status == true)
            {
                ToggleState();
            }
            else
            {
                notifyIcon.ShowBalloonTip(100, "Anticheat Stop Failed", "Failed to stop Anticheat as it is already Stopped.", ToolTipIcon.Warning);
            }
        }

        private void tskBarMenuSettings_Click(object sender, EventArgs e)
        {
            globals.set.Show();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.Globals.status)
            {
                notifyIcon.ShowBalloonTip(50, "Anticheat is currently Running", "The Anticheat Process is currently Running", ToolTipIcon.Info);
            }
            else
            {
                notifyIcon.ShowBalloonTip(50, "Anticheat is currently Stopped", "The Anticheat Process is currently Stopped", ToolTipIcon.Warning);
            }
        }
    }
    public static class globals
    {
        public static SettingsForm set;
        public static LogsForm log;
        public static CloudForm cld;
    }
}
