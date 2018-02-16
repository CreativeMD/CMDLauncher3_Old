using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDLauncher.Utils
{ 
    public class FileUtils
    {

        public static bool DeleteFolder(string Path, Logger Log, IProgressBar bar = null)
        {
            if (Log == null)
                Log = Core.MainLog;
            string[] files = Directory.GetFiles(Path, "*", SearchOption.AllDirectories);

            if (bar != null)
            {
                bar.StartStep(files.Length);
            }

            for(int i = 0; i < files.Length; i++)
            {
                try
                {
                    File.Delete(files[i]);
                }
                catch (IOException e)
                {
                    Log.Log("Could not delete {0}! An unexpected error occurred {1}.", files[i], e);
                }
                if (bar != null)
                    bar.SetProgress(i);
            }

            Directory.Delete(Path, true);

            if (bar != null)
                bar.FinishStep();

            return true;
        }

        public static bool RenameFolder(string SourcePath, string DestinationPath, Logger Log, IProgressBar bar = null)
        {
            if (Log == null)
                Log = Core.MainLog;
            string[] files = Directory.GetFiles(SourcePath, "*", SearchOption.AllDirectories);

            if (bar != null)
            {
                bar.StartStep(files.Length);
            }

            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    Directory.CreateDirectory(files[i].Replace(SourcePath, DestinationPath));
                    File.Move(files[i], files[i].Replace(SourcePath, DestinationPath));
                }
                catch (IOException e)
                {
                    Log.Log("Could not rename {0} to {1}! An unexpected error occurred {1}.", files[i], files[i].Replace(SourcePath, DestinationPath), e);
                }
                if (bar != null)
                    bar.SetProgress(i);
            }

            Directory.Delete(SourcePath, true);

            if (bar != null)
                bar.FinishStep();

            return true;
        }

        public static bool CopyFolder(string SourcePath, string DestinationPath, Logger Log, bool overwrite = true, IProgressBar bar = null)
        {
            if (Log == null)
                Log = Core.MainLog;
            string[] files = Directory.GetFiles(SourcePath, "*", SearchOption.AllDirectories);

            if (bar != null)
            {
                bar.StartStep(files.Length);
            }

            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    Directory.CreateDirectory(files[i].Replace(SourcePath, DestinationPath));
                    File.Copy(files[i], files[i].Replace(SourcePath, DestinationPath), overwrite);
                }
                catch (IOException e)
                {
                    Log.Log("Could not copy {0} to {1}! An unexpected error occurred {1}.", files[i], files[i].Replace(SourcePath, DestinationPath), e);
                }
                if (bar != null)
                    bar.SetProgress(i);
            }

            Directory.Delete(SourcePath, true);

            if (bar != null)
                bar.FinishStep();

            return true;
        }
    }

    public class DeleteFolder : Task
    {

        public string Path;

        public DeleteFolder(string Path) : base("Delete Folder")
        {
            this.Path = Path;
        }

        public override bool CanBeThreaded()
        {
            return true;
        }

        public override bool CanDoMultiTasking()
        {
            return true;
        }

        public override bool RequiresInternetConnection()
        {
            return false;
        }

        protected override bool RunTask(IProgressBar bar)
        {
            return FileUtils.DeleteFolder(Path, Log, bar);
        }
    }

    public class RenameFolder : Task
    {
        public string SourcePath;
        public string DestinationPath;

        public RenameFolder(string SourcePath, string DestinationPath) : base("Rename Folder")
        {
            this.SourcePath = SourcePath;
            this.DestinationPath = DestinationPath;
        }

        public override bool CanBeThreaded()
        {
            return true;
        }

        public override bool CanDoMultiTasking()
        {
            return true;
        }

        public override bool RequiresInternetConnection()
        {
            return false;
        }

        protected override bool RunTask(IProgressBar bar)
        {
            return FileUtils.RenameFolder(SourcePath, DestinationPath, Log, bar);
        }
    }

    public class CopyFolder : Task
    {
        public string SourcePath;
        public string DestinationPath;
        public bool overwrite;

        public CopyFolder(string SourcePath, string DestinationPath, bool overwrite = true) : base("Copy Folder")
        {
            this.SourcePath = SourcePath;
            this.DestinationPath = DestinationPath;
            this.overwrite = overwrite;
        }

        public override bool CanBeThreaded()
        {
            return true;
        }

        public override bool CanDoMultiTasking()
        {
            return true;
        }

        public override bool RequiresInternetConnection()
        {
            return false;
        }

        protected override bool RunTask(IProgressBar bar)
        {
            return FileUtils.CopyFolder(SourcePath, DestinationPath, Log, overwrite, bar);
        }
    }
}
