using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace TRS2004Edit;

public partial class FormMain : Form
{
    OptionsFile options;
    string gamePath;
    public FormMain()
    {
        Icon = Properties.Resources.Icon;
        InitializeComponent();
        if (File.Exists("trainzoptions.txt"))
        {
            options = new OptionsFile("trainzoptions.txt");

            if (options.Exists("goto"))
            {
                gamePath = options.Get("goto");
                Console.WriteLine(gamePath);
                string filepath = Path.GetFullPath(Path.Combine(gamePath, "trainzoptions.txt"));
                if (File.Exists(filepath))
                {
                    options.Load(filepath);
                }
                else
                {
                    MessageBox.Show(filepath + " not found!");
                }
            }
            else
            {
                gamePath = "";
            }
        }
        else
        {
            MessageBox.Show("trainzoptions.txt not found!");
        }
        
    }

    private void buttonClose_Click(object sender, EventArgs e) =>
        Application.Exit();

    private void buttonSetting_Click(object sender, EventArgs e) =>
        new FormSetup(gamePath).ShowDialog(this);

    private void buttonContent_Click(object sender, EventArgs e)
    {       
        new FormContent(gamePath).Show(this);
        Hide();
    }
    private void buttonPlay_Click(object sender, EventArgs e)
    {
        Process pProcess = new Process();
        pProcess.StartInfo.FileName = Path.GetFullPath(Path.Combine(gamePath, "Bin/Trainz.exe"));
        pProcess.StartInfo.WorkingDirectory = gamePath;
        //pProcess.StartInfo.Arguments = "-1920 -ColorBits=16 -GlobalTextureResolution=0 -Render=DirectX -ResourceMemory=4096";
        pProcess.Start();
        Application.Exit();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {

    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == WM_NCHITTEST)
            m.Result = (IntPtr)(HT_CAPTION);
    }

    private const int WM_NCHITTEST = 0x84;
    private const int HT_CLIENT = 0x1;
    private const int HT_CAPTION = 0x2;

    private void trainzButton5_Click(object sender, EventArgs e)
    {
        Process pProcess = new Process();
        pProcess.StartInfo.FileName = Path.GetFullPath(Path.Combine(gamePath, "TRS2004.exe"));
        pProcess.StartInfo.WorkingDirectory = gamePath;
        pProcess.Start();
        Application.Exit();
    }

}
