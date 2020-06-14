using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ProcessCheck;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace anti_cheat
{
    static class Program
    {
        [DllImport("kernel32.dll",
           EntryPoint = "GetStdHandle",
           SetLastError = true,
           CharSet = CharSet.Auto,
           CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll",
            EntryPoint = "AllocConsole",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();
        private const int STD_OUTPUT_HANDLE = -11;
        private const int MY_CODE_PAGE = 437;
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
            Thread guithread = new Thread(new ThreadStart(windowGui));
            Thread consolethread = new Thread(new ThreadStart(windowConsole));
            // Start ThreadProc.  Note that on a uniprocessor, the new
            // thread does not get any processor time until the main thread
            // is preempted or yields.  Uncomment the Thread.Sleep that
            // follows t.Start() to see the difference.
            guithread.Start();
            consolethread.Start();
            //Form1 c = new Form1();
           // c.ShowDialog();

           // var curDir = Directory.GetCurrentDirectory();
           // var txtFile = curDir + "\\proc.txt";
            //string[] lines = File.ReadAllLines(txtFile);

            //foreach (string line in lines)
             //   Console.WriteLine(line);
        }
        public static void windowConsole()
        {
            Console.WriteLine("This text you can see in debug output window.");

            AllocConsole();
            IntPtr stdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
            SafeFileHandle safeFileHandle = new SafeFileHandle(stdHandle, true);
            FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
            Encoding encoding = System.Text.Encoding.GetEncoding(MY_CODE_PAGE);
            StreamWriter standardOutput = new StreamWriter(fileStream, encoding);
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);

            Console.WriteLine("This text you can see in console window.");
            Console.ReadKey();
            MessageBox.Show("Now I'm happy!");
        }
        public static void windowGui()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main());
        }
        public static bool Checkproc(string proc)
        {
            bool check = ProcessValidation.CheckForProcessByName(proc.ToString()); 
            return check;
        }
    }
}

