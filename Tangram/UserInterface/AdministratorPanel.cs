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
    public partial class AdministratorPanel : Form
    {
        bool userClose = false;

        private UserTableControl control;
        private GroupChildControl childGroup;
        private ResultsViewer viewer;

        public AdministratorPanel()
        {
            InitializeComponent();
            
        }
        //Выводит имя и фамилию текущего пользователя в текстовое поле
        private void UpdateName()
        {
            userName.Text = Database.userRepository.currentUser.Name + " " + Database.userRepository.currentUser.Otch;
        }

        //Обработчик загрузки формы
        private void AdministratorPanel_Load(object sender, EventArgs e)
        {
            UpdateName();
            control = new UserTableControl();
            childGroup = new GroupChildControl();
            viewer = new ResultsViewer();
        }

        //открывает форму входа
        private void userProfile_Click(object sender, EventArgs e)
        {
            UserEdit users = new UserEdit();
            users.ShowDialog();
            UpdateName();
        }

        //Обработчик закрытия формы
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

        //Обработчик закрытия формы
        private void AdministratorPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!userClose)
            {
                Application.Exit();
            }
        }

        //отображает панель для управления пользователями.
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            control.ReUpdate();
            control.Dock = DockStyle.Fill;
            TablePlace.Controls.Clear();
            TablePlace.Controls.Add(control);
        }

        //отображает панель для управления группами и списком детей в группах
        private void button1_Click(object sender, EventArgs e)
        {
            childGroup.Dock = DockStyle.Fill;
            childGroup.ReUpdate();
            TablePlace.Controls.Clear();
            TablePlace.Controls.Add(childGroup);
        }

        //отображает панель для просмотра результатов игр
        private void button2_Click(object sender, EventArgs e)
        {
            viewer.Dock = DockStyle.Fill;
            TablePlace.Controls.Clear();
            TablePlace.Controls.Add(viewer);
        }

        //открывает форму для просмотра статистики
        private void StatisticsBtn_Click(object sender, EventArgs e)
        {
            StatisticsForm f = new StatisticsForm();
            f.Show();
        }

        //открывает форму для редактирования типов групп
        private void button3_Click(object sender, EventArgs e)
        {
            UserTypesEdit groupTypes = new UserTypesEdit();
            groupTypes.ShowDialog();
        }
    }
}
