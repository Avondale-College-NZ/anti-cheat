using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ProcessCheck;

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
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new main());

            Thread guithread = new Thread(new ThreadStart(WindowGui));
            Thread checkthread = new Thread(new ThreadStart(BGProc));

            // Start ThreadProcs
            guithread.Start();
            checkthread.Start();
        }
        public static void BGProc()
        {
            var curDir = Directory.GetCurrentDirectory();
            var txtFile = curDir + "\\proc.txt";
            string[] lines = File.ReadAllLines(txtFile);

            // TODO: Write kill if found, alert if found, 
            while (true){
                Thread.Sleep(5000);
                while (main.Globals.status)
                {
                    //Thread.Sleep(5000);
                    foreach (string line in lines)
                    {

                        if (Checkproc(line))
                        {
                            MessageBox.Show("Process \"" + line + "\" was found.");
                        }

                        if (Checkapp(line))
                        {
                            MessageBox.Show("Application \"" + line + "\" was found.");
                        }
                    }
                }
            }
        }
        public static void WindowGui()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main());
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

