using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangram.UserInterface
{
    public partial class FigureViewer : Form
    {
        public FigureViewer()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void AddFigure_Click(object sender, EventArgs e)
        {
            TestForm3 form3 = new TestForm3();
            form3.Show();
        }
    }
}
