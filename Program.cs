using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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

            // The constructor for the Thread class requires a ThreadStart
            // delegate that represents the method to be executed on the
            // thread.  C# simplifies the creation of this delegate.
            Thread guithread = new Thread(new ThreadStart(Gui));

            // Start ThreadProc.  Note that on a uniprocessor, the new
            // thread does not get any processor time until the main thread
            // is preempted or yields.  Uncomment the Thread.Sleep that
            // follows t.Start() to see the difference.
            guithread.Start();

            Form1 c = new Form1();
            c.ShowDialog();

        }
        public static void Gui()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main());
        }
    }
}
