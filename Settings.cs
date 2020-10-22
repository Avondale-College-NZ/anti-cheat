using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using folderSelect;
using System.Diagnostics;

namespace anti_cheat
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            TxtLogfiledir.Text = Program.Globals.logdir;
            Cmbsqlauth.SelectedIndex = 0;
            txtsqlserver.Text = Program.Globals.databaseSvr;
            txtsqldatabase.Text = Program.Globals.database;
            txtsqluser.Text = Program.Globals.sqluser;
            txtsqlpass.Text = Program.Globals.sqlpass;
        }

        private void Btnfiledir_Click(object sender, EventArgs e)
        {
            try
            {
                FolderSelect dlg = new FolderSelect();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo info = dlg.info;
                    TxtLogfiledir.Text = dlg.fullPath;
                    Properties.Settings.Default.logdir = dlg.fullPath;
                    Properties.Settings.Default.Save();

                    // extract the directory info.
                    string[] strArray = new string[4];
                    try
                    {
                        strArray[0] = "Creation Time : " + info.CreationTime.ToString();
                        strArray[1] = "Full Name     : " + info.FullName;
                        strArray[2] = "Last Access Time : " + info.LastAccessTime.ToString();
                        strArray[3] = "Last Write Time  : " + info.LastWriteTime.ToString();
                    } catch { }
                    //textBox3.Lines = strArray;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }

        private void Cmbsqlauth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Globals.authmethod = Cmbsqlauth.SelectedIndex;
            if (Cmbsqlauth.Text == "SQL Authentication") {
                lblsqluser.Visible = true;
                lblsqlpass.Visible = true;
                txtsqluser.Visible = true;
                txtsqlpass.Visible = true;
            } else {
                lblsqluser.Visible = false;
                lblsqlpass.Visible = false;
                txtsqluser.Visible = false;
                txtsqlpass.Visible = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Are you sure you would like to Reset settings to their default values?", "Reset Settings", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                Program.resetSettings();
            }

        }
    }
}
