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
using Tangram.Data.DataModels;

namespace Tangram.UserInterface
{
    public partial class UserEdit : Form
    {
        public UserEdit()
        {
            InitializeComponent();
        }

        //Обработчик нажатия на кнопку «Сохранить»
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(FamTB.Text=="" ||
               NameTB.Text =="" ||
               OcthTB.Text == "" ||
               PhoneTB.Text == "")
            {
                MessageBox.Show( "Заполните поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
            else
            {
                if (PasswordTB.Text != "")
                {
                    if (PasswordTB.Text != RepassTB.Text)
                    {
                        MessageBox.Show( "Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //if(!Database.ChangeCurrentUser(FamTB.Text.Trim(),
                        //                          NameTB.Text.Trim(),
                        //                          OcthTB.Text.Trim(),
                        //                          PhoneTB.Text.Trim(),
                        //                          PasswordTB.Text.Trim()))
                        //{
                        //    MessageBox.Show("Ошибка", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        //else
                        //{
                        //    this.Close();
                        //}

                        User current = Database.userRepository.currentUser;
                        if (!Database.userRepository.Update(new User( current.Id,
                                                                     current.UserType,
                                                                    current.Login,
                                                                    NameTB.Text.Trim(),
                                                                    FamTB.Text.Trim(),
                                                                    OcthTB.Text.Trim(),
                                                                    PhoneTB.Text.Trim(),
                                                                    User.getHash(PasswordTB.Text.Trim()))))
                        {
                            MessageBox.Show( "Ошибка базы данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            this.Close();
                        }

                    }
                }
                else
                {
                    //if(!Database.ChangeCurrentUser(FamTB.Text.Trim(),
                    //                              NameTB.Text.Trim(),
                    //                              OcthTB.Text.Trim(),
                    //                              PhoneTB.Text.Trim()
                    //                               ))
                    //{
                    //    MessageBox.Show("Ошибка", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //else
                    //{
                    //    this.Close();
                    //}
                    User current = Database.userRepository.currentUser;
                    if (!Database.userRepository.Update(new User(current.Id,
                                                                 current.UserType,
                                                                current.Login,
                                                                NameTB.Text.Trim(),
                                                                FamTB.Text.Trim(),
                                                                OcthTB.Text.Trim(),
                                                                PhoneTB.Text.Trim(),
                                                                current.Password)))
                    {
                        MessageBox.Show("Ошибка базы данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }


        //обработчик нажатия на кнопку "Отмена"
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show( "Закрыть? Изменения не будут сохранены", "Закрытие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //Обработчик загрузки формы
        private void UserEdit_Load(object sender, EventArgs e)
        {
            FamTB.Text = Database.userRepository.currentUser.Fam;
            NameTB.Text = Database.userRepository.currentUser.Name;
            OcthTB.Text = Database.userRepository.currentUser.Otch;
            PhoneTB.Text = Database.userRepository.currentUser.Phone;
        }
    }
}
