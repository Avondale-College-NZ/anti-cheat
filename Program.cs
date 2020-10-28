﻿using ProcessCheck;
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
        public string Name { get; set; }
        public string ProcessId { get; set; }
        public string Handle { get; set; }
        public int Length { get; }
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

                            uniqueProcs.Add(new UniqueProc { Name = mo["Name"].ToString().Replace(".exe", ""), ProcessId = mo["ProcessId"].ToString(), Handle = mo["Handle"].ToString() });
                        }
                    }
                    c++;
                }
            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex);
            }

            return uniqueProcs;

        }

        public static void LogtoDB(string procName, string procID, string procHandle)
        {

            if (Program.Globals.authmethod == 1)
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(Program.Globals.connectionStringSQLAuth);
                    sqlCon.Open();

                    string query = "SELECT * FROM " + Program.Globals.databaseTbl + " WHERE ProcessName=@procname"; // + " AND DateLogged < DATEADD(day, -1, GETDATE()";

                    SqlCommand checkCmd = new SqlCommand(query, sqlCon);
                    checkCmd.Parameters.AddWithValue("@procname", procName);

                    SqlDataReader checkreader = checkCmd.ExecuteReader();
                    Debug.WriteLine(checkreader.HasRows);

                    if (checkreader.HasRows)
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("LogProc", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@ProcessName", procName);
                        sqlCmd.Parameters.AddWithValue("@ProcessID", procID);
                        sqlCmd.Parameters.AddWithValue("@ProcessHandle", procHandle);
                        sqlCmd.ExecuteNonQuery();
                    }
                    else { Debug.Indent(); Debug.WriteLine("Dupe value"); Debug.Unindent(); }
                    
                }
                catch (Exception ex)
                {
                    //SimpleLog.E(ex); // Write exception with all inner exceptions to log
                }

            }
            else
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(Program.Globals.connectionStringWinAuth);

                    SimpleLog.Info(Program.Globals.connectionStringWinAuth);

                    sqlCon.Open();
                    string query = "SELECT * FROM " + Program.Globals.databaseTbl + " WHERE ProcessName=@procname"; // + " AND DateLogged < DATEADD(day, -1, GETDATE()";

                    SqlCommand checkCmd = new SqlCommand(query, sqlCon);
                    checkCmd.Parameters.AddWithValue("@procname", procName);
                    SqlDataReader checkreader = checkCmd.ExecuteReader();
 
                    bool reader = checkreader.HasRows;
                    checkreader.Close();

                    if (reader == false)
                    {

                        SqlCommand sqlCmd = new SqlCommand("LogProc", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@ProcessName", procName);
                        sqlCmd.Parameters.AddWithValue("@ProcessID", procID);
                        sqlCmd.Parameters.AddWithValue("@ProcessHandle", procHandle);
                        sqlCmd.ExecuteNonQuery();
                        checkreader.Close();
                        sqlCon.Close();
                        SimpleLog.Log("Logged " + procName + "To the database");
                    }
                    else 
                    { 
                        Debug.Indent(); Debug.WriteLine("Duplicate value"); Debug.Unindent();
                        checkreader.Close();
                        sqlCon.Close();
                    }

                }
                catch (System.Data.SqlClient.SqlException exception)
                {
                    // Output exception information to log.
                    SimpleLog.Log(exception);
                }
                catch (Exception ex)
                {
                    //SimpleLog.Log(ex); // Write any exception to Log file.

                }

            }
        }
    }


    static class Program
    {

        public static class Globals
        {
            // Anticheat  Globals:
            public static string[] uniqueids = { };                   // Global String array: "uniqueids"
            public static bool status = false;                        // Global Variable: "status" 
            public static Thread guithread = null;                    // Global Thread: "guithread"
            public static int count = 0;                              // Global Variable: "count"

            // User Defined Globals:
            public static string logdir;                              // Global Variable: "logdirectory"
            public static bool autokill;                              // Global Variable: "autokill"

            // SQL Server Location:
            public static string databaseSvr;                         // Global Variable: "databaseSvr"
            public static string database;                            // Global Variable: "database"
            public static string databaseTbl;                         // Global Variable: "databaseTbl"

            // SQL Server Authentication:
            public static int authmethod;                             // Global Variable: "authmethod" - 0 = Windows Authentication, 2 = SQL Authentication
            public static string sqluser;                             // Global Variable: "sqluser"

            /* --- INSECURE STORAGE OF PASSWORD ---- */
            public static string sqlpass;                             // Global Variable: "sqlpass"

            // SQL Server Connection Strings:
            public static string connectionStringWinAuth;            // Global Variable: "connectionStringWinAuth"
            public static string connectionStringSQLAuth;            // Global Variable: "connectionStringSQLAuth"
        }

        public static void InitSettings() 
        {
            try
            {
                // User Defined Globals:
                if (Properties.Settings.Default.logdir != null)
                {
                    Globals.logdir = Properties.Settings.Default.logdir;
                }

                if (Properties.Settings.Default.autokill.ToString() != "")
                {
                    Globals.autokill = Properties.Settings.Default.autokill;
                }
                // SQL Server Location:
                if (Properties.Settings.Default.databaseSvr != null)
                {
                    Globals.databaseSvr = Properties.Settings.Default.databaseSvr;
                }
                if (Properties.Settings.Default.database != null)
                {
                    Globals.database = Properties.Settings.Default.database;
                }
                if (Properties.Settings.Default.databaseTbl != null)
                {
                    Globals.databaseTbl = Properties.Settings.Default.databaseTbl;
                }

                // SQL Server Authentication:
                if (Properties.Settings.Default.authmethod.ToString() != "") 
                {
                    Globals.authmethod = Properties.Settings.Default.authmethod;
                }
                        
                Globals.sqluser = Properties.Settings.Default.sqluser;
                Globals.sqlpass = Properties.Settings.Default.sqlpass;

                Globals.connectionStringWinAuth = @"Data Source=" + Globals.databaseSvr + ";Initial Catalog=" + Globals.database + ";Integrated Security=True;"; 
                Globals.connectionStringSQLAuth = @"Data Source=" + Globals.databaseSvr + ";Initial Catalog=" + Globals.database + ";User ID=(" + Globals.sqluser + ");Password=(" + Globals.sqlpass + ");";


        Debug.WriteLine("List of current Globals: \n" + Globals.logdir + "\n" +
               Globals.autokill + "\n" +
               Globals.databaseSvr + "\n" +
               Globals.database + "\n" +
               Globals.databaseTbl + "\n" +
               Globals.authmethod + "\n"
    );

            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex); // Write any exception to Log file.

            }
            SimpleLog.Info("List of current Globals: \n" + Globals.logdir + "\n" +
               Globals.autokill + "\n" +
               Globals.databaseSvr + "\n" +
               Globals.database + "\n" +
               Globals.databaseTbl + "\n" +
               Globals.authmethod + "\n"
    );

        }

        public static void ResetSettings()
        {
            try
            {
                // User Defined Settings:
                Properties.Settings.Default.logdir = Directory.GetCurrentDirectory().ToString(); 

                Globals.autokill = false;
                Properties.Settings.Default.autokill = Globals.autokill;

                // Database Location Settings:
                Globals.databaseSvr = "tpisql01.avcol.school.nz";
                Properties.Settings.Default.databaseSvr = Globals.databaseSvr;
                Globals.database = "Anticheat";
                Properties.Settings.Default.database = Globals.database;
                Globals.databaseTbl = "tblProcess";
                Properties.Settings.Default.databaseTbl = Globals.databaseTbl;

                // SQL Server Authentication Settings:
                Globals.authmethod = 0;
                Properties.Settings.Default.authmethod = Globals.authmethod;
                Globals.sqluser = "";
                Properties.Settings.Default.sqluser = Globals.sqluser;
                Globals.sqlpass = "";
                Properties.Settings.Default.sqlpass = Globals.sqlpass;

                Properties.Settings.Default.Save();

                Globals.connectionStringWinAuth = @"Data Source=" + Globals.databaseSvr + ";Initial Catalog=" + Globals.database + ";Integrated Security=True;";
                Globals.connectionStringSQLAuth = @"Data Source=" + Globals.databaseSvr + ";Initial Catalog=" + Globals.database + ";User ID=(" + Globals.sqluser + ");Password=(" + Globals.sqlpass + ");";
            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex); // Write any exception to Log file.
            }

        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Starts SimpleLog & Debug Console output.
            SimpleLog.StartLogging();
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Debug.AutoFlush = false;

            // Takes all Persistant settings from Settings.settings and sets them to Global Variables
            //ResetSettings();
            InitSettings();


            // Initializes Threads for GUI & Background process.
            Thread guithread = new Thread(new ThreadStart(WindowGui));
            Thread checkthread = new Thread(new ThreadStart(BGProc));

            Globals.guithread = guithread;
            guithread.IsBackground = false;

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
                while(true)
                {
                    Thread.Sleep(2000);
                    while (Program.Globals.status)
                    {

                        int[] current = Background.TakeCurrent();

                        Program.Globals.uniqueids = Background.Compareprocesses(baseline, current);         // Finds IDs of processes that started after anticheat
                        List<UniqueProc> differentProcessesID = Background.PIDlookup(Program.Globals.uniqueids);

                        if (differentProcessesID.Count() > 0)
                        {
                            foreach (var p in differentProcessesID)
                            {
                               // Debug.WriteLine("Id: {0} Name: {1}, Handle: {2} ", p.Name, p.ProcessId, p.Handle);

                                Thread dblog = new Thread(() => Background.LogtoDB(p.Name, p.ProcessId, p.Handle));
                                dblog.IsBackground = true;
                                dblog.Start();

                            }
                        }
                        

                        foreach (string line in proclines)
                        {

                            if (Checkproc(line))
                            {
                                MessageBox.Show("Process \"" + line + "\" was found.");
                                if (Program.Globals.autokill && Program.Globals.status == true)
                                {
                                    string a = ProcessValidation.ProcKill(line);
                                    MessageBox.Show("Process \"" + line + "\" " + "\"" + a + "\"" + "  was killed.");
                                }
                            }

                            if (Checkapp(line))
                            {
                                MessageBox.Show("Application \"" + line + "\" was found.");
                                if (Program.Globals.autokill && Program.Globals.status == true)
                                {
                                    string a = ProcessValidation.ProcKill(line);
                                    MessageBox.Show("Process \"" + line + "\" " + "\"" + a + "\"" + "  was killed.");
                                }
                            }
                        }
                    }

                    int formcount = Int32.Parse(Application.OpenForms.Count.ToString());
                    if (formcount == 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex);
            }
            Application.Exit();
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