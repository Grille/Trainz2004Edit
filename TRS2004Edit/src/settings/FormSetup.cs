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

namespace TRS2004Edit;

//[DesignerCategory("code")]
public partial class FormSetup : System.Windows.Forms.Form
{
    OptionsFile options;
    TuningFile tuning;
    string gamePath;
    public FormSetup(string gamePath)
    {
        setup();
        this.gamePath = gamePath;


        Text = $"{Text} {gamePath}";

        load();
        read();
    }

    public FormSetup()
    {
        if (!GameFinder.TryLocateGameFiles(this, Path.GetFullPath("./"), out gamePath))
        {
            void handler (object sender, EventArgs e) => Close();
            Load += handler;
            return;
        }

        setup();
        Text = $"{Text} {gamePath}";

        load();
        read();
    }

    private void FormSetup_Load1(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    void setup()
    {
        Icon = Properties.Resources.Icon;
        InitializeComponent();

        comboBoxRes.Items.Add("640 x 480");
        comboBoxRes.Items.Add("800 x 600");
        comboBoxRes.Items.Add("1280 x 720");
        comboBoxRes.Items.Add("1920 x 1080");
        comboBoxRes.Items.Add("2560 x 1440");
    }

    void load()
    {
        if (File.Exists(Path.Combine(gamePath,"Settings/tuning.dat")))
        {
            tuning = new TuningFile(Path.Combine(gamePath, "Settings/tuning.dat"));
            options = new OptionsFile(Path.Combine(gamePath, "trainzoptions.txt"));
        }
        else
            Application.Exit();
    }
    void save()
    {
        if (File.Exists(Path.Combine(gamePath, "Settings/tuning.dat")))
        {
            tuning.Save();
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
        string width = options.Get("width", "800");
        string height = options.Get("height", "600");
        string res = $"{width} x {height}";

        comboBoxRes.Text = res;

        checkBoxFullscreen.Checked = options.Exists("fullscreen");

        numericGround.Value = (decimal)(tuning.DrawDistanceGround / 1000f);
        numericScenery.Value = (decimal)(tuning.DrawDistanceScenery / 1000f);

        var fog = (decimal)tuning.FogGoodWeather;
        numericUpDownFogGood.Value = fog == 0 ? 100 : 1 / fog;
        numericUpDownFogBad.Value = (decimal)tuning.FogBadWeather + 1;

        numericParticles.Value = (decimal)tuning.Particles;
    }
    void write()
    {
        var res = comboBoxRes.Text.Split('x');
        string width = res[0].Trim();
        string height = res[1].Trim();
        options.Set("width", width);
        options.Set("height", height);
        options.Set("fullscreen", checkBoxFullscreen.Checked);

        float drawGround = (float)(numericGround.Value * 1000);
        float drawScenery = (float)(numericScenery.Value * 1000);

        var MaxDistance = (int)Math.Max(drawGround, drawScenery);

        options.Set("zfar", MaxDistance.ToString());

        tuning.DrawDistanceGround = drawGround;
        tuning.DrawDistanceScenery = drawScenery;

        tuning.FogGoodWeather = 1 / (float)numericUpDownFogGood.Value;
        tuning.FogBadWeather = (float)numericUpDownFogBad.Value - 1;

        tuning.Particles = (float)numericParticles.Value;
    }

    private void FormSetup_Load(object sender, EventArgs e)
    {

    }

    private void checkBoxFullscreen_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void buttonLoad_Click(object sender, EventArgs e)
    {
        load();
        read();
    }
}
