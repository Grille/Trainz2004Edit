using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRS2004Edit
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            new FormSetup().Show(this);
        }

        private void buttonContent_Click(object sender, EventArgs e)
        {
            new FormContent().Show(this);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = @"TRS2004.exe";
            pProcess.Start();
            Application.Exit();
        }
    }
}
