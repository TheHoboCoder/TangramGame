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
using Tangram.Data.DataModels;

namespace Tangram.UserInterface
{
    public partial class LoginForm : Form
    {
        private bool reLog = false;


        //Констуктор формы
        public LoginForm(bool reLog)
        {
            InitializeComponent();
            this.reLog = reLog;
            this.KeyPreview = true;
        }

        //Авторизация
        private void Auth()
        {
            if (LoginBtn.Text == "" || passwordTB.Text == "")
            {
                MessageBox.Show("Заполните поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                switch (Database.userRepository.Auth(LoginTB.Text.Trim(), passwordTB.Text.Trim()))
                {
                    case UserRepository.AuthResult.AUTH_FAIL:
                        MessageBox.Show("Неверный логин и/или пароль", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case UserRepository.AuthResult.AUTH_PASS:
                        //Database.Init(Database.userRepository.currentUser.UserType);
                        switch (Database.userRepository.currentUser.UserType)
                        {
                            case (User.UserTypes.VOSP):
                                MainForm form = new MainForm();
                                form.Show();

                                if (!reLog)
                                {
                                    Hide();
                                }
                                else
                                {
                                    Close();
                                }

                                break;
                            case (User.UserTypes.MET):
                                AdministratorPanel panel = new AdministratorPanel();
                                panel.Show();
                                if (!reLog)
                                {
                                    Hide();
                                }
                                else
                                {
                                    Close();
                                }
                                break;
                        }

                        DialogResult = DialogResult.OK;
                        break;
                    case UserRepository.AuthResult.EXCEPTION:
                        MessageBox.Show("Ошибка", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                }
            }
        }

        //Обработчик нажатия на кнопку "Вход"
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Auth();
        }

        //обработчик загрузки формы
        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (!reLog)
            {
                if (!Database.Open())
                {
                    MessageBox.Show("Невозможно подключиться к базе данных.Приложение будет закрыто","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            
        }

        //обработчик закрытия формы
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!reLog)
            {
                Database.Close();
            }
              
        }

        //Обработчик нажатия клавиши "Enter"
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Auth();
            }
        }
    }
}
