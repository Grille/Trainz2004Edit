using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRS2004Edit
{
    public static class Packer
    {
        static public string Pack(TrainzObject obj)
        {
            var sb = new StringBuilder();
            foreach (var value in obj.Properties)
            {
                if (value.Type == PropertyType.String)
                    sb.Append(value.Name + " \"" + value.Value + "\"\n");
                else
                    sb.Append(value.Name + " " + value.Value + "\n");
            }
            foreach (var value in obj.Objects)
            {
                sb.Append(value.Name + " {\n");
                sb.Append(Pack(value));
                sb.Append("}\n");
            }
            return sb.ToString();
        }
    }
}
