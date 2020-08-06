using ProcessCheck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
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
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread guithread = new Thread(new ThreadStart(WindowGui));
            Thread checkthread = new Thread(new ThreadStart(BGProc));

            // Start ThreadProcs
            guithread.Start();
            checkthread.Start();
        }
        public static class Globals
        {
            public static bool status = false; // Global Variable: "status"
            public static int count = 0; // Global Variable: "count"
            public static string logdir = Directory.GetCurrentDirectory(); // Global Variable: "logdirectory"
            public static bool autokill = true; // Global Variable: "autokill"
        }
        public static void WindowGui()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        private static List<string> TakeCurrent()
        {

            // Process[] currentprocs = Process.GetProcesses();
            // List<string> currentprocsids = new List<string>();
            List<string> currentprocsids = ProcessValidation.ListAllProcessIds();

            foreach (string p in currentprocsids)
            {
                string a = p.ToString();
                currentprocsids.Add(a);
            }

            return currentprocsids;
        }

        private static List<string> Compareprocesses(List<string> baseline, List<string> current)
        {

            List<string> differentProcesses = new List<string>();

            foreach (string pb in baseline)
            {
                foreach (string pc in current)
                {
                    if (pb != pc)
                    {

                        //hasunique = true;
                        string pstr = pc.ToString();
                        differentProcesses.Add(pstr);
                    }
                }
            }

            return differentProcesses;
        }


        public static void BGProc()
        {
            List<string> baseline = TakeCurrent();


            var curDir = Directory.GetCurrentDirectory();
            var txtFile = curDir + "\\proc.txt";
            string[] lines = File.ReadAllLines(txtFile);

            try
            {
                while (true)
                {
                    Thread.Sleep(2000);
                    while (Globals.status)
                    {

                        List<string> current = TakeCurrent();


                        List<string> differentProcesses = Compareprocesses(baseline, current);

                        //var diffprc = differentProcesses;

                        if (differentProcesses != null)
                        {

                            using (TextWriter tw = new StreamWriter(curDir + "\\SavedList.txt"))
                            {
                                foreach (string s in differentProcesses)
                                {
                                    tw.WriteLine(s);
                                }
                                tw.Close();
                            }
                        }

                        foreach (string line in lines)
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
            catch { }
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

