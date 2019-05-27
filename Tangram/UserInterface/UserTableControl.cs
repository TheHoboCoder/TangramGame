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

        public bool edit = false;

        public int id = -1;

        public UserTableControl()
        {
            InitializeComponent();

            Update();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FamTB_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(!Char.IsLetter(e.KeyChar)&&e.KeyChar!=8 && e.KeyChar!=' ')
            {
                e.Handled = true;
            }
        }

        public void ReUpdate()
        {
            rolesFilterCombo.SelectedIndex = 0;
            rolesCombo.SelectedIndex = 0;
            ControlPanel.Visible = false;

            GridView.DataSource = Database.userRepository.Table;
        }

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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            edit = true;
            ControlPanel.Visible = true;

            LoginTB.Text = GridView.SelectedRows[0].Cells["login"].Value.ToString();
            NameTB.Text = GridView.SelectedRows[0].Cells["name"].Value.ToString();
            FamTB.Text = GridView.SelectedRows[0].Cells["fam"].Value.ToString();
            OtchTB.Text = GridView.SelectedRows[0].Cells["otch"].Value.ToString();
            PhoneTB.Text = GridView.SelectedRows[0].Cells["phone"].Value.ToString();
            PasswordTB.Text = GridView.SelectedRows[0].Cells["password"].Value.ToString();
            id = Convert.ToInt32(GridView.SelectedRows[0].Cells["id_user"].Value);

            if(Convert.ToInt32(GridView.SelectedRows[0].Cells["role_id"].Value)==1){
                rolesCombo.SelectedIndex = 0;
            }
            else
            {
                rolesCombo.SelectedIndex = 1;
            }

            PasswordTB.Visible = passwordLabel.Visible = false;
        }


        private User GetUser()
        {
           
           return  new User(id, 
                              rolesCombo.SelectedIndex == 0 ? User.UserTypes.VOSP : User.UserTypes.MET,
                              LoginTB.Text.Trim(),
                              NameTB.Text.Trim(),
                              FamTB.Text.Trim(),
                              OtchTB.Text.Trim(),
                              PhoneTB.Text.Trim(),
                              !edit ? User.getHash(PasswordTB.Text.Trim()) : PasswordTB.Text.Trim());
        }

        private bool isEmpty()
        {
            return LoginTB.Text == "" ||
                   NameTB.Text == "" ||
                   FamTB.Text == "" ||
                   OtchTB.Text == "" ||
                   PhoneTB.Text == "" ||
                   PasswordTB.Text == "";
        }


        private void LoginBtn_Click(object sender, EventArgs e)
        {
          
            if (edit)
            {
                if (!isEmpty())
                {
                    if (Database.userRepository.Update(GetUser()))
                    {
                        ControlPanel.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка", "Заполните поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
             
            }
            else
            {
                if (!isEmpty())
                {
                    if (Database.userRepository.Add(GetUser())!=-1)
                    {
                        ControlPanel.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка", "Заполните поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                   
            }

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            ControlPanel.Visible = false;
        }

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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Удалить пользователя?","Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Database.userRepository.Delete(Convert.ToInt32(GridView.SelectedRows[0].Cells["id_user"].Value));
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
