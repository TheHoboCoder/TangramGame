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
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(LoginBtn.Text=="" || passwordTB.Text == "")
            {
                MessageBox.Show( "Заполните поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                switch (Database.Auth(LoginTB.Text.Trim(), passwordTB.Text.Trim()))
                {
                    case Database.AuthResult.AUTH_FAIL:
                        MessageBox.Show( "Неверный логин и/или пароль", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case Database.AuthResult.AUTH_PASS:
                        switch (Database.currentUser.UserType)
                        {
                            case (User.UserTypes.VOSP):
                                MainForm form = new MainForm();
                                form.Show();
                                this.Hide();
                                break;
                            case (User.UserTypes.MET):
                                break;
                        }
                        break;
                    case Database.AuthResult.EXCEPTION:
                        MessageBox.Show("Ошибка", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Database.Open();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database.Close();
        }
    }
}
