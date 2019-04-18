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
    public partial class FormContent : Form
    {
        public FormContent()
        {
            InitializeComponent();
            treeView1.BeginUpdate();


            treeView1.Nodes.Add("maps","maps");
            treeView1.Nodes.Add("traincar", "traincar");
            treeView1.Nodes["maps"].Nodes.Add("ahndo");

            /*
            treeView1.Nodes.Add("Parent");
            treeView1.Nodes["Maps"].Nodes.Add("Child 1");
            treeView1.Nodes[0].Nodes.Add("Child 2");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            */
            treeView1.EndUpdate();
        }
    }
}
