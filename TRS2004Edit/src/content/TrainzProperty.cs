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
