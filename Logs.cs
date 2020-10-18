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
using System.Data.SqlClient;

namespace anti_cheat
{
    public partial class Logs : Form
    {
        public Logs()
        {
            InitializeComponent();
        }

        private void Logs_Load(object sender, EventArgs e)
        {
            populate_List();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populate_List();
        }

        public void populate_List()
        {

            if (Program.Globals.authmethod == 1)
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(Program.Globals.connectionStringSQLAuth);


                    
                }
                catch (Exception ex)
                {
                    SimpleLog.Log(ex); // Write exception with all inner exceptions to log
                }

            }
            else
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(Program.Globals.connectionStringWinAuth);

                }
                catch (Exception ex)
                {
                    SimpleLog.Log(ex); // Write exception with all inner exceptions to log

                }
            }








            using (AnticheatDataSet db = new AnticheatDataSet())
            {
                List<AnticheatDataSet.tblProcessRow> list = db.tblProcess.ToList();
                foreach(AnticheatDataSet.tblProcessRow r in list)
                {
                    ListViewItem item = new ListViewItem(r.DatabaseID.ToString());
                    item.SubItems.Add(r.DatabaseID.ToString());
                    item.SubItems.Add(r.DatabaseID.ToString());
                    item.SubItems.Add(r.DatabaseID.ToString());
                    LogsList.Items.Add(item);
                }


            }    
        }

    }
}
