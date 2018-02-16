using CMDLauncher.Module;
using CMDLauncher.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CMDLauncher
{
    public class Startup
    {

        public static List<Task> GetStartupTasks()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(new UpdateTask());
            return tasks;
        }

    }

    public class UpdateTask : Task
    {
        public UpdateTask() : base("Searching for updates")
        {

        }

        public override bool CanBeThreaded()
        {
            return true;
        }

        public override bool CanDoMultiTasking()
        {
            return false;
        }

        public override bool RequiresInternetConnection()
        {
            return false;
        }

        protected override bool RunTask(IProgressBar bar)
        {
            //CommandUtils.loadLauncherCommands;

            HttpWebRequest request = HttpWebRequest.CreateHttp("http://creativemd.de/service/version_new.php?name=" + Core.ProgramName);
            request.UserAgent = "Mozilla/5.0";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    Internet.InternetModule.ChangeState(ModuleState.Loaded);
                    string content = reader.ReadToEnd();
                    var newest = new Version(content);
                    var current = new Version(Core.ProgramVersion);

                    if(newest.CompareTo(current) > 0)
                    {
                        //Download new version
                        
                        return true;
                    }
                    else
                        return true;
                }

            }
            catch (Exception)
            {
                
            }

            Internet.InternetModule.ChangeState(ModuleState.Failed);
            bar.StartStep(1);
            bar.FinishStep();
            return true;
        }
    }
}
