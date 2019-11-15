using System.Collections.Generic;

namespace TRS2004Edit
{
    public class TrainzObject
    {
        public readonly string Name;

        public string Path;
        public string Folder;

        public bool Changed = false;

        public List<TrainzObject> Objects;
        public List<TrainzProperty> Properties;

        public TrainzObject(string name) {
            Name = name;

            Properties = new List<TrainzProperty>();
            Objects = new List<TrainzObject>();
        }

        public string this[string name]
        {
            get { return GetValue(name); }
            set { SetValue(name, value); }
        }
        public bool Exists(string name)
        {
            name = name.ToLower();
            foreach (var property in Properties)
            {
                if (property.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public void Set(TrainzProperty property)
        {
            string name = property.Name.ToLower();
            for (int i = 0;i< Properties.Count;i++)
            {
                if (Properties[i].Name == name)
                {
                    Properties[i] = property;
                    return;
                }
            }
            Properties.Add(property);
        }
        public bool SetValue(string name, string value)
        {
            for (int i = 0; i < Properties.Count; i++)
            {
                if (Properties[i].Name.ToLower() == name.ToLower())
                {
                    Properties[i].Value = value;
                    return true;
                }
            }
            return false;
        }
        public void Set(string name, string value, PropertyType type = PropertyType.Number)
        {
            Set(new TrainzProperty(name, value, type));
        }
        public string GetValue(string name)
        {
            return Exists(name) ? Get(name).Value : "";
        }
        public TrainzProperty Get(string name)
        {
            name = name.ToLower();
            foreach (var property in Properties)
            {
                if (property.Name == name)
                    return property;
            }
            return null;
        }
        public void Remove(string name)
        {
            foreach (var property in Properties)
            {
                if (property.Name == name)
                {
                    Properties.Remove(property);
                    return;
                }
            }
        }
    }
}
