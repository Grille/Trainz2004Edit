using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRS2004Edit
{
    public class TrainzProperty
    {
        public readonly string Name;
        public string Value;
        public PropertyType Type;
        public TrainzProperty()
        {
        }
        public TrainzProperty(string name, string value, PropertyType type)
        {
            Name = name;
            Value = value;
            Type = type;
        }
    }
    public enum PropertyType
    {
        Number, KUID, String
    }
}
