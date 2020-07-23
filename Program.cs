using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ProcessCheck;
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

        private static Process[] TakeBaseline()
        {
            Process[] baseline = Process.GetProcesses();

                return baseline;
        }

        private static Process[] TakeCurrent()
        {

            Process[] currentprocs = Process.GetProcesses();

                return currentprocs;
        }

        private static List<Process> CompareBaseline(Process[] baseline, Process[] current)
        {

            // Implement compare between process lists.
            // Using LINQ

            //T[] array1 = getOneArray();
            //T[] array2 = getAnotherArray();
            //Process[] diffprocs = new Process[baseline.Length + current.Length];
            //Array.Copy(baseline, diffprocs, baseline.Length);
            //Array.Copy(current, 0, diffprocs, baseline.Length, current.Length);

            //bool hasunique = false;
            List<Process> differentProcesses = new List<Process>();
            foreach (Process pb in baseline)
            {
                foreach (Process pc in current)
                {
                    if (pb != pc)
                    {
                        //hasunique = true;
                        differentProcesses.Add(pc);
                    }
                }
            }

            //String[] strdiffprocs = diffprocs.Distinct().ToArray();
            return differentProcesses;
        }


        public static void BGProc()
        {
            Process[] baseline = TakeBaseline();
            
            
            var curDir = Directory.GetCurrentDirectory();
            var txtFile = curDir + "\\proc.txt";
            string[] lines = File.ReadAllLines(txtFile);
            
            try{
                while (true){
                    Thread.Sleep(2000);
                    while (Globals.status){

                        Process[] current = TakeCurrent();


                        List<Process> differentProcesses = CompareBaseline(baseline, current);

                        //var diffprc = differentProcesses;
                        



                        if (differentProcesses != null)
                        {

                            using (TextWriter tw = new StreamWriter(curDir + "\\SavedList.txt"))
                            {
                                foreach (Process s in differentProcesses)
                                {
                                    tw.WriteLine(s);
                                }
                                tw.Close();
                            }
                        }
                        foreach (string line in lines){

                            if (Checkproc(line))
                            {
                                MessageBox.Show("Process \"" + line + "\" was found.");
                                if (Globals.autokill && Globals.status == true)
                                {
                                    string a = ProcessValidation.ProcKill(line);
                                    MessageBox.Show("Process \"" + line + "\" " + "\"" + a + "\""  + "  was killed.");
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
            } catch { }
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

