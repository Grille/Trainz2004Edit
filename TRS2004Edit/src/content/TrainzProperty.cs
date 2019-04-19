using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRS2004Edit
{
    public class TrainzProperty
    {
        List<TrainzProperty> properties;
        public string Name;
        public string Value;
        public TrainzProperty()
        {
        }
        public TrainzProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public void Set(string name,string value)
        {
            foreach (var property in properties)
            {
                if (property.Name == name)
                {
                    property.Value = value;
                    return;
                }
            }
            properties.Add(new TrainzProperty(name, value));
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
