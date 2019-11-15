using System;
using System.Runtime.InteropServices;
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
        public FormContent()
        {
            InitializeComponent();

            dataGridView.Rows.Clear();
            content = new ContentManager();
            content.Load();
            buttonSubmit_Click(null, null);
        }
        private string getValue(TrainzObject obj,string name)
        {
            if (obj.Exists(name))
                return obj.Get(name).Value;
            else
                return "";
        }

        private void trainzButtonClose_Click(object sender, EventArgs e) => 
            Close();

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();

            var args = textBox1.Text.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            dataGridView.ColumnCount = args.Length + 1;

            dataGridView.Columns[0].Name = "<path>";
            dataGridView.Columns[0].Visible = false;

            for (int i = 0;i< args.Length; i++)
            {
                args[i] = args[i].ToLower().Trim(' ', ',', '\n', '\r', '\t');
                dataGridView.Columns[i + 1].Name = args[i];
            }

            foreach (var obj in content.Objects)
            {
                var values = new string[args.Length + 1];
                values[0] = obj.Path;
                for (int i = 0; i < args.Length; i++)
                    values[i + 1] = obj[args[i]];

                dataGridView.Rows.Add(values);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var order = (int)dataGridView.SortOrder;
            var column = dataGridView.SortedColumn;
            content.Load();
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
    }
}
