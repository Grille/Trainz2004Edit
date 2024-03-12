using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRS2004Edit;

internal static class GameFinder
{
    public static bool TryLocateGameFiles(Form owner, string inpath, out string path)
    {
        const string title = "File not found.";
        const string message = "Could not find Trainz files. Please place the executable in your Trainz root directory.\nAlternatively, you can manually locate your Trainz directory.\n\n";

        try
        {
            path = Validate(inpath);
            return true;
        }
        catch (Exception ex)
        {
            var result = MessageBox.Show(owner, $"{message}{ex.Message}", title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            if (result == DialogResult.OK)
            {
                using var dialog = new OpenFileDialog();
                var fileresult = dialog.ShowDialog();
                if (fileresult == DialogResult.OK)
                {
                    return TryLocateGameFiles(owner, Path.GetDirectoryName(dialog.FileName), out path);
                }

            }

            path = null;
            return false;
        }
    }


    public static string Validate(string inpath)
    {
        var path = ValidateTrainzoptions(inpath);
        var tuningpath = Path.Combine(path, "settings\\tuning.dat");


        if (!File.Exists(tuningpath))
        {
            throw new IOException($"Pleas note that this program is only designed for Trainz 2004, 2006 and 2007.\n\n{tuningpath} not found.");
        }

        return path;
    }
    public static string ValidateTrainzoptions(string inpath)
    {
        var optionspath = Path.Combine(inpath, "trainzoptions.txt");

        if (File.Exists(optionspath))
        {
            var options = new OptionsFile(optionspath);

            if (options.Exists("goto"))
            {
                var link = options.Get("goto");
                string filepath = Path.GetFullPath(Path.Combine(link, "trainzoptions.txt"));
                if (File.Exists(filepath))
                {
                    return Path.GetDirectoryName(filepath);
                }
                else
                {
                    throw new IOException($"{link} not found.");
                }
            }
            return Path.GetDirectoryName(optionspath);
        }
        else
        {
            throw new IOException($"{optionspath} not found.");
        }
    }
}
