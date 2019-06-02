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
        //показывает, была ли закрыта форма пользователем
        bool userClose = false;

        //Конструктор формы
        public MainForm()
        {
            InitializeComponent();
        }

        //Обработчик загрузки формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateName();
        }

        //Обновляет имя и фамилию текущего пользователя
        private void UpdateName()
        {
            userName.Text = Database.userRepository.currentUser.Name + " " + Database.userRepository.currentUser.Otch;
        }

        //Обработчик нажатия на кнопку "Редактировать пользователя", открывает форму для редактирования текущего пользователя
        private void userProfile_Click(object sender, EventArgs e)
        {
            UserEdit users = new UserEdit();
            users.ShowDialog();
            UpdateName();
        }

        //Обработчик нажатия на кнопку "Начать игру", открывает форму для  для выбора детей для занятия
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

        //Обработчик закрытия формы.
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!userClose)
            {
                Application.Exit();
            }
           
        }


        //Обработчик нажатия на кнопку «Выход», открывает форму авторизации.
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

        //Обработчик нажатия на кнопку «Фигуры», открывает форму для просмотра фигур.
        private void FiguresBtn_Click(object sender, EventArgs e)
        {
            FigureViewer viewer = new FigureViewer(false);
            viewer.Show();
        }


        //Обработчик нажатия на кнопку «Статистика», открывает форму для просмотра статистики.
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
