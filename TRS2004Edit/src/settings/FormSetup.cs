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
        OptionsFile options;
        BinaryView tuning;
        string gamePath;
        public FormSetup(string gamePath)
        {
            InitializeComponent();
            this.gamePath = gamePath;

            comboBoxRes.Items.Add("640 x 480");
            comboBoxRes.Items.Add("800 x 600");
            comboBoxRes.Items.Add("1280 x 720");
            comboBoxRes.Items.Add("1920 x 1080");

            Text = "TRS2004 Settings " + gamePath;

            load();
            read();
        }
        void load()
        {
            if (File.Exists(Path.Combine(gamePath,"Settings/tuning.dat")))
            {
                tuning = new BinaryView(File.ReadAllBytes(Path.Combine(gamePath, "Settings/tuning.dat")));
                options = new OptionsFile(Path.Combine(gamePath, "trainzoptions.txt"));
            }
            else
                Application.Exit();
        }
        void save()
        {
            if (File.Exists(Path.Combine(gamePath, "Settings/tuning.dat")))
            {
                File.WriteAllBytes(Path.Combine(gamePath, "Settings/tuning.dat"), tuning.Bytes);
                options.Save();
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


        void read()
        {
            comboBoxRes.SelectedIndex = 0;
            string res = options.Get("width") + " x " + options.Get("height");
            for (int i = 0; i < comboBoxRes.Items.Count; i++)
                if ((string)comboBoxRes.Items[i] == res)
                    comboBoxRes.SelectedIndex = i;
            checkBoxFullscreen.Checked = options.Exists("fullscreen");

            numericGround.Value = (decimal)(float)tuning.Read<half>(30)/1000;
            numericScenery.Value = (decimal)(float)tuning.Read<half>(34)/1000;

        }
        void write()
        {
            
            string width = ((string)comboBoxRes.SelectedItem).Split('x')[0].Trim();
            string height = ((string)comboBoxRes.SelectedItem).Split('x')[1].Trim();
            options.Set("width", width);
            options.Set("height", height);
            options.Set("fullscreen", checkBoxFullscreen.Checked);

            float drawGround = (float)(numericGround.Value * 1000);
            float drawScenery = (float)(numericScenery.Value * 1000);

            options.Set("zfar", ((int)Math.Max(drawGround, drawScenery)).ToString());

            tuning.Write<half>(30, (half)drawGround);
            tuning.Write<half>(34, (half)drawScenery);
        }

        private void FormSetup_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxFullscreen_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
