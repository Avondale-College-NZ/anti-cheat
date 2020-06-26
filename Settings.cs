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

        private void Settings_Load(object sender, EventArgs e)
        {
            TxtLogfiledir.Text = Main.Globals.logdir;
        }

        private void lblautokill_Click(object sender, EventArgs e)
        {

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
                    Main.Globals.logdir = dlg.fullPath;

                    // extract the directory info.
                    string[] strArray = new string[4];

                    strArray[0] = "Creation Time : " + info.CreationTime.ToString();
                    strArray[1] = "Full Name     : " + info.FullName;
                    strArray[2] = "Last Access Time : " + info.LastAccessTime.ToString();
                    strArray[3] = "Last Write Time  : " + info.LastWriteTime.ToString();

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
