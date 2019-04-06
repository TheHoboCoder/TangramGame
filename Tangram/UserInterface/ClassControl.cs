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
    public partial class ClassControl : Form
    {
        public ClassControl()
        {
            InitializeComponent();
        }

        private void ClassControl_Load(object sender, EventArgs e)
        {
            difficultyCombo.SelectedIndex = 0;

            childCombo.DataSource = Database.Teacher_Workspace.childrenInGroup;
            childCombo.DisplayMember = "FullName";
            childCombo.ValueMember = "Id";
            childCombo.SelectedIndex = 0;
        }

        private void endClass_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            this.Close();
        }
    }
}
