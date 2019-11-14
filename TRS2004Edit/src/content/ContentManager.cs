using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TRS2004Edit
{
    public class ContentManager
    {
        public Parser Parser;
        public List<TrainzObject> Objects;

        public ContentManager()
        {
            Parser = new Parser();
            string[] directories = Directory.GetDirectories("./World/Custom");
            List<string> paths = new List<string>();

            foreach (var directory in directories)
            {
                paths.AddRange(Directory.GetDirectories(directory));
            }
            Objects = new List<TrainzObject>(paths.Count);
            foreach (var path in paths)
            {
                try
                {
                    string text = File.ReadAllText(path + "/config.txt");
                    Console.WriteLine(path);
                    var obj = Parser.Parse(text);
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
