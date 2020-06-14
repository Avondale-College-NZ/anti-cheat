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

namespace anti_cheat
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        public static class Globals
        {
            public static bool status = false; // Global Variable: "status"
            public static string cheatproc = "";
        }
        
        private void main_Resize(object sender, EventArgs e)
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

        private void main_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;

        }

        private void Buttonlist_Click(object sender, EventArgs e)
        {
            textbox.Text = string.Empty;

            // populate it with a list of all applications along with
            // some information about those application
            textbox.Text = ProcessValidation.ListAllByImageName();
        }

        private string Check(string cheatproc)
        {
                bool bTest = ProcessValidation.CheckForApplicationByName(cheatproc.ToString());

                switch (bTest)
                {
                    case true:
                        MessageBox.Show(cheatproc + " was found.");
                        break;
                    default:
                        break;
                }
            return cheatproc;
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            Globals.status = true;
        }
        
    }
}
