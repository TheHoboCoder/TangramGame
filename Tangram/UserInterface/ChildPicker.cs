using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.Data;

namespace Tangram.UserInterface
{
    public partial class ChildPicker : Form
    {
        public ChildPicker()
        {
            InitializeComponent();
        }

        private void ChildPicker_Load(object sender, EventArgs e)
        {
            for(int i = 1; i <= Database.subGroupCount; i++)
            {
                subGroup.Items.Add(i + " подруппа");
            }
            subGroup.SelectedIndex = 0;


        }
    }
}
