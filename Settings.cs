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

namespace anti_cheat
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void cmbsqlauth_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            lblsqluser.Visible = true;
            lblsqlpass.Visible = true;
            txtsqluser.Visible = true;
            txtsqlpass.Visible = true;
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            TxtLogfiledir.Text = Program.Globals.logdir;
            cmbsqlauth.SelectedIndex = 0;

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
                    Program.Globals.logdir = dlg.fullPath;

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
                Console.WriteLine(err.Message);
            }
        }
    }
}
