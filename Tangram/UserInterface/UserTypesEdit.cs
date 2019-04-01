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
            GridView.DataSource = Database.GroupTypeRepository.Table;
        }

        private Group_types GetGroupType()
        {
            return new Group_types()
            {
                Id = id,
                Group_type_name = GroupNameTB.Text.Trim()
            };
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Удалить тип группы?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Database.GroupTypeRepository.Delete(Convert.ToInt32(GridView.SelectedRows[0].Cells["id_group_type"].Value));
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            edit = true;
            ControlPanel.Visible = true;
            id = Convert.ToInt32(GridView.SelectedRows[0].Cells["id_group_type"].Value);
            GroupNameTB.Text = GridView.SelectedRows[0].Cells["group_type"].Value.ToString();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            edit = false;
            ControlPanel.Visible = true;
            GroupNameTB.Text = "";
            id = -1;
        }

       
        private bool isEmpty()
        {
            return GroupNameTB.Text == "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                if (!isEmpty())
                {
                    if (Database.GroupTypeRepository.Update(GetGroupType()))
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
                    if (Database.GroupTypeRepository.Add(GetGroupType())!=-1)
                    {
                        ControlPanel.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show( "Заполните поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void GroupNameTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            ControlPanel.Visible = false;
        }
    }
}
