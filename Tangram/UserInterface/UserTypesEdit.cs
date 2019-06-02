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
    public partial class UserTypesEdit : Form
    {
        public bool edit = false;

        public int id = -1;

        public UserTypesEdit()
        {
            InitializeComponent();
            GridView.DataSource = Database.MetWorkspace.GroupTypes.Table;
        }

        //Создает объект данных тип группы
        private Group_types GetGroupType()
        {
            return new Group_types()
            {
                Id = id,
                Group_type_name = GroupNameTB.Text.Trim()
            };
        }

        //Обработчик нажатия на кнопку "Удалить"
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Удалить тип группы?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Database.MetWorkspace.GroupTypes.Delete(Convert.ToInt32(GridView.SelectedRows[0].Cells["id_group_type"].Value));
            }

            if(Database.MetWorkspace.GroupTypes.Table.Rows.Count == 0)
            {
                UpdateBtn.Enabled = DeleteBtn.Enabled = false;
            }
        }

        //Обработчик нажатия на кнопку "Редактировать"
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            edit = true;
            ControlPanel.Visible = true;
            id = Convert.ToInt32(GridView.SelectedRows[0].Cells["id_group_type"].Value);
            GroupNameTB.Text = GridView.SelectedRows[0].Cells["group_type"].Value.ToString();
        }

        //Обработчик нажатия на кнопку "Добавить"
        private void AddBtn_Click(object sender, EventArgs e)
        {
            edit = false;
            ControlPanel.Visible = true;
            GroupNameTB.Text = "";
            id = -1;
        }

        //Проверяет на заполнение поле название типа группы
        private bool isEmpty()
        {
            return GroupNameTB.Text == "";
        }

        //Обработчик нажатия на кнопку "Сохранить"
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                if (!isEmpty())
                {
                    if (Database.MetWorkspace.GroupTypes.Update(GetGroupType()))
                    {
                        ControlPanel.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                if (!isEmpty())
                {
                    if (Database.MetWorkspace.GroupTypes.Add(GetGroupType())!=-1)
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

        //Обработчик ввода символов в текстовое поле "Название типа группы", блокирует ввод символов, которые не являются буквами
        private void GroupNameTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        //Обработчик нажатия на кнопку "Отмена"
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            ControlPanel.Visible = false;
        }

        private void UserTypesEdit_Load(object sender, EventArgs e)
        {
            if (Database.MetWorkspace.GroupTypes.Table.Rows.Count == 0)
            {
                UpdateBtn.Enabled = DeleteBtn.Enabled = false;
            }
        }
    }
}
