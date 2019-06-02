using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.Data;
using Tangram.Data.DataModels;

namespace Tangram.UserInterface
{
    public partial class UserTableControl : UserControl
    {

        //режим добавления или изменения
        public bool edit = false;

        private string cur_password = "";

        //идентификатор текущего пользователя
        public int id = -1;

        public UserTableControl()
        {
            InitializeComponent();

            ReUpdate();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        //Обработчик ввода символов в тестовое поле, блокирует ввод символов, не являющихся буквами.
        private void FamTB_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(!Char.IsLetter(e.KeyChar)&&e.KeyChar!=8 && e.KeyChar!=' ')
            {
                e.Handled = true;
            }
        }

        //Обновляет панель
        public void ReUpdate()
        {
            rolesFilterCombo.SelectedIndex = 0;
            rolesCombo.SelectedIndex = 0;
            ControlPanel.Visible = false;

            GridView.DataSource = Database.userRepository.Table;

            if(Database.userRepository.Table.Rows.Count == 0)
            {
                UpdateBtn.Enabled = DeleteBtn.Enabled = false;
            }
        }


        //Обработчик ввода символов в тестовое поле "Телефон", блокирует ввод символов, не являющихся цифрами.
        private void PhoneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //Обработчик нажатия на кнопку "Добавить", очищает поля ввода и выводит панель для добавления
        private void AddBtn_Click(object sender, EventArgs e)
        {
            ControlPanel.Visible = true;
            LoginTB.Text = "";
            NameTB.Text = "";
            FamTB.Text = "";
            OtchTB.Text = "";
            PhoneTB.Text ="";
            PasswordTB.Text = "";
            id = -1;
            edit = false;
            PasswordTB.Visible = passwordLabel.Visible = true;
        }

        //Обработчик нажатия на кнопку "Изменить", заполняет поля ввода и выводит панель для редактирования
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            edit = true;
            PasswordHint.Visible = true;
            ControlPanel.Visible = true;

            LoginTB.Text = GridView.SelectedRows[0].Cells["login"].Value.ToString();
            NameTB.Text = GridView.SelectedRows[0].Cells["name"].Value.ToString();
            FamTB.Text = GridView.SelectedRows[0].Cells["fam"].Value.ToString();
            OtchTB.Text = GridView.SelectedRows[0].Cells["otch"].Value.ToString();
            PhoneTB.Text = GridView.SelectedRows[0].Cells["phone"].Value.ToString();
            cur_password = GridView.SelectedRows[0].Cells["password"].Value.ToString();
            PasswordTB.Text = "";
            id = Convert.ToInt32(GridView.SelectedRows[0].Cells["id_user"].Value);

            if(Convert.ToInt32(GridView.SelectedRows[0].Cells["role_id"].Value)==1){
                rolesCombo.SelectedIndex = 0;
            }
            else
            {
                rolesCombo.SelectedIndex = 1;
            }

        }

        //создает объект данных Пользователь
        private User GetUser()
        {
           
           return  new User(id, 
                              rolesCombo.SelectedIndex == 0 ? User.UserTypes.VOSP : User.UserTypes.MET,
                              LoginTB.Text.Trim(),
                              NameTB.Text.Trim(),
                              FamTB.Text.Trim(),
                              OtchTB.Text.Trim(),
                              PhoneTB.Text.Trim(),
                              !edit || PasswordTB.Text!="" ? User.getHash(PasswordTB.Text.Trim()) : cur_password);
        }

        //Проверяет поля на пустоту
        private bool isEmpty()
        {
            return LoginTB.Text == "" ||
                   NameTB.Text == "" ||
                   FamTB.Text == "" ||
                   OtchTB.Text == "" ||
                   PhoneTB.Text == "";
                  
        }

        //обработчик нажатия на кнопку "Сохранить"
        private void LoginBtn_Click(object sender, EventArgs e)
        {
          
            if (edit)
            {
                if (!isEmpty())
                {
                    if (Database.userRepository.Update(GetUser()))
                    {
                        ControlPanel.Visible = false;
                        PasswordHint.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show( "Заполните поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
             
            }
            else
            {
                if (!isEmpty() && PasswordTB.Text!="")
                {
                    if (Database.userRepository.Add(GetUser())!=-1)
                    {
                        ControlPanel.Visible = false;
                        UpdateBtn.Enabled = DeleteBtn.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show( "Заполните поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                   
            }

        }

        //обработчик нажатия на кнопку "Отмена"
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            ControlPanel.Visible = false;
        }


        //обработчик закрытия выпадающего списка "Фильтр по роли пользователя"
        private void rolesFilterCombo_DropDownClosed(object sender, EventArgs e)
        {
            switch (rolesFilterCombo.SelectedIndex) {
                case 0:
                    GridView.DataSource = Database.userRepository.Table;
                    break;
                case 1:
                    Database.userRepository.FilterUsersByType(User.UserTypes.VOSP);
                    GridView.DataSource = Database.userRepository.filteredTable;
                    break;
                case 2:
                    Database.userRepository.FilterUsersByType(User.UserTypes.MET);
                    GridView.DataSource = Database.userRepository.filteredTable;
                    break;
            }

        }

        //обработчик изменения текста в поле "Фильтр по фамилии"
        private void famFilter_TextChanged(object sender, EventArgs e)
        {
            if(famFilter.Text != "")
            {
                Database.userRepository.FilterUsersByFam(famFilter.Text.Trim());
                GridView.DataSource = Database.userRepository.filteredTable;
            }
            else
            {

                GridView.DataSource = Database.userRepository.Table;
            }
        }

        //обработчик нажатия на кнопку удалить 
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Удалить пользователя?","Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Database.userRepository.Delete(Convert.ToInt32(GridView.SelectedRows[0].Cells["id_user"].Value));
                if (Database.userRepository.Table.Rows.Count == 0)
                {
                    UpdateBtn.Enabled = DeleteBtn.Enabled = false;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
