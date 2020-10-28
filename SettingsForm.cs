using System;
using SimpleLogger;
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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

        }

        // Variable to check if form is changed
        public static bool changed;

        private void Settings_Load(object sender, EventArgs e)
        {
            // Adds Handlers for Closing and Control changes.
            this.FormClosing += new FormClosingEventHandler(SettingsForm_FormClosing);

            // Populates the controls to reflect the current settings.
            LoadSettings();

        }

        protected bool ControlsChanged() 
        {
            bool changed = false;
            if (TxtLogfiledir.Text != "") {
                if (Properties.Settings.Default.logdir != TxtLogfiledir.Text) { changed = true; }
            }
            if (Properties.Settings.Default.autokill != Chkautokill.Checked) { changed = true; }
            if (Properties.Settings.Default.databaseSvr != txtsqlserver.Text) { changed = true; }
            if (Properties.Settings.Default.database != txtsqldatabase.Text) { changed = true; }
            if (Properties.Settings.Default.authmethod != Cmbsqlauth.SelectedIndex) { changed = true; }
            if (Properties.Settings.Default.sqluser != txtsqluser.Text) { changed = true; }
            if (Properties.Settings.Default.sqlpass != txtsqlpass.Text) { changed = true; }

            return changed;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                
                Debug.WriteLine("Is it changed?" + changed);
                if (ControlsChanged())
                {
                    DialogResult dr = MessageBox.Show("Would you like to Save Curent Settings?", "Save Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        SaveSettings();
                    }
                }
            }
        }

        private void LoadSettings()
        {
            try
            {
                // Log Directory TextBox
                if (Properties.Settings.Default.logdir != null)
                {
                    TxtLogfiledir.Text = Properties.Settings.Default.logdir;
                }
                else { TxtLogfiledir.Text = Program.Globals.logdir; }

                // Autokill Checkbox
                if (Properties.Settings.Default.autokill.ToString() != "")
                {
                    if (Properties.Settings.Default.autokill)
                    {
                        Chkautokill.Checked = true;
                    }
                    else { Chkautokill.Checked = false; }
                }

                // SQL Server Location TextBox
                if (Properties.Settings.Default.databaseSvr != null)
                {
                    txtsqlserver.Text = Properties.Settings.Default.databaseSvr;
                }
                else { txtsqlserver.Text = Program.Globals.databaseSvr; }

                // SQL Database TextBox
                if (Properties.Settings.Default.database != null)
                {
                    txtsqldatabase.Text = Properties.Settings.Default.database;
                }
                else { txtsqldatabase.Text = Program.Globals.database; }

                // Selected SQL Authentication Method
                if (Properties.Settings.Default.authmethod == 1)
                {
                    Cmbsqlauth.SelectedIndex = 1;
                }
                else { Cmbsqlauth.SelectedIndex = 0; }

                // SQL User TextBox
                if (Properties.Settings.Default.sqluser != null)
                {
                    txtsqluser.Text = Properties.Settings.Default.sqluser;
                }
                else { txtsqluser.Text = Program.Globals.sqluser; }

                // SQL Password Text box
                if (Properties.Settings.Default.sqlpass != "") 
                {
                    txtsqlpass.Text = "aaaaaa";
                }

            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex); // Write any exception to Log file.
                MessageBox.Show("Failed to Load Settings. ", "Failed To Load Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettings() 
        {
            try
            {
                // Log Directory
                if (TxtLogfiledir.Text != "")
                {
                    Properties.Settings.Default.logdir = (TxtLogfiledir.Text);
                }
                else
                {
                    Properties.Settings.Default.logdir = Directory.GetCurrentDirectory().ToString();
                }

                // Autokill
                if (Chkautokill.Checked == true)
                {
                    Properties.Settings.Default.autokill = true;
                }
                else { Properties.Settings.Default.autokill = false; }

                // SQL Server
                if (txtsqlserver.Text != "")
                {
                    Properties.Settings.Default.databaseSvr = (txtsqlserver.Text);
                }
                else
                {
                    Properties.Settings.Default.databaseSvr = Program.Globals.databaseSvr;
                }

                // Database
                if (txtsqldatabase.Text != "")
                {
                    Properties.Settings.Default.database = (txtsqldatabase.Text);
                }
                else
                {
                    Properties.Settings.Default.database = Program.Globals.databaseSvr;
                }

                // SQL Authentication
                if (Cmbsqlauth.SelectedIndex == 1 && txtsqluser.Text != "") // Checks which Auth method is selected and if there is a SQL username.
                {
                    // Authmethod 1 is SQL Authentication
                    Properties.Settings.Default.authmethod = 1;

                }
                else { Properties.Settings.Default.authmethod = 0; /* Auth method 0 is Windows Authentication */ }

                // SQL User & Password
                if (txtsqluser.Text != "")
                {
                    Properties.Settings.Default.sqluser = txtsqluser.Text;
                    Properties.Settings.Default.sqlpass = txtsqlpass.Text; /* --- INSECURE STORAGE OF PASSWORD ---- */
                }
                else
                {
                    Properties.Settings.Default.sqluser = Program.Globals.sqluser;
                    Properties.Settings.Default.sqlpass = Program.Globals.sqlpass; /* --- INSECURE STORAGE OF PASSWORD ---- */
                }

                Properties.Settings.Default.Save();

                SimpleLog.Info("Successfully Saved Settings");
            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex); // Write any exception to Log file.
                MessageBox.Show("Failed to Save Settings. ", "Failed To Save Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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
                }
            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex); // Write any exception to Log file.
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
                Program.ResetSettings();
                LoadSettings();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you would like to Save Current Settings?", "Save Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                SaveSettings();
            }

        }
    }
}
