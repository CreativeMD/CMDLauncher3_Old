using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CMDLauncher
{
    public class Logger
    {

        private readonly string name;
        private List<string> content;
        public List<IList<string>> listeners;
        public bool logToConsole;

        public Logger(string name, bool logToConsole)
        {
            this.name = name;
            this.logToConsole = logToConsole;
            this.content = new List<string>();
            this.listeners = new List<IList<string>>();
        }

        public Logger(string name, bool logConsole, List<string> listener) : this(name, logConsole)
        {
            this.listeners.Add(listener);
        }

        private string Format(string text, params object[] args)
        {
            return "[" + name + "] " + String.Format(text, args);
        }

        public void Log(string text, params object[] args)
        {
            text = Format(text, args);
            content.Add(text);
            foreach (var listener in listeners)
                listener.Add(text);
            if (logToConsole)
                Console.WriteLine(text);
        }

        public void LogLastLine(string text, params object[] args)
        {
            if(content.Count == 0)
            {
                Log(text, args);
                return;
            }
            text = Format(text, args);
            content[content.Count - 1] = text;
            foreach (var listener in listeners)
            {
                if (listener.Count == 0)
                    listener.Add(text);
                else
                    listener[listener.Count-1] = text;
            }

            if (logToConsole)
            {
                Console.Write("\r" + text + "             ");
            }
        }

        public string GetLastLine()
        {
            return content.Count > 0 ? content.Last<string>() : "";
        }
    }
}
