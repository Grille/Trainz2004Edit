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
            dataGridView.Rows.Clear();

            dataGridView.ColumnCount = 3;
            dataGridView.Columns[0].Name = "name";
            dataGridView.Columns[1].Name = "username";
            dataGridView.Columns[2].Name = "kind";

            foreach (var obj in content.Objects)
            {
                var name = getValue(obj, "name");
                var uname = getValue(obj, "username");
                var kind = getValue(obj, "kind");
                dataGridView.Rows.Add(name, uname, kind);
            }
        }
    }
}
