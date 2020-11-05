using System;
using SimpleLogger;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace anti_cheat
{
    public partial class LogsForm : Form
    {
        public LogsForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void Logs_Load(object sender, EventArgs e)
        {

            // Textbox settings for "txtLogFile"
            txtLogFile.ReadOnly = true;
            txtLogFile.Text = SimpleLog.GetFileName(DateTime.Now);
            txtLogFile.Focus();
            txtLogFile.SelectionStart = txtLogFile.Text.Length;

            populate_List();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populate_List();
        }

        public void populate_List()
        {
            this.UseWaitCursor = true;
            logsList.Items.Clear();

            if (Program.Globals.authMethod == 1) // 1 = SQL Authentication
            {
                try
                {
                    Debug.WriteLine(Program.Globals.connectionStringSQLAuth);
                    SqlConnection sqlCon = new SqlConnection(Program.Globals.connectionStringSQLAuth);

                    string query = "SELECT * FROM " + Program.Globals.databaseTbl;

                    SqlDataAdapter sqlda = new SqlDataAdapter(query, sqlCon); // Query 
                    DataTable dtbl = new DataTable();
                    sqlda.Fill(dtbl);
                    logsList.View = View.Details;


                    for (int i = 0; i < dtbl.Rows.Count; i++)
                    {
                        DataRow dr = dtbl.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr["DatabaseID"].ToString());
                        listitem.SubItems.Add(dr["Processname"].ToString());
                        listitem.SubItems.Add(dr["ProcessID"].ToString());
                        listitem.SubItems.Add(dr["ProcessHandle"].ToString());
                        listitem.SubItems.Add(dr["DateLogged"].ToString());
                        logsList.Items.Add(listitem);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is SqlException)
                    {
                        Debug.WriteLine(ex);

                       
                        return;
                    }

                    //SimpleLog.Log(ex); // Write exception with all inner exceptions to log
                    throw;
                }

            }
            else
            {
                try
                {
                    Debug.WriteLine(Program.Globals.connectionStringWinAuth);
                    SqlConnection sqlCon = new SqlConnection(Program.Globals.connectionStringWinAuth);

                    string query = "SELECT * FROM " + Program.Globals.databaseTbl;

                    SqlDataAdapter sqlda = new SqlDataAdapter(query, sqlCon); // Query 
                    DataTable dtbl = new DataTable();
                    sqlda.Fill(dtbl);
                    logsList.View = View.Details;



                    for (int i = 0; i < dtbl.Rows.Count; i++)
                    {
                        DataRow dr = dtbl.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr["DatabaseID"].ToString());
                        listitem.SubItems.Add(dr["Processname"].ToString());
                        listitem.SubItems.Add(dr["ProcessID"].ToString());
                        listitem.SubItems.Add(dr["ProcessHandle"].ToString());
                        listitem.SubItems.Add(dr["DateLogged"].ToString());
                        logsList.Items.Add(listitem);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is SqlException)
                    {
                        Debug.WriteLine(ex);

                        return;
                    }

                    SimpleLog.Log(ex); // Write exception with all inner exceptions to log
                    //throw;
                }
                this.UseWaitCursor = false;
            }    
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you would like to Clear the Database?", "Clear Database", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (Program.Globals.authMethod == 1)
                {
                    try
                    {

                        string query = "TRUNCATE TABLE " + Program.Globals.databaseTbl;

                        using (SqlConnection connection = new SqlConnection(Program.Globals.connectionStringWinAuth))
                        {
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Connection.Open();
                            command.ExecuteNonQuery();
                            command.Connection.Close();
                        }

                        SimpleLog.Info("Cleared Database.");

                    }
                    catch (Exception ex)
                    {
                        SimpleLog.Log(ex);
                    }
                }
                else
                {
                    try 
                    { 

                        string query = "TRUNCATE TABLE " + Program.Globals.databaseTbl; // Defines the SQL query inline. 

                        // Defines the connection with the Windows Authentication connection string.
                        using (SqlConnection connection = new SqlConnection(Program.Globals.connectionStringWinAuth)) 
                        {
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Connection.Open(); // Opens the connection to the SQL Server
                            command.ExecuteNonQuery(); // Executes the inline SQL query against the specified database.
                            command.Connection.Close(); // Closes the the connection.
                        }

                        SimpleLog.Info("Cleared Database.");

                    }
                    catch (Exception ex)
                    {
                        SimpleLog.Log(ex);
                    }
            
                }

            }
        }

        private void btnSmpLogs_Click(object sender, EventArgs e)
        {
             SimpleLog.ShowLogFile(); 
        }

        private void tabApp_Click(object sender, EventArgs e)
        {

        }
    }
}
