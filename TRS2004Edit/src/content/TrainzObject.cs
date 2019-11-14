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

        public string this[int i]
        {
            get { return Path; }
            set { Path = value; }
        }
        public TrainzProperty this[string name]
        {
            get { return Get(name); }
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
        public void Add(TrainzObject value)
        {
            Objects.Add(value);
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
        public void Set(string name, string value, PropertyType type)
        {
            name = name.ToLower();
            foreach (var property in Properties)
            {
                if (property.Name == name)
                {
                    property.Value = value;
                    return;
                }
            }
            Properties.Add(new TrainzProperty(name, value, type));
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
