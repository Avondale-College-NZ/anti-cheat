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

        public static int LogtoDB(string procName, string procID, string procHandle)
        {

            if (Program.Globals.authMethod == 1)
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

                    SimpleLog.Log(ex); // Write exception with all inner exceptions to log
                    return 5;
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
                catch (SqlException sex)
                {
                        switch (sex.Number)
                        {
                            case 53:
                            if (System.Windows.Forms.Application.OpenForms["Main"] != null)
                            {
                                (System.Windows.Forms.Application.OpenForms["Main"] as Main).ToggleState();
                            }

                            break;
                            
                            default:
                                return 66;
                                throw;
                        } 
                } catch (Exception ex)
                {
                    SimpleLog.Log(ex); // Write any exception to Log file.
                }
            }
            return 0;
        }
    }


    static class Program
    {

        public static class Globals
        {
            // Anticheat  Globals:
            public static string[] uniqueIds = { };                   // Global String array: "uniqueids"
            public static string[] procLines = { };                   // Global String array: "proclines"
            public static bool status = false;                        // Global Variable: "status" 
            public static Thread guiThread = null;                    // Global Thread: "guithread"
            public static int count = 0;                              // Global Variable: "count"

            // User Defined Globals:
            public static string logDir;                              // Global Variable: "logdirectory"
            public static string blackList;                           // Global Variable: "blacklist"
            public static bool autoKill;                              // Global Variable: "autokill"
            public static bool stealthMode;                           // Global Variable: "stealthmode"

            // SQL Server Location:
            public static string databaseSvr;                         // Global Variable: "databaseSvr"
            public static string database;                            // Global Variable: "database"
            public static string databaseTbl;                         // Global Variable: "databaseTbl"

            // SQL Server Authentication:
            public static int authMethod;                             // Global Variable: "authmethod" - 0 = Windows Authentication, 2 = SQL Authentication
            public static string sqlUser;                             // Global Variable: "sqluser"

            /* --- INSECURE STORAGE OF PASSWORD ---- */
            public static string sqlPass;                             // Global Variable: "sqlpass"

            // SQL Server Connection Strings:
            public static string connectionStringWinAuth;            // Global Variable: "connectionStringWinAuth"
            public static string connectionStringSQLAuth;            // Global Variable: "connectionStringSQLAuth"
        }

        public static void InitSettings() 
        {
            try
            {
                // User Defined Globals:
                if (Properties.Settings.Default.logDir != "")
                {
                    Globals.logDir = Properties.Settings.Default.logDir;
                }
                else
                {
                    Properties.Settings.Default.logDir = Directory.GetCurrentDirectory().ToString();
                    Globals.logDir = Properties.Settings.Default.logDir;
                }

                Globals.blackList = Properties.Settings.Default.blackList;
                Globals.stealthMode = Properties.Settings.Default.stealthMode;


                if (Properties.Settings.Default.autoKill.ToString() != "")
                {
                    Globals.autoKill = Properties.Settings.Default.autoKill;
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
                if (Properties.Settings.Default.authMethod.ToString() != "") 
                {
                    Globals.authMethod = Properties.Settings.Default.authMethod;
                }
                        
                Globals.sqlUser = Properties.Settings.Default.sqlUser;
                Globals.sqlPass = Properties.Settings.Default.sqlPass;

                Globals.connectionStringWinAuth = @"Data Source=" + Globals.databaseSvr + ";Initial Catalog=" + Globals.database + ";Integrated Security=True;"; 
                Globals.connectionStringSQLAuth = @"Data Source=" + Globals.databaseSvr + ";Initial Catalog=" + Globals.database + ";User ID=(" + Globals.sqlUser + ");Password=(" + Globals.sqlPass + ");";


        Debug.WriteLine("List of current Globals: \n" + Globals.logDir + "\n" +
               Globals.autoKill + "\n" +
               Globals.databaseSvr + "\n" +
               Globals.database + "\n" +
               Globals.databaseTbl + "\n" +
               Globals.authMethod + "\n"
    );

            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex); // Write any exception to Log file.

            }
            SimpleLog.Info("List of current Globals: \n" + Globals.logDir + "\n" +
               Globals.autoKill + "\n" +
               Globals.databaseSvr + "\n" +
               Globals.database + "\n" +
               Globals.databaseTbl + "\n" +
               Globals.authMethod + "\n"
    );

        }

        public static void ResetSettings()
        {
            try
            {
                // User Defined Settings:
                Properties.Settings.Default.logDir = Directory.GetCurrentDirectory().ToString();

                Properties.Settings.Default.blackList = "";

                Globals.autoKill = false;
                Properties.Settings.Default.autoKill = Globals.autoKill;

                Globals.stealthMode = false;
                Properties.Settings.Default.stealthMode = Globals.stealthMode;

                // Database Location Settings:
                Globals.databaseSvr = "tpisql01.avcol.school.nz";
                Properties.Settings.Default.databaseSvr = Globals.databaseSvr;
                Globals.database = "Anticheat";
                Properties.Settings.Default.database = Globals.database;
                Globals.databaseTbl = "tblProcess";
                Properties.Settings.Default.databaseTbl = Globals.databaseTbl;

                // SQL Server Authentication Settings:
                Globals.authMethod = 0;
                Properties.Settings.Default.authMethod = Globals.authMethod;
                Globals.sqlUser = "";
                Properties.Settings.Default.sqlUser = Globals.sqlUser;
                Globals.sqlPass = "";
                Properties.Settings.Default.sqlPass = Globals.sqlPass;

                Properties.Settings.Default.Save();

                Globals.connectionStringWinAuth = @"Data Source=" + Globals.databaseSvr + ";Initial Catalog=" + Globals.database + ";Integrated Security=True;";
                Globals.connectionStringSQLAuth = @"Data Source=" + Globals.databaseSvr + ";Initial Catalog=" + Globals.database + ";User ID=(" + Globals.sqlUser + ");Password=(" + Globals.sqlPass + ");";
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

            Globals.guiThread = guithread;
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

            try
            {
                while(true)
                {
                    Thread.Sleep(2000);
                    while (Program.Globals.status)
                    {

                        int[] current = Background.TakeCurrent();

                        Program.Globals.uniqueIds = Background.Compareprocesses(baseline, current);         // Finds IDs of processes that started after anticheat
                        List<UniqueProc> differentProcessesID = Background.PIDlookup(Program.Globals.uniqueIds);

                        if (differentProcessesID.Count() > 0)
                        {
                            foreach (var p in differentProcessesID)
                            {
                                int r;
                                Thread dblog = new Thread(() => { r = Background.LogtoDB(p.Name, p.ProcessId, p.Handle); });
                                
                                dblog.IsBackground = true;
                                dblog.Start();
                                
                            }
                        }

                        var txtFile = Globals.blackList;
                        if (txtFile != "" && File.Exists(txtFile))
                        {
                            string[] Globalsproclines = File.ReadAllLines(txtFile);
                        }


                        if (Globals.procLines.Length > 0) { 
                            foreach (string line in Globals.procLines)
                            {

                                if (Checkproc(line))
                                {
                                    MessageBox.Show("Process \"" + line + "\" was found.");
                                    if (Program.Globals.autoKill && Program.Globals.status == true)
                                    {
                                        string ProcName = ProcessValidation.ProcKill(line);
                                        if (Program.Globals.stealthMode == false)
                                        {
                                            MessageBox.Show("Process \"" + line + "\" " + "\"" + ProcName + "\"" + "  was killed.");
                                        }
                                    }
                                }

                                if (Checkapp(line))
                                {
                                    MessageBox.Show("Application \"" + line + "\" was found.");
                                    if (Program.Globals.autoKill && Program.Globals.status == true)
                                    {
                                        string ProcName = ProcessValidation.ProcKill(line);
                                        if (Program.Globals.stealthMode == false) {
                                            MessageBox.Show("Process \"" + line + "\" " + "\"" + ProcName + "\"" + "  was killed.");
                                        }
                                    }
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