using CMDLauncher.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMDLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Core.InitCore();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Core.PostInit();

            Application.Run(new LoadingScreen(Startup.GetStartupTasks(), "startup", "Starting ...").Build());
        }
    }
}
