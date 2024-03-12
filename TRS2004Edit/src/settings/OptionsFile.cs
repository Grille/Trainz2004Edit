using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TRS2004Edit;

class OptionsFile : Dictionary<string, string>
{
    string path;

    public OptionsFile(string path)
    {
        Load(path);
    }

    public void Load(string path)
    {
        this.path = path;

        var code = File.ReadAllText(path);
        Parse(code);
    }

    public void Save(string path = null)
    {
        if (path == null)
            path = this.path;

        var code = Serialize();
        File.WriteAllText(path, code);
    }

    public void Parse(string code)
    {
        var lines = code.Split('\n');

        foreach (var line in lines)
        {
            var tline = line.Trim();
            if (tline.Length > 0 && tline[0] == '-')
            {
                var split = tline.Split(new[] { '=' }, 2);
                var key = split[0].Substring(1, split[0].Length - 1);
                if (split.Length == 2)
                {
                    this[key] = split[1];
                }
                else
                {
                    this[key] = null;
                }
            }
        }
    }

    public string Serialize()
    {
        var sb = new StringBuilder();

        foreach (var pair in this)
        {
            if (string.IsNullOrEmpty(pair.Value))
            {
                sb.AppendLine($"-{pair.Key}");
            }
            else
            {
                sb.AppendLine($"-{pair.Key}={pair.Value}");
            }
        }

        return sb.ToString();
    }

    public void Set(string name, string value)
    {
        this[name] = value;
    }

    public void Set(string name, bool value)
    {
        if (value) Set(name, null);
        else Remove(name);
    }

    public string Get(string name)
    {
        return this[name];
    }

    public string Get(string name, string defaultValue)
    {
        if (TryGetValue(name, out var value)) return value;
        else return defaultValue;
    }

    public bool Exists(string name)
    {
        return ContainsKey(name);
    }
}
