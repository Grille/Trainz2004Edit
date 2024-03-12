using System.Collections.Generic;

namespace TRS2004Edit;

public class TrainzObject
{
    public string Path;
    public string Folder;

    public bool Changed = false;

    public Dictionary<string, TrainzObject> Objects;
    public Dictionary<string, TrainzProperty> Properties;

    public TrainzObject() {
        Properties = new Dictionary<string, TrainzProperty>();
        Objects = new Dictionary<string, TrainzObject>();
    }

    public TrainzObject this[string name]
    {
        get { return Objects[name]; }
    }

}
