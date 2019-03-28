﻿using System;
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
    public partial class UserEdit : Form
    {
        public UserEdit()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(FamTB.Text=="" ||
               NameTB.Text =="" ||
               OcthTB.Text == "" ||
               PhoneTB.Text == "")
            {
                MessageBox.Show("Ошибка", "Заполните поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
            else
            {
                if (PasswordTB.Text != "")
                {
                    if (PasswordTB.Text != RepassTB.Text)
                    {
                        MessageBox.Show("Ошибка", "Пароли не совпадают", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if(!Database.ChangeCurrentUser(FamTB.Text.Trim(),
                                                  NameTB.Text.Trim(),
                                                  OcthTB.Text.Trim(),
                                                  PhoneTB.Text.Trim(),
                                                  PasswordTB.Text.Trim()))
                        {
                            MessageBox.Show("Ошибка", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            this.Close();
                        }

                    }
                }
                else
                {
                    if(!Database.ChangeCurrentUser(FamTB.Text.Trim(),
                                                  NameTB.Text.Trim(),
                                                  OcthTB.Text.Trim(),
                                                  PhoneTB.Text.Trim()
                                                   ))
                    {
                        MessageBox.Show("Ошибка", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Закрытие", "Закрыть? Изменения не будут сохранены", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void UserEdit_Load(object sender, EventArgs e)
        {
            FamTB.Text = Database.currentUser.Fam;
            NameTB.Text = Database.currentUser.Name;
            OcthTB.Text = Database.currentUser.Otch;
            PhoneTB.Text = Database.currentUser.Phone;
        }
    }
}
