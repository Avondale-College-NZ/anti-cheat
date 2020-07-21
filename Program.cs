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

        private static string[] CompareBaseline(Process[] baseline, Process[] current)
        {
            
            // Implement compare between process lists.
            
            string[] diffprocs = {"a","b"};
            return diffprocs;
        }


        public static void BGProc()
        {
            Process[] baseline = TakeBaseline();
            Process[] current = TakeCurrent();
            
            string[] diffprocs = CompareBaseline(baseline,current);


            var curDir = Directory.GetCurrentDirectory();
            var txtFile = curDir + "\\proc.txt";
            string[] lines = File.ReadAllLines(txtFile);
            
            try{
                while (true){
                    Thread.Sleep(2000);
                    while (Globals.status){
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

