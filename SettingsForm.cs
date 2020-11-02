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

            if (txtBlacklist.Text != "")
            {
                if (Properties.Settings.Default.blackList != txtBlacklist.Text) { changed = true; }
            }
            if (Properties.Settings.Default.autoKill != chkAutoKill.Checked) { changed = true; }
            if (Properties.Settings.Default.stealthMode != chkStealth.Checked) { changed = true; }
            if (txtLogFileDir.Text != "") {
                if (Properties.Settings.Default.logDir != txtLogFileDir.Text) { changed = true; }
            }
            if (Properties.Settings.Default.databaseSvr != txtSqlServer.Text) { changed = true; }
            if (Properties.Settings.Default.database != txtSqlDatabase.Text) { changed = true; }
            if (Properties.Settings.Default.authMethod != cmbSqlAuth.SelectedIndex) { changed = true; }
            if (Properties.Settings.Default.sqlUser != txtSqlUser.Text) { changed = true; }
            if (Properties.Settings.Default.sqlPass != txtSqlPass.Text) { changed = true; }

            return changed;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                
                Debug.WriteLine("Is it changed?" + changed);
                if (ControlsChanged())
                {
                    DialogResult dr = MessageBox.Show("Would you like to Save Curent Settings before Exit?", "Save Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                // Blacklist TextBox
                if (Properties.Settings.Default.blackList != null)
                {
                    txtBlacklist.Text = Properties.Settings.Default.blackList;
                }
                else { txtBlacklist.Text = Program.Globals.blackList; }

                // Autokill Checkbox
                if (Properties.Settings.Default.autoKill.ToString() != "")
                {
                    if (Properties.Settings.Default.autoKill)
                    {
                        chkAutoKill.Checked = true;
                    }
                    else { chkAutoKill.Checked = false; }
                }

                // Stealthmode Checkbox
                if (Properties.Settings.Default.stealthMode.ToString() != "")
                {
                    if (Properties.Settings.Default.stealthMode)
                    {
                        chkStealth.Checked = true;
                    }
                    else { chkStealth.Checked = false; }
                }

                // Log Directory TextBox
                if (Properties.Settings.Default.logDir != null)
                {
                    txtLogFileDir.Text = Properties.Settings.Default.logDir;
                }
                else { txtLogFileDir.Text = Program.Globals.logDir; }

                // SQL Server Location TextBox
                if (Properties.Settings.Default.databaseSvr != null)
                {
                    txtSqlServer.Text = Properties.Settings.Default.databaseSvr;
                }
                else { txtSqlServer.Text = Program.Globals.databaseSvr; }

                // SQL Database TextBox
                if (Properties.Settings.Default.database != null)
                {
                    txtSqlDatabase.Text = Properties.Settings.Default.database;
                }
                else { txtSqlDatabase.Text = Program.Globals.database; }

                // Selected SQL Authentication Method
                if (Properties.Settings.Default.authMethod == 1)
                {
                    cmbSqlAuth.SelectedIndex = 1;
                }
                else { cmbSqlAuth.SelectedIndex = 0; }

                // SQL User TextBox
                if (Properties.Settings.Default.sqlUser != null)
                {
                    txtSqlUser.Text = Properties.Settings.Default.sqlUser;
                }
                else { txtSqlUser.Text = Program.Globals.sqlUser; }

                // SQL Password Text box
                if (Properties.Settings.Default.sqlPass != "") 
                {
                    txtSqlPass.Text = "aaaaaa"; // Full the field with dummy data if a SQL password is saved.
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

                // Blacklist
                if (txtBlacklist.Text != "")
                {
                    Properties.Settings.Default.blackList = (txtBlacklist.Text);
                }
                else
                {
                    Properties.Settings.Default.blackList = "";
                }

                // Autokill
                if (chkAutoKill.Checked == true)
                {
                    Properties.Settings.Default.autoKill = true;
                }
                else { Properties.Settings.Default.autoKill = false; }

                // Stealthmode
                if (chkStealth.Checked == true)
                {
                    Properties.Settings.Default.stealthMode = true;
                }
                else { Properties.Settings.Default.stealthMode = false; }

                // Log Directory
                if (txtLogFileDir.Text != "")
                {
                    Properties.Settings.Default.logDir = (txtLogFileDir.Text);
                }
                else
                {
                    Properties.Settings.Default.logDir = Directory.GetCurrentDirectory().ToString();
                }

                // Autokill
                if (chkAutoKill.Checked == true)
                {
                    Properties.Settings.Default.autoKill = true;
                }
                else { Properties.Settings.Default.autoKill = false; }

                // SQL Server
                if (txtSqlServer.Text != "")
                {
                    Properties.Settings.Default.databaseSvr = (txtSqlServer.Text);
                }
                else
                {
                    Properties.Settings.Default.databaseSvr = Program.Globals.databaseSvr;
                }

                // Database
                if (txtSqlDatabase.Text != "")
                {
                    Properties.Settings.Default.database = (txtSqlDatabase.Text);
                }
                else
                {
                    Properties.Settings.Default.database = Program.Globals.databaseSvr;
                }

                // SQL Authentication
                if (cmbSqlAuth.SelectedIndex == 1 && txtSqlUser.Text != "") // Checks which Auth method is selected and if there is a SQL username.
                {
                    // Authmethod 1 is SQL Authentication
                    Properties.Settings.Default.authMethod = 1;

                }
                else {
                    if (cmbSqlAuth.SelectedIndex == 1)
                    {
                        MessageBox.Show("Please enter a SQL Username to use SQL Authentication.", "Empty SQL Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Properties.Settings.Default.authMethod = 0; /* Auth method 0 is Windows Authentication */ }

                // SQL User & Password
                if (txtSqlUser.Text != "")
                {
                    Properties.Settings.Default.sqlUser = txtSqlUser.Text;
                    Properties.Settings.Default.sqlPass = txtSqlPass.Text; /* --- INSECURE STORAGE OF PASSWORD ---- */
                }
                else
                {
                    Properties.Settings.Default.sqlUser = Program.Globals.sqlUser;
                    Properties.Settings.Default.sqlPass = Program.Globals.sqlPass; /* --- INSECURE STORAGE OF PASSWORD ---- */
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
                    txtLogFileDir.Text = dlg.fullPath;
                }
            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex); // Write any exception to Log file.
            }
        }

        private void Cmbsqlauth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Globals.authMethod = cmbSqlAuth.SelectedIndex;
            if (cmbSqlAuth.Text == "SQL Authentication") {
                lblSqlUser.Visible = true;
                lblSqlPass.Visible = true;
                txtSqlUser.Visible = true;
                txtSqlPass.Visible = true;
            } else {
                lblSqlUser.Visible = false;
                lblSqlPass.Visible = false;
                txtSqlUser.Visible = false;
                txtSqlPass.Visible = false;
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
