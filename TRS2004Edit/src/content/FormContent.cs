using System;
using System.Windows.Forms;

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
                return ((char)834) + " undefined " + ((char)834);
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
            var text = textBox1.Text;

            dataGridView.Rows.Clear();

            dataGridView.ColumnCount = 4;
            dataGridView.Columns[0].Name = "<path>";
            dataGridView.Columns[1].Name = "kuid";
            dataGridView.Columns[2].Name = "name";
            dataGridView.Columns[3].Name = "username";

            foreach (var obj in content.Objects)
            {
                var path = obj.Path;
                var name = getValue(obj, "name");
                var uname = getValue(obj, "username");
                var kind = getValue(obj, "kuid");
                dataGridView.Rows.Add(path, kind, name, uname);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            content.Load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            content.Save();
        }
    }
}
