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
using Tangram.GraphicsElements;

namespace Tangram.UserInterface
{
    public partial class MainForm : Form
    {
        bool userClose = false;

        private static float BRIGHTNESS_SHIFT = 0.09F;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateName();
        }

        private void UpdateName()
        {
            userName.Text = Database.userRepository.currentUser.Name + " " + Database.userRepository.currentUser.Otch;
        }

        private void userProfile_Click(object sender, EventArgs e)
        {
            UserEdit users = new UserEdit();
            users.ShowDialog();
            UpdateName();
        }

        private void StartGameBtn_Click(object sender, EventArgs e)
        {
            ChildPicker picker = new ChildPicker();
            DialogResult res  = picker.ShowDialog();
            if(res == DialogResult.OK)
            {
                userClose = true;
                this.Close();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!userClose)
            {
                Application.Exit();
            }
           
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm(true);
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                userClose = true;
                this.Close();
            }
        }

        private void FiguresBtn_Click(object sender, EventArgs e)
        {
            FigureViewer viewer = new FigureViewer(false);
            viewer.Show();
        }

        private void StatisticsBtn_Click(object sender, EventArgs e)
        {
            StatisticsForm f = new StatisticsForm();
            f.Show();
        }

        private void StartGameBtn_MouseEnter(object sender, EventArgs e)
        {

        }

        private void StartGameBtn_MouseLeave(object sender, EventArgs e)
        {

        }

        private void RootLayout_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
