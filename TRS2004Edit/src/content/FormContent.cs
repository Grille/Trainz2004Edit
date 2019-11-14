using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
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

            /*
            foreach (var obj in content.Objects)
            {
                var name = getValue(obj, "name");
                var uname = getValue(obj, "username");
                var kind = getValue(obj, "kind");
                dataGridView.Rows.Add(name,uname, kind);
            }
            */

            //dataGridView1.BeginEdit(true);
            //dataGridView1.EndEdit();
            // dataGridView1.Rows.Add()
            /*
                 dataGridView1.Refresh();


             treeView1.Nodes.Add("maps", "maps");
             treeView1.Nodes.Add("traincar", "traincar");
             treeView1.Nodes["maps"].Nodes.Add("ahndo");

             /*
             treeView1.Nodes.Add("Parent");
             treeView1.Nodes["Maps"].Nodes.Add("Child 1");
             treeView1.Nodes[0].Nodes.Add("Child 2");
             treeView1.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
             treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");

             treeView1.EndUpdate();
             */
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
