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
    public partial class GroupChildControl : UserControl
    {
        bool groupEdit = false;

        int groupId = -1;
        int childId = -1;
        int ChildCount = 0;

        bool childEdit = false;

        public GroupChildControl()
        {
            InitializeComponent();
            Update();

        }


        public void ReUpdate()
        {
            Database.userRepository.FilterUsersByType(User.UserTypes.VOSP);

            teacherCombo.DataSource = Database.userRepository.filteredTable;
            teacherCombo.ValueMember = "id_user";
            teacherCombo.DisplayMember = "usersInitials";
            teacherCombo.SelectedIndex = 0;

            groupTypeCombo.DataSource = Database.GroupTypeRepository.Table;
            groupTypeCombo.ValueMember = "group_type_id";
            groupTypeCombo.DisplayMember = "group_type_name";
            groupTypeCombo.SelectedIndex = 0;

            GroupsCombo.DataSource = Database.GroupsRepository.Table;
            GroupsCombo.ValueMember = "id_group";
            GroupsCombo.DisplayMember = "group_name";

            GroupGridView.DataSource = Database.GroupsRepository.Table;

            groupTypeFilter.DataSource = Database.GroupTypeRepository.Table;
            groupTypeFilter.ValueMember = "group_type_id";
            groupTypeFilter.DisplayMember = "group_type_name";
            groupTypeFilter.SelectedIndex = 0;

            //groupTypeFilter.Items.Insert(0, "<Не выбрано>");

            if (Database.GroupsRepository.Table.Rows.Count >= 0)
            {
                filterTable(Convert.ToInt32(Database.GroupsRepository.Table.Rows[0]["id_group"]));

            }
            else
            {
                filterTable(-1);
                AddChildBtn.Enabled = EditChildBtn.Enabled = DeleteChildBtn.Enabled = false;
                UpdateGroupBtn.Enabled = DeleteChildBtn.Enabled = false;
            }
        }



        private void filterTable(int id)
        {
            Database.ChildrenRepository.GetChildrenInGroup(id);
            ChildGridView.DataSource = Database.ChildrenRepository.filteredTable;

            subGroupFilter.Items.Clear();
            for (int i =1; i<= Database.ChildrenRepository.currentGroupCount; ++i)
            {
                subGroupFilter.Items.Add(i + " подгруппа");
            }
            if (ChildGridView.Rows.Count == 0)
            {
                EditChildBtn.Enabled = DeleteChildBtn.Enabled = false;
            }
            else
            {
               EditChildBtn.Enabled = DeleteChildBtn.Enabled = true;
            }
        }


        public Garden_groups getGroup() {
            return new Garden_groups()
            {
                Id = groupId,
                Group_Name = GroupNameTB.Text.Trim(),
                GroupTypeId = Convert.ToInt32(groupTypeCombo.SelectedValue),
                TeacherId = Convert.ToInt32(teacherCombo.SelectedValue),
                childCount = ChildCount
            };
        }

        public Child getChild()
        {
            return new Child() {
                Id = childId,
                GroupId = Convert.ToInt32(GroupsCombo.SelectedValue),
                SubGroup = subGroupFilter.SelectedIndex + 1,
                Fam = FamTB.Text.Trim(),
                Name = NameTB.Text.Trim(),
                gender = genderBox.SelectedIndex == 0
            };

        }


        private void AddGroupBtn_Click(object sender, EventArgs e)
        {
            GroupControlPanel.Visible = true;
            groupEdit = false;
            GroupNameTB.Text = "";
            teacherCombo.SelectedIndex = 0;
            groupTypeCombo.SelectedIndex = 0;
            groupId = -1;
            ChildCount = 0;

        }

        private void UpdateGroupBtn_Click(object sender, EventArgs e)
        {
            groupId = Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["Id"].Value);
            ChildCount = Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["count"].Value);
            GroupNameTB.Text = GroupGridView.SelectedRows[0].Cells["GroupName"].Value.ToString();
            teacherCombo.SelectedValue = GroupGridView.SelectedRows[0].Cells["id_user"].Value;
            groupTypeCombo.SelectedValue = GroupGridView.SelectedRows[0].Cells["group_type_id"].Value;
            GroupControlPanel.Visible = true;
            groupEdit = true;
        }

        private void DeleteGroupBtn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Удалить группу?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                if (Database.GroupsRepository.Delete(Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["Id"].Value)))
                {
                    if(GroupGridView.Rows.Count == 0)
                    {
                        AddChildBtn.Enabled = EditChildBtn.Enabled = DeleteChildBtn.Enabled = false;
                        UpdateGroupBtn.Enabled = DeleteChildBtn.Enabled = false;
                    }
                }
                
            }
        }

        private void CancelGroupBtn_Click(object sender, EventArgs e)
        {
            GroupControlPanel.Visible = false;
        }

        private void SaveGroupBtn_Click(object sender, EventArgs e)
        {
            if (groupEdit)
            {
                if (GroupNameTB.Text != "")
                {
                    if (Database.GroupsRepository.Update(getGroup()))
                    {
                        GroupControlPanel.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка", "Заполните поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (GroupNameTB.Text != "")
                {
                    int c = Database.GroupsRepository.Add(getGroup());
                    if (c!=-1)
                    {
                        UpdateGroupBtn.Visible = DeleteGroupBtn.Visible = true;
                        AddChildBtn.Visible = true;
                        filterTable(c);
                        GroupControlPanel.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка", "Заполните поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
           
        }

        private void DeleteChildBtn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Удалить ребенка?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                if (Database.ChildrenRepository.Delete(Convert.ToInt32(ChildGridView.SelectedRows[0].Cells["id_child"].Value)))
                {
                    if (ChildGridView.Rows.Count == 0)
                    {
                        EditChildBtn.Enabled = DeleteChildBtn.Enabled = false;
                    }
                }

            }
        }

        private void AddChildBtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            NameTB.Text = "";
            FamTB.Text = "";
            genderBox.SelectedIndex = 0;
            subGroupFilter.SelectedIndex = 0;
            GroupsCombo.SelectedValue = GroupGridView.SelectedRows[0].Cells["group_type_id"].Value;
            childId = -1;
            childEdit = false;
           
            

        }

        private void EditChildBtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            NameTB.Text = ChildGridView.SelectedRows[0].Cells["ChildName_1"].Value.ToString();
            childId = Convert.ToInt32(ChildGridView.SelectedRows[0].Cells["id_child"].Value);
            FamTB.Text = ChildGridView.SelectedRows[0].Cells["fam"].Value.ToString();

            if (Convert.ToBoolean(ChildGridView.SelectedRows[0].Cells["genderInt"].Value))
            {
                genderBox.SelectedIndex = 0;
            }
            else
            {
                genderBox.SelectedIndex = 1;
            }

            subGroupFilter.SelectedIndex = Convert.ToInt32(ChildGridView.SelectedRows[0].Cells["subGroup"].Value) - 1;
            GroupsCombo.SelectedValue = GroupGridView.SelectedRows[0].Cells["Id"].Value;
            childEdit = true;
        }

        private void SaveChildButton_Click(object sender, EventArgs e)
        {
            if (childEdit)
            {
                if (NameTB.Text != "" && FamTB.Text != "")
                {
                    if (Database.ChildrenRepository.Update(getChild()))
                    {
                        filterTable(Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["Id"].Value));
                        panel1.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка", "Заполните поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (NameTB.Text != "" && FamTB.Text != "")
                {
                    int c = Database.ChildrenRepository.Add(getChild());
                    if (c != -1)
                    {
                        filterTable(Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["Id"].Value));
                        EditChildBtn.Visible = DeleteChildBtn.Visible = true;
                        panel1.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка", "Заполните поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CancelChildBtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void GroupGridView_Click(object sender, EventArgs e)
        {
            if (GroupGridView.SelectedRows.Count != 0)
            {
                filterTable(Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["Id"].Value));
            }
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            Database.GroupsRepository.FilterGroupsByType(Convert.ToInt32(groupTypeFilter.SelectedValue));
            GroupGridView.DataSource = Database.GroupsRepository.filteredTable;

            filterTable(Convert.ToInt32(groupTypeFilter.SelectedValue));

            if (GroupGridView.Rows.Count == 0)
            {
                UpdateGroupBtn.Enabled = DeleteGroupBtn.Enabled = false;
            }
            else
            {
               
                UpdateGroupBtn.Enabled = DeleteChildBtn.Enabled = true;
            }


        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            UpdateGroupBtn.Enabled = DeleteGroupBtn.Enabled = true;
            GroupGridView.DataSource = Database.GroupsRepository.Table;
            filterTable(Convert.ToInt32(Database.GroupsRepository.Table.Rows[0]["id_group"]));
        }

        private void EditGroupTypes_Click(object sender, EventArgs e)
        {
            UserTypesEdit groupTypes = new UserTypesEdit();
            groupTypes.ShowDialog();
        }
    }
}
