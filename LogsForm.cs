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
            populate_List();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LogsList.Items.Clear();
            populate_List();
        }




        public void populate_List()
        {

            if (Program.Globals.authmethod == 1)
            {
                try
                {
                    Debug.WriteLine(Program.Globals.connectionStringSQLAuth);
                    SqlConnection sqlCon = new SqlConnection(Program.Globals.connectionStringSQLAuth);

                string query = "SELECT * FROM " + Program.Globals.databaseTbl;

                    SqlDataAdapter sqlda = new SqlDataAdapter(query, sqlCon); // Query 
                    DataTable dtbl = new DataTable();
                    sqlda.Fill(dtbl);
                    LogsList.View = View.Details;


                    for (int i = 0; i < dtbl.Rows.Count; i++)
                    {
                        DataRow dr = dtbl.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr["DatabaseID"].ToString());
                        listitem.SubItems.Add(dr["Processname"].ToString());
                        listitem.SubItems.Add(dr["ProcessID"].ToString());
                        listitem.SubItems.Add(dr["ProcessHandle"].ToString());
                        listitem.SubItems.Add(dr["DateLogged"].ToString());
                        LogsList.Items.Add(listitem);
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
                    LogsList.View = View.Details;



                    for (int i = 0; i < dtbl.Rows.Count; i++)
                    {
                        DataRow dr = dtbl.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr["DatabaseID"].ToString());
                        listitem.SubItems.Add(dr["Processname"].ToString());
                        listitem.SubItems.Add(dr["ProcessID"].ToString());
                        listitem.SubItems.Add(dr["ProcessHandle"].ToString());
                        listitem.SubItems.Add(dr["DateLogged"].ToString());
                        LogsList.Items.Add(listitem);
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
        }

    }
}
