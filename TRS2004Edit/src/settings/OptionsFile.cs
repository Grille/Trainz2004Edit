using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TRS2004Edit
{
    class OptionsFile
    {
        List<string> lines;
        string path;
        public OptionsFile(string path)
        {
            Load(path);
        }

        public void Load(string path)
        {
            this.path = path;
            lines = new List<string>(File.ReadAllLines(path));
        }

        public void Save(string path = null)
        {
            if (path == null)
                path = this.path;

            File.WriteAllLines(path, lines);
        }

        public void Remove(string name)
        {
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].Split('=')[0] == '-' + name)
                    lines[i] = "";
        }
        public void Set(string name, string value)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Split('=')[0] == '-' + name)
                {
                    lines[i] = '-' + name;
                    if (value != null) lines[i] += '=' + value;
                    return;
                }
            }
            var newLine = '-' + name;
            if (value != null) newLine += '=' + value;
            lines.Add(newLine);
        }
        public void Set(string name, bool value)
        {
            if (value) Set(name, null);
            else Remove(name);
        }
        public string Get(string name)
        {
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].Split('=')[0] == '-' + name)
                    return lines[i].Split('=')[1];
            return null;
        }
        public bool Exists(string name)
        {
            for (int i = 0; i < lines.Count; i++)
                if (lines[i].Split('=')[0] == '-' + name)
                    return true;
            return false;
        }
    }
}
