using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace MouseSpeedSwitcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            bool runone;
            Mutex run = new Mutex(true, "MouseSpeedSwitcher", out runone);
            if (runone)
            {
                run.ReleaseMutex();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (new Tray())
                {
                    Application.Run();
                }
            }
        }
    }
}
