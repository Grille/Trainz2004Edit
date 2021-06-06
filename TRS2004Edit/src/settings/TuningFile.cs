using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TRS2004Edit
{
    class TuningFile
    {
        BinaryView view;
        string path;
        SortedList<string, float> values;
        
        public TuningFile(string path)
        {
            values = new SortedList<string, float>();
            Load(path);
        }
        public void Load(string path)
        {
            this.path = path;

            view = new BinaryView(File.ReadAllBytes(path));

            values["ground"] = view.Read<half>(30) / 1000;
            values["scenery"] = view.Read<half>(34) / 1000;
        }

        public void Save(string path = null)
        {
            if (path == null)
                path = this.path;

            view.Write<half>(30, (half)values["ground"]);
            view.Write<half>(34, (half)values["scenery"]);

            File.WriteAllBytes(path, view.Bytes);
        }

        public void Set(string key, float value)
        {
            values[key] = value;
        }

        public float Get(string key)
        {
            return values[key];
        }
    }
}
