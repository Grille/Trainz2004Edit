using System.Collections.Generic;

namespace TRS2004Edit
{
    public class TrainzObject
    {
        public string Path;
        public string Folder;

        public bool Changed = false;

        public SortedList<string, TrainzObject> Objects;
        public SortedList<string, TrainzProperty> Properties;

        public TrainzObject() {
            Properties = new SortedList<string, TrainzProperty>();
            Objects = new SortedList<string, TrainzObject>();
        }

        public TrainzObject this[string name]
        {
            get { return Objects[name]; }
        }

    }
}
