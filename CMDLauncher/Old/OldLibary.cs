using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDLauncher.Old
{

    public class TStringList : List<string>
    {

        public TStringList(IEnumerable<string> collection) : base(collection)
        {

        }

        public TStringList() : base()
        {
            
        }

        public void LoadFromFile(string path)
        {
            this.Clear();
            this.AddRange(File.ReadAllLines(path));
        }

        public void SaveToFile(string path)
        {
            if (!File.Exists(path))
                File.Create(path).Close();
            File.WriteAllLines(path, this.ToArray());
        }

    }

    public class TSaveFile
    {
        const string SplitReplacement = "&Split";

        public string filename;
        public string splitter;

        public TSaveFile(string filename, string splitter)
        {
            this.filename = filename;
            this.splitter = splitter;
        }

        public TSaveFile(string filename) : this(filename, "=") { }

        public TStringList getFile()
        {
            TStringList list = new TStringList();
            if (!File.Exists(filename))
            {
                Directory.CreateDirectory(Path.GetFullPath(filename));
                list.SaveToFile(filename);
            }else
                list.LoadFromFile(this.filename);
            return list;
        }

        public bool hasKey(string key)
        {
            TStringList list = getFile();
            foreach(var line in list)
            {
                string[] parts = line.Split(new string[] { splitter }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 && key == parts[0])
                    return true;
            }
            return false;
        }
        
        public string getString(string key)
        {
            TStringList list = getFile();
            foreach (var line in list)
            {
                string[] parts = line.Split(new string[] { splitter }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 && key == parts[0])
                    return parts[1];
            }
            return null;
        }

        public int getInteger(string key)
        {
            string value = getString(key);
            if(value != null)
            {
                int result;
                if (int.TryParse(value, out result))
                    return result;
            }
            return 0;
        }

        public bool getBoolean(string key)
        {
            return getString(key) == "true";
        }

        public TStringList getList(string key)
        {
            var value = getString(key);
            if(value != null)
                return new TStringList(value.Split(';'));
            return new TStringList();
        }

        public void setString(string key, string value)
        {
            TStringList list = getFile();
            for(int i = 0; i < list.Count; i++)
            {
                string[] parts = list[i].Split(new string[] { splitter }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 && key == parts[0])
                {
                    list[i] = key + splitter + value.Replace(splitter, SplitReplacement);
                    list.SaveToFile(filename);
                    return;
                }
            }
        }

        public void setInteger(string key, int value)
        {
            setString(key, value.ToString());
        }

        public void setBoolean(string key, bool value)
        {
            setString(key, value ? "true" : "false");
        }

        public void setList(string key, TStringList value)
        {
            setString(key, String.Join(";", value.ToArray()));
        }

    }
}
