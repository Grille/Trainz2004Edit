using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;

namespace TRS2004Edit
{
    public partial class FormContent : Form
    {
        ContentManager content;
        string gamePath;
        public FormContent(string gamePath)
        {
            InitializeComponent();

            this.gamePath = gamePath;

            dataGridView.Rows.Clear();
            content = new ContentManager();
            content.Load(Path.Combine(gamePath,"World/Custom"));
            Text = "TRS2004 Content Manager " + gamePath;
            buttonSubmit_Click(null, null);
        }
        private string getValue(TrainzObject obj,string name)
        {
            if (obj.Exists(name))
                return obj.Get(name).Value;
            else
                return "";
        }

        private void trainzButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            Parser.ParseQuery(textBox1.Text, out List<string> names, out List<QueryCondition> conditions);

            dataGridView.ColumnCount = names.Count + 1;

            dataGridView.Columns[0].Name = "<path>";
            dataGridView.Columns[0].Visible = false;

            for (int i = 0;i< names.Count; i++)
            {
                dataGridView.Columns[i + 1].Name = names[i];
            }

            foreach (var obj in content.Objects)
            {
                var values = new string[names.Count + 1];
                values[0] = obj.Path;
                for (int i = 0; i < names.Count; i++)
                {
                    var name = names[i];
                    values[i + 1] = obj[name];
                }
                bool visible = true;
                foreach (var condition in conditions)
                {
                    visible &= values[condition.Index + 1] == condition.Value;
                    Console.WriteLine(values[condition.Index]);
                    Console.WriteLine(condition.Value);
                }
                if (visible)
                {
                    dataGridView.Rows.Add(values);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var order = (int)dataGridView.SortOrder;
            var column = dataGridView.SortedColumn;
            content.Load(Path.Combine(gamePath, "World/Custom"));
            buttonSubmit_Click(null, null);
            if (order != 0)
                dataGridView.Sort(column, (ListSortDirection)(order - 1));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            content.Save();
        }

        private void FormContent_ResizeBegin(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].Visible = false;
            }
        }
        private void FormContent_ResizeEnd(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].Visible = true;
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            string path = Path.GetFullPath((string)dataGridView.SelectedRows[0].Cells[0].Value);
            Process.Start("explorer.exe", path);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string path = Path.GetFullPath((string)dataGridView.SelectedRows[0].Cells[0].Value);
            Process.Start(path + "/config.txt");
        }

        private void FormContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void dataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string path = Path.GetFullPath((string)dataGridView.SelectedRows[0].Cells[0].Value);
            Process.Start("explorer.exe", path);
        }
    }
}
