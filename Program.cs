using ProcessCheck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

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

        private static int[] TakeCurrent()
        {
            // Process[] currentprocs = Process.GetProcesses();
            // List<string> currentprocsids = new List<string>();

            int[] pids = ProcessValidation.ListAllProcessIds();

            // foreach (string p in currentprocsids)
            // {
            //     string a = p.ToString();
            //     currentprocsids.Add(a);
            // }

            return pids;
        }

        private static string[] Compareprocesses(int[] baseline, int[] current)
        {

            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            IEnumerable<int> differentProcesses = current.Except(baseline);

            //Console.WriteLine("Numbers in first array but not second array:");
            //foreach (int n in aOnlyNumbers)
            //{
            //    Console.WriteLine(n);
            //}



            //List<string> differentProcesses = new List<string>();

            //foreach (string pb in baseline)
            //{
            //    foreach (string pc in current)
            //    {
            //        if (pb == pc)
            //        {

            //            //hasunique = true;
            //            string pstr = pc.ToString();
            //            differentProcesses.Add(pstr);
            //        }
            //    }
            //}
            string[] adifferentProcesses = differentProcesses.Select(x => x.ToString()).ToArray();

            return adifferentProcesses;
        }


        public static void BGProc()
        {
            int[] baseline = TakeCurrent();


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

                        int[] current = TakeCurrent();


                        string[] differentProcesses = Compareprocesses(baseline, current);

                        //var diffprc = differentProcesses;

                        if (differentProcesses.Length > 0)
                        {
                            try
                            {
                                using (TextWriter tw = new StreamWriter(curDir + "\\SavedList.txt"))
                                {
                                    foreach (string s in differentProcesses)
                                    {
                                        tw.WriteLine(s);
                                    }
                                    tw.Close();
                                }
                            } catch { }
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

