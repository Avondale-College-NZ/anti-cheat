using ProcessCheck;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace anti_cheat
{

    /// <summary>
    /// Notes:
    /// p.StartTime (Shows the time the process started)
    /// p.TotalProcessorTime(Shows the amount of CPU time the process has taken)
    /// p.Threads(gives access to the collection of threads in the process)
    /// </summary>
    /// 
    static class Background
    {
        public static int[] TakeCurrent()
        {
            int[] pids = ProcessValidation.ListAllProcessIds();

            return pids;
        }

        public static string[] Compareprocesses(int[] baseline, int[] current)
        // Runs comparison on "baseline" vs "current" array arguments
        {

            IEnumerable<int> differentProcesses = current.Except(baseline);
            string[] adifferentProcesses = differentProcesses.Select(x => x.ToString()).ToArray();

            return adifferentProcesses;
        }

        public static List<String> PIDlookup(string[] PIDarray)
        {
            List<string> PIDlist = new List<string>();

            for (int i = 0; i < PIDlist.Count; i++)
            {
                string a = ProcessValidation.Processlookup(PIDarray[i]);
                PIDlist.Add(a);
            }

            return PIDlist;
        }

    }
    static class Program
    {
        public static class Globals
        {
            public static bool status = false; // Global Variable: "status"
            public static int count = 0; // Global Variable: "count"
            public static string logdir = Directory.GetCurrentDirectory(); // Global Variable: "logdirectory"
            public static bool autokill = true; // Global Variable: "autokill"
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Debug.AutoFlush = true;

            Thread guithread = new Thread(new ThreadStart(WindowGui));
            Thread checkthread = new Thread(new ThreadStart(BGProc));

            // Start thread processes that handle Main.cs GUI and the background handler
            guithread.Start();
            checkthread.Start();
        }

        public static void WindowGui()
        {
            Debug.WriteLine("Entering WindowGui"); // Debug Message

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }



        public static void BGProc()
        {
            Debug.WriteLine("Entering BGProc"); // Debug Message 

            int[] baseline = Background.TakeCurrent();

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

                        int[] current = Background.TakeCurrent();
                        string[] differentProcesses = Background.Compareprocesses(baseline, current);
                        List<string> differentProcessesID = Background.PIDlookup(differentProcesses);

                        Debug.WriteLine("Exiting Main"); // Debug Messages
                        Debug.Indent();
                        Debug.Write(differentProcessesID);
                        Debug.Unindent();


                        if (differentProcessesID.Count > 0)
                        {
                            try
                            {
                                using (TextWriter tw = new StreamWriter(curDir + "\\SavedList.txt"))
                                {

                                    tw.Write(differentProcessesID);
                                    
                                    
                                    //foreach (string s in differentProcessesID)
                                    //{
                                    //    tw.WriteLine(s);
                                    //}
                                    tw.Close();
                                }
                            }
                            catch { }
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

