using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TRS2004Edit
{
    public class ContentManager
    {
        public List<TrainzObject> Objects;

        public ContentManager()
        {
            Objects = new List<TrainzObject>();
        }

        public void Load()
        {
            Objects.Clear();

            string[] directories = Directory.GetDirectories("./World/Custom");
            List<string> paths = new List<string>();

            foreach (var directory in directories)
            {
                paths.AddRange(Directory.GetDirectories(directory));
            }
            foreach (var path in paths)
            {
                try
                {
                    string text = File.ReadAllText(path + "/config.txt", Encoding.UTF8);
                    Console.WriteLine(path);
                    var obj = Parser.ParseConfig(text);
                    obj.Path = path;
                    Objects.Add(obj);
                    Console.WriteLine("________________");
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR -> " + e.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            }
        }
        public void Save()
        {
            foreach (var obj in Objects)
            {
                if (obj.Changed == true)
                {
                    string config = Packer.Pack(obj);
                    File.WriteAllText(obj.Path + "/config.txt", config, Encoding.UTF8);
                }
            }
        }

        public TrainzObject SearchKUID(string kuid)
        {
            foreach (var property in Objects)
            {
                if (property.Get("kuid").Value == kuid)
                    return property;
            }
            return null;
        }
        public TrainzObject SearchName(string name)
        {
            foreach (var property in Objects)
            {
                if (property.Get("name").Value == name)
                    return property;
            }
            foreach (var property in Objects)
            {
                if (property.Get("username").Value == name)
                    return property;
            }
            return null;
        }

    }
}
