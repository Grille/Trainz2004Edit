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

            //dataGridView.Rows.Clear();
            content = new ContentManager();
            foreach (var obj in content.Objects)
            {
                //treeView1.Nodes.Add(obj.Path, obj.Path);
                //dataGridView.Rows.Add(obj.Name, "ghfdj", "xf");
            }
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

        private void trainzButtonClose_Click(object sender, EventArgs e) => 
            Close();
    }
}
