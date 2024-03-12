namespace TRS2004Edit;

public class TrainzProperty
{
    public string Value;
    public PropertyType Type;
    public TrainzProperty()
    {
    }
    public TrainzProperty(string value, PropertyType type)
    {
        Value = value;
        Type = type;
    }
}
public enum PropertyType
{
    None, Number, KUID, String, 
}
