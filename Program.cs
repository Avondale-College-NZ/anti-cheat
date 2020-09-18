using ProcessCheck;
using SimpleLogger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Windows.Forms;


namespace anti_cheat
{

    /// <summary>
    /// Notes:
    /// p.StartTime (Shows the time the process started)
    /// p.TotalProcessorTime(Shows the amount of CPU time the process has taken)
    /// p.Threads(gives access to the collection of threads in the process)
    /// </summary>
    /// 

    public struct UniqueProc
    {
        public string Name{get;set;}
        public string ProcessId{get;set;}
        public string Handle{get;set;}
    }
    public static class Extensions
    {
        public static List<T> AddAlso<T>(this List<T> list, T item)
        {
            list.Add(item);
            return list;
        }
    }

    static class Background
    {
        public static int[] TakeCurrent()
        {
            int[] pids = { };
            try
            {
                pids = ProcessValidation.ListAllProcessIds();
            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex);
            }

            return pids;
        }

        public static string[] Compareprocesses(int[] baseline, int[] current)
        {
            // Runs comparison on "baseline" vs "current" array arguments
            string[] adifferentProcesses = { };
            try
            {
                IEnumerable<int> differentProcesses = current.Except(baseline);
                adifferentProcesses = differentProcesses.Select(x => x.ToString()).ToArray();

                Debug.WriteLine("Compareprocesses:");                                   // Debug Message
                foreach (string s in adifferentProcesses) { Debug.Write(s + "\n"); }    // Debug Message
            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex);
            }

            return adifferentProcesses;
        }

        public static List<UniqueProc> PIDlookup(string[] PIDarray)
        {

            List<UniqueProc> uniqueProcs = new List<UniqueProc>();

            try
            {
                
                ManagementClass MgmtClass = new ManagementClass("Win32_Process");
                for (int c = 0; c < PIDarray.Length - 1;)
                {
                    foreach (ManagementObject mo in MgmtClass.GetInstances())
                    {
                        if (mo["ProcessId"].ToString() == PIDarray[c])
                        {
                            
                            Debug.WriteLine(mo["Name"].ToString().Replace(".exe", ""), mo["ProcessId"].ToString(), mo["Handle"].ToString());

                            uniqueProcs.Add(new UniqueProc { Name = mo["Name"].ToString().Replace(".exe", ""), ProcessId = mo["ProcessId"].ToString(), Handle = mo["Handle"].ToString()});
                        }
                    }
                    c++;
                }
            }
            catch(Exception ex)
            {
                SimpleLog.Log(ex);
            }

            return uniqueProcs;

            }

            public static void LogtoDB(string procName, string procID, string procHandle)
            {



                Debug.Write(Program.Globals.connectionStringWinAuth);
                if (Program.Globals.authmethod == 1)
                {
                    try
                    {
                        SqlConnection sqlCon = new SqlConnection(Program.Globals.connectionStringSQLAuth);

                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("LogProc", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@ProcessName", procName);
                        sqlCmd.Parameters.AddWithValue("@ProcessID", procID);
                        sqlCmd.Parameters.AddWithValue("@ProcessHandle", procHandle);
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        SqlConnection sqlCon = new SqlConnection(Program.Globals.connectionStringWinAuth);

                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("LogProc", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@ProcessName", procName);
                        sqlCmd.Parameters.AddWithValue("@ProcessID", procID);
                        sqlCmd.Parameters.AddWithValue("@ProcessHandle", procHandle);
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        SimpleLog.Log(ex); // Write exception with all inner exceptions to log

                    }
                }

                //return true;
            }

            public static bool GetfromDB()
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=(local)\sqle2012;Initial Catalog=;Integrated Security=True");
                SqlDataAdapter sqlda = new SqlDataAdapter("", sqlCon); // Query 
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                foreach (DataRow row in dtbl.Rows)
                {

                }
                return true;
            }
        }

    static class Program
        {

            public static class Globals
            {
                public static string[] uniqueids = { };                         // Global String array: "uniqueids"
                public static bool status = false;                              // Global Variable: "status" 
                public static int count = 0;                                    // Global Variable: "count"
                public static string logdir = Directory.GetCurrentDirectory();  // Global Variable: "logdirectory"
                public static bool autokill = true;                             // Global Variable: "autokill"
                public static string databaseSvr = "tpisql01.avcol.school.nz";  // Global Variable: "databaseSvr"
                public static string database = "Anticheat";                    // Global Variable: "database"
                public static string databaseTbl = "tblProcesses";              // Global Variable: "databaseTbl"
                public static string sqluser = "";                              // Global Variable: "sqluser"
                public static string sqlpass = "";                              // Global Variable: "sqlpass"
                public static int authmethod = 0;                               // Global Variable: "authmethod" - 0 = Windows Authentication, 2 = SQL Authentication
                public static string connectionStringWinAuth = @"Data Source = " + databaseSvr + "; Initial Catalog = " + database +
        "; Integrated Security = True;";                                        // Global Variable: "connectionStringWinAuth"
                public static string connectionStringSQLAuth = @"Data Source = " + databaseSvr + "; Initial Catalog = " + database +
        "; User ID=(" + sqluser + "); Password=(" + sqlpass + ");";             // Global Variable: "connectionStringSQLAuth"
            }

            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                SimpleLog.StartLogging();
                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                Debug.AutoFlush = true;

                Thread guithread = new Thread(new ThreadStart(WindowGui));
                Thread checkthread = new Thread(new ThreadStart(BGProc));

                // Start thread processes that handle Main.cs GUI and the background handler
                SimpleLog.Info("Starting threads: 'guithread' and 'checkthread'."); // Writes 'info' level message to log
                bool exception = false;
                try
                {
                    guithread.Start();
                    checkthread.Start();

                }
                catch (Exception ex)
                {

                    exception = true;
                    SimpleLog.Log(ex); // Write exception with all inner exceptions to log

                }
                if (!exception)
                {
                    SimpleLog.Info("Succsessfully started threads: 'guithread' and 'checkthread'.");
                }


            }

            public static void WindowGui()
            {
                Debug.WriteLine("Entering WindowGui"); // Debug Message
                SimpleLog.Info("Entered 'Main graphical interface thread (WindowGui)'."); // Writes 'info' level message to log

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }

            public static void BGProc()
            {
                Debug.WriteLine("Entering BGProc"); // Debug Message 
                SimpleLog.Info("Entered 'Background thread (BGProc)'."); // Writes 'info' level message to log

                int[] baseline = Background.TakeCurrent();

                var curDir = Directory.GetCurrentDirectory();
                var txtFile = curDir + "\\proc.txt";

                string[] proclines = File.ReadAllLines(txtFile);

                

                try
                {
                    while (true)
                    {
                        Thread.Sleep(2000);
                        while (Globals.status)
                        {

                            int[] current = Background.TakeCurrent();

                            Globals.uniqueids = Background.Compareprocesses(baseline, current);         // Finds IDs of processes that started after anticheat
                            List<UniqueProc> differentProcessesID = Background.PIDlookup(Globals.uniqueids);     

                        foreach (var p in differentProcessesID)
                        {
                            Debug.WriteLine("Id {0} Name {1}, Handle {2} ", p.Name, p.ProcessId, p.Handle);

                            Thread dblog = new Thread(() => Background.LogtoDB(p.Name, p.ProcessId, p.Handle));
                            dblog.Start();
                            dblog.Join();

                        }
                            



                            Debug.WriteLine("Write to file:");                                            // Debug Message

                            //foreach (string s in differentProcessesID) { Debug.Write(s + "\n"); }         // Debug Message

                            //if (differentProcessesID.Length > 0)
                            //{
                            //    try
                            //    {
                            //        using (TextWriter tw = new StreamWriter(curDir + "\\SavedList.txt"))
                            //        {
                            //            foreach (string s in differentProcessesID) { tw.Write(s + " " + "\n"); }
                            //            tw.Close();

                            //        }
                            //    }
                            //    catch (Exception ex) { SimpleLog.Log(ex); }
                            //}

                            foreach (string line in proclines)
                            {

                                if (Checkproc(line))
                                {
                                    MessageBox.Show("Process \"" + line + "\" was found.");
                                    if (Globals.autokill && Globals.status == true)
                                    {
                                        string a = ProcessValidation.ProcKill(line);
                                        MessageBox.Show("Process \"" + line + "\" " + "\"" + a + "\"" + "  was killed.");
                                    }
                                }

                                if (Checkapp(line))
                                {
                                    MessageBox.Show("Application \"" + line + "\" was found.");
                                    if (Globals.autokill && Globals.status == true)
                                    {
                                        string a = ProcessValidation.ProcKill(line);
                                        MessageBox.Show("Process \"" + line + "\" " + "\"" + a + "\"" + "  was killed.");
                                    }
                                }

                            }
                        }
                    }
                }
                catch (Exception ex) { SimpleLog.Log(ex); }
            }

        private static bool LogtoDB(string name, string processId, string handle)
        {
            throw new NotImplementedException();
        }

        public static bool Checkapp(string proc)
            {
                bool check = ProcessValidation.CheckForApplicationByName(proc.ToString());
                return check;
            }
            public static bool Checkproc(string proc)
            {
                bool check = ProcessValidation.CheckForProcessByName(proc.ToString());
                return check;
            }
        }
    }

