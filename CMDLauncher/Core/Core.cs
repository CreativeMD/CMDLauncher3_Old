using CefSharp;
using CMDLauncher.Old;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMDLauncher
{
    public class Core
    {
        public static Logger MainLog;
        public static string ProgramVersion;
        public static string ProgramName = "CMDLauncher";

        public static bool Terminated = false;
        public static bool CloseLauncher = false;

        public static string ProgramFolder;
        public static string AssetsFolder;
        public static string TempFolder;
        public static string HTMLFolder;
        public static string InstanceFolder;
        public static string LibFolder;
        public static string DownloadFolder;
        public static string MinecraftFolder;

        public static void InitCore()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            ProgramVersion = assembly.GetName().Version.ToString();
            ProgramFolder = Path.GetDirectoryName(assembly.Location) + Path.DirectorySeparatorChar;

            AssetsFolder = ProgramFolder + "assets" + Path.DirectorySeparatorChar;
            InstanceFolder = ProgramFolder + "instances" + Path.DirectorySeparatorChar;
            Directory.CreateDirectory(InstanceFolder);
            LibFolder = ProgramFolder + "lib" + Path.DirectorySeparatorChar;
            DownloadFolder = ProgramFolder + "download" + Path.DirectorySeparatorChar;
            TempFolder = DownloadFolder + "temp" + Path.DirectorySeparatorChar;
            HTMLFolder = ProgramFolder + "html" + Path.DirectorySeparatorChar;
            MinecraftFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + ".minecraft" + Path.DirectorySeparatorChar;

            MainLog = new Logger("main", true);

            MainLog.Log("Launching CMDLauncher v" + ProgramVersion + " ...");

            string[] tempArgs = Environment.GetCommandLineArgs();
            string[] args = new string[tempArgs.Length - 1];
            for(int i = 1; i < tempArgs.Length; i++)
                args[i - 1] = tempArgs[i];

            LauncherConfiguration configuration;

            if (File.Exists(ProgramFolder + "CMDLauncher.cfg"))
            {
                MainLog.Log("Detected old CMDLauncher configuration file. Attempting to convert it ...");
                TSaveFile oldSettings = new TSaveFile(ProgramFolder + "CMDLauncher.cfg");

                configuration = new LauncherConfiguration();
                configuration.protocolEnabled = oldSettings.getBoolean("protocol-enabled");
            }
            else
                configuration = DeserializeFile<LauncherConfiguration>(ProgramFolder + "CMDLauncher.json");
            
            configuration.version = ProgramVersion;
            SerializeFile(ProgramFolder + "CMDLauncher.json", configuration);
            
            if (args.Length > 0)
                MainLog.Log("Launching CMDLauncher with following args " + String.Join(",", args));

            Application.ApplicationExit += ApplicationExit;
            
        }

        public static void PostInit()
        {
            Cef.Initialize();
        }

        public static void ApplicationExit(object sender, EventArgs e)
        {
            Terminated = true;
        }


        public static void SerializeFile(string path, object value)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(value, Formatting.Indented));
        }

        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static T DeserializeFile<T>(string path)
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "{ }");
            return Deserialize<T>(File.ReadAllText(path));
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void Populate(string json, object value)
        {
            JsonConvert.PopulateObject(json, value);
        }

    }
}
