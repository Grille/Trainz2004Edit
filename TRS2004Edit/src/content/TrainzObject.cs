using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRS2004Edit
{
    public class TrainzObject
    {
        public readonly string Name;

        public string Path;
        public string Folder;

        List<TrainzObject> objects;
        List<TrainzProperty> properties;

        public TrainzObject(string name) {
            Name = name;

            properties = new List<TrainzProperty>();
            objects = new List<TrainzObject>();
        }

        public string this[int i]
        {
            get { return Path; }
            set { Path = value; }
        }
        public string this[string i]
        {
            get { return Path; }
            set { Path = value; }
        }
        public bool Exists(string name)
        {
            foreach (var property in properties)
            {
                if (property.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public void Add(string name, TrainzObject value)
        {
            objects.Add(value);
        }
        public void Set(string name, string value, PropertyType type)
        {
            foreach (var property in properties)
            {
                if (property.Name == name)
                {
                    property.Value = value;
                    return;
                }
            }
            properties.Add(new TrainzProperty(name, value, type));
        }
        public TrainzProperty Get(string name)
        {
            foreach (var property in properties)
            {
                if (property.Name == name)
                    return property;
            }
            return null;
        }
        public void Remove(string name)
        {
            foreach (var property in properties)
            {
                if (property.Name == name)
                {
                    properties.Remove(property);
                    return;
                }
            }
        }
    }
}
