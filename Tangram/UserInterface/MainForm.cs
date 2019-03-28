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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            userName.Text = Database.currentUser.Name + " " + Database.currentUser.Otch;
        }

        private void userProfile_Click(object sender, EventArgs e)
        {
            UserEdit users = new UserEdit();
            users.ShowDialog();
            userName.Text = Database.currentUser.Name + " " + Database.currentUser.Otch;
        }

        private void StartGameBtn_Click(object sender, EventArgs e)
        {
            ChildPicker picker = new ChildPicker();
            picker.ShowDialog();
        }
    }
}
