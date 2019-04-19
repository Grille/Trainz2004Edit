using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TRS2004Edit
{
    //[DesignerCategory("code")]
    public partial class FormSetup : System.Windows.Forms.Form
    {
        string[] options;
        byte[] tuning;
        public FormSetup()
        {
            InitializeComponent();
            load();
            read();

        }
        void load()
        {
            if (File.Exists("tuning.dat"))
            {
                tuning = File.ReadAllBytes("tuning.dat");
                options = File.ReadAllLines("../trainzoptions.txt");
            }
            else if (File.Exists("Settings/tuning.dat"))
            {
                tuning = File.ReadAllBytes("Settings/tuning.dat");
                options = File.ReadAllLines("trainzoptions.txt");
            }
            else
                Application.Exit();
        }
        void save()
        {


            if (File.Exists("tuning.dat"))
            {
                File.WriteAllBytes("tuning.dat", tuning);
                File.WriteAllLines("../trainzoptions.txt", options);
            }
            else if (File.Exists("Settings/tuning.dat"))
            {
                File.WriteAllBytes("Settings/tuning.dat", tuning);
                File.WriteAllLines("trainzoptions.txt", options);
            }
            else
                Application.Exit();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            write();
            save();
            Close();
        }

        void deleteOption(string name)
        {
            for (int i = 0; i < options.Length; i++)
                if (options[i].Split('=')[0] == '-' + name)
                    options[i] = "";
        }
        void setOption(string name,string value)
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (options[i].Length==0||options[i].Split('=')[0] == '-'+name)
                {
                    options[i] = '-' + name;
                    if (value!=null) options[i] += '=' + value;
                    return;
                }
            }
            Array.Resize(ref options, options.Length + 1);
            options[options.Length-1] = '-'+name;
            if (value != null) options[options.Length - 1] += '=' + value;
        }
        void setOption(string name, bool value)
        {
            if (value) setOption(name, null);
            else deleteOption(name);
        }
        string getOption(string name)
        {
            for (int i = 0; i < options.Length; i++)
                if (options[i].Split('=')[0] == '-'+name)
                    return options[i].Split('=')[1];
            return null;
        }
        bool existsOption(string name)
        {
            for (int i = 0; i < options.Length; i++)
                if (options[i].Split('=')[0] == '-' + name)
                    return true;
            return false;
        }

        void read()
        {
            comboBoxRes.SelectedIndex = 0;
            string res = getOption("width") + " x " + getOption("height");
            for (int i = 0;i<comboBoxRes.Items.Count;i++)
                if ((string)comboBoxRes.Items[i] == res)
                    comboBoxRes.SelectedIndex = i;
            checkBoxFullscreen.Checked = existsOption("fullscreen");
            switch (tuning[30])
            {
                case 0x32:
                    comboBoxGround.SelectedIndex = 3;
                    break;
                case 0xB5:
                    comboBoxGround.SelectedIndex = 2;
                    break;
                case 0x77:
                    comboBoxGround.SelectedIndex = 1;
                    break;
                default:
                    comboBoxGround.SelectedIndex = 0;
                    break;
            }
            switch (tuning[34])
            {
                case 0x19:
                    comboBoxScenery.SelectedIndex = 3;
                    break;
                case 0x9C:
                    comboBoxScenery.SelectedIndex = 2;
                    break;
                case 0x5E:
                    comboBoxScenery.SelectedIndex = 1;
                    break;
                default:
                    comboBoxScenery.SelectedIndex = 0;
                    break;
            }
        }
        void write()
        {
            string width = ((string)comboBoxRes.SelectedItem).Split('x')[0].Trim();
            string height = ((string)comboBoxRes.SelectedItem).Split('x')[1].Trim();
            setOption("width", width);
            setOption("height", height);
            setOption("fullscreen", checkBoxFullscreen.Checked);

            switch (comboBoxGround.SelectedIndex)
            {
                case 3:
                    tuning[29] = 0x80; tuning[30] = 0x32; tuning[31] = 0x46;
                    break;
                case 2:
                    tuning[29] = 0x80; tuning[30] = 0xB5; tuning[31] = 0x45;
                    break;
                case 1:
                    tuning[29] = 0x00; tuning[30] = 0x77; tuning[31] = 0x45;
                    break;
                default:
                    tuning[29] = 0x80; tuning[30] = 0xBB; tuning[31] = 0x44;
                    break;
            }
            switch (comboBoxScenery.SelectedIndex)
            {
                case 3:
                    tuning[33] = 0x80; tuning[34] = 0x19; tuning[35] = 0x46;
                    break;
                case 2:
                    tuning[33] = 0x80; tuning[34] = 0x9C; tuning[35] = 0x45;
                    break;
                case 1:
                    tuning[33] = 0x00; tuning[34] = 0x5E; tuning[35] = 0x45;
                    break;
                default:
                    tuning[33] = 0x80; tuning[34] = 0xA2; tuning[35] = 0x44;
                    break;
            }
        }

    }
}
