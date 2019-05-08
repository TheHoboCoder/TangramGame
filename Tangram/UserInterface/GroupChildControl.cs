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
        int group_hId = -1;
        int childJournalId = -1;
        int userId = -1;

        bool childEdit = false;

        int currentYear = 0;

        public GroupChildControl()
        {
            InitializeComponent();
            ReUpdate();

        }


        public void ReUpdate()
        {
            yearPicker.Value = GroupsRepository.GetWorkYear(DateTime.Now);

            Database.userRepository.FilterUsersByType(User.UserTypes.VOSP);

            teacherCombo.DataSource = Database.userRepository.filteredTable;
            teacherCombo.ValueMember = "id_user";
            teacherCombo.DisplayMember = "usersInitials";
            teacherCombo.SelectedIndex = 0;

            groupTypeCombo.DataSource = Database.MetWorkspace.GroupTypes.Table;
            groupTypeCombo.ValueMember = "group_type_id";
            groupTypeCombo.DisplayMember = "group_type_name";
            groupTypeCombo.SelectedIndex = 0;

           
            GroupsCombo.ValueMember = "id_group_h";
            GroupsCombo.DisplayMember = "group_name";
            GroupsCombo.DataSource = Database.MetWorkspace.GroupManager.groups.PureGroups;

            GroupGridView.DataSource = Database.MetWorkspace.GroupManager.groups.Table;

            groupTypeFilter.DataSource = Database.MetWorkspace.GroupTypes.Table;
            groupTypeFilter.ValueMember = "group_type_id";
            groupTypeFilter.DisplayMember = "group_type_name";
            groupTypeFilter.SelectedIndex = 0;

            //groupTypeFilter.Items.Insert(0, "<Не выбрано>");

            if (Database.MetWorkspace.GroupManager.groups.Table.Rows.Count > 0)
            {
                if (GroupGridView.Rows[0].Cells["id_group_h"].Value != DBNull.Value)
                {
                    AddChildBtn.Enabled = true;
                    filterTable(Convert.ToInt32(Database.MetWorkspace.GroupManager.groups.Table.Rows[0]["id_group_h"]));
                }
                else
                {
                    AddChildBtn.Enabled = false;
                    filterTable(-1);
                }

            }
        }

        private void UpdateCurrentYear(int year)
        {
            currentYear = year;
            workYear.Text = " - " + (year+1);
            Database.MetWorkspace.GroupManager.groups.FilterByYear(currentYear);
            GroupsCombo.ValueMember = "id_group_h";
            GroupsCombo.DisplayMember = "group_name";
            GroupsCombo.DataSource = Database.MetWorkspace.GroupManager.groups.PureGroups;
        }


        private void yearPicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentYear((int)yearPicker.Value);

            if (Database.MetWorkspace.GroupManager.groups.Table.Rows.Count > 0)
            {

                if (GroupGridView.SelectedRows.Count > 0 &&
                     GroupGridView.SelectedRows[0].Cells["id_group_h"].Value != DBNull.Value)
                {
                    AddChildBtn.Enabled = true;
                    filterTable(Convert.ToInt32(Database.MetWorkspace.GroupManager.groups.Table.Rows[0]["id_group_h"]));
                }
                else
                {
                    AddChildBtn.Enabled = false;
                    filterTable(-1);
                }

            }
        }



        private void filterTable(int id)
        { 

            Database.MetWorkspace.ChildManager.children.GetChildrenInGroup(id);
            ChildGridView.DataSource = Database.MetWorkspace.ChildManager.children.filteredTable;

            subGroupFilter.Items.Clear();
            for (int i =1; i <= Database.MetWorkspace.ChildManager.children.currentGroupCount; ++i)
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
                //TeacherId = Convert.ToInt32(teacherCombo.SelectedValue),
                //childCount = ChildCount
            };
        }

        public History_group GetHistory_Group()
        {
            return new History_group() {
                Id = group_hId,
                GroupId = groupId,
                UserId = Convert.ToInt32(teacherCombo.SelectedValue),
                Year = currentYear
            };
        }

        public Child getChild()
        {
            return new Child() {
                Id = childId,
                //GroupId = Convert.ToInt32(GroupsCombo.SelectedValue),
                //SubGroup = subGroupFilter.SelectedIndex + 1,
                Fam = FamTB.Text.Trim(),
                Name = NameTB.Text.Trim(),
                gender = genderBox.SelectedIndex == 0,
                birthday = ChildBirthDay.Value
            };

        }

        public Child_Journal GetChild_Journal()
        {
            return new Child_Journal() {
                Id = childJournalId,
                ChildId = childId,
                GroupHistoryId = Convert.ToInt32(GroupsCombo.SelectedValue),
                SubGroup=subGroupFilter.SelectedIndex + 1,
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
            group_hId = -1;
            userId = -1;

        }

        private void UpdateGroupBtn_Click(object sender, EventArgs e)
        {
            groupId = Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["Id"].Value);
            GroupNameTB.Text = GroupGridView.SelectedRows[0].Cells["GroupName"].Value.ToString();

            if (GroupGridView.SelectedRows[0].Cells["id_user"].Value == null ||
                GroupGridView.SelectedRows[0].Cells["id_user"].Value == DBNull.Value)
            {
                userId = -1;
                group_hId = -1;
                teacherCombo.SelectedValue = 0;
            }
            else
            {
                userId = Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["id_user"].Value);
                group_hId = Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["id_group_h"].Value);
                teacherCombo.SelectedValue = userId;
            }
            groupTypeCombo.SelectedValue = GroupGridView.SelectedRows[0].Cells["group_type_id"].Value;
            GroupControlPanel.Visible = true;
            groupEdit = true;
        }

        private void DeleteGroupBtn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Удалить группу?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                if (Database.MetWorkspace.GroupManager.Delete(Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["Id"].Value)))
                {
                    if(GroupGridView.Rows.Count == 0)
                    {
                        AddChildBtn.Enabled = EditChildBtn.Enabled = DeleteChildBtn.Enabled = false;
                        UpdateGroupBtn.Enabled = DeleteGroupBtn.Enabled = false;
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
                if (GroupNameTB.Text != "" && teacherCombo.SelectedValue!=null)
                {
                    if(userId != Convert.ToInt32(teacherCombo.SelectedValue))
                    {

                        DataRow[] rows = Database.MetWorkspace.GroupManager.groups.Table.Select("id_user = '" + teacherCombo.SelectedValue + "'");

                        if (rows.Count() > 0)
                        {
                            if (userId == -1)
                            {
                                DialogResult res = MessageBox.Show("Воспитатель " + rows[0]["fam"] + " уже назначен на группу \"" + rows[0]["group_name"] + "\" " +
                                                  "\nНазначить его на данную группу (он будет снят с группы \"" + rows[0]["group_name"] + "\"",
                                                  "Предупреждение",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

                                if (res == DialogResult.No)
                                {
                                    return;
                                }
                                else
                                {
                                    Database.MetWorkspace.GroupManager.history.Delete(Convert.ToInt32(rows[0]["id_group_h"]));
                                }
                            }
                            else
                            {
                                DataRow row = Database.MetWorkspace.GroupManager.groups.Table.Select("id_user = '" + userId + "'")[0];
                                DialogResult res = MessageBox.Show("Воспитатель " + rows[0]["fam"] + " уже назначен на группу \"" + rows[0]["group_name"] + "\"" +
                                                 "Поменять его местами с " + row["fam"] + ", который назначен на данную группу",
                                                 "Предупреждение",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);
                                if (res == DialogResult.No)
                                {
                                    return;
                                }
                                else
                                {
                                    History_group gr = new History_group()
                                    {
                                        Id = Convert.ToInt32(rows[0]["id_group_h"]),
                                        GroupId = Convert.ToInt32(rows[0]["id_group"]),
                                        UserId = userId,
                                        Year = Convert.ToInt32(rows[0]["history_year"])
                                    };

                                    if (!Database.MetWorkspace.GroupManager.history.Update(gr))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        teacherCombo.SelectedValue = rows[0]["id_user"];
                                    }

                                }
                            }
                        }
                    }

                  
                    if (Database.MetWorkspace.GroupManager.groups.Update(getGroup()))
                    {
                        if (group_hId != -1)
                        {
                            Database.MetWorkspace.GroupManager.history.Update(GetHistory_Group());
                        }
                        else
                        {
                            Database.MetWorkspace.GroupManager.history.Add(GetHistory_Group());
                        }
                       Database.MetWorkspace.GroupManager.groups.UpdateTable();
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
                if (GroupNameTB.Text != "" && teacherCombo.SelectedValue != null)
                {

                    DataRow[] rows = Database.MetWorkspace.GroupManager.groups.Table.Select("id_user = '" + teacherCombo.SelectedValue + "'");
                    if (rows.Count() > 0)
                    {
                        DataRow[] childRows = Database.MetWorkspace.ChildManager.children.Table.Select("id_group_h = '" + rows[0]["id_group_h"]+ "'");
                        if(childRows.Count() == 0)
                        {
                            DialogResult res = MessageBox.Show("Воспитатель " + rows[0]["fam"] + " уже назначен на группу \"" + rows[0]["group_name"] + "\"" +
                                                                       "Назначить его на данную группу (он будет снят с группы \"" + rows[0]["group_name"] + "\"",
                                                                       "Предупреждение",
                                                                       MessageBoxButtons.YesNo,
                                                                       MessageBoxIcon.Warning);

                            if (res == DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                Database.MetWorkspace.GroupManager.history.Delete(Convert.ToInt32(rows[0]["id_group_h"]));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Воспитатель не должен повторяться","Невозможно сохранить",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }


                    if (Database.MetWorkspace.GroupManager.Add(getGroup(), GetHistory_Group()))
                    {
                        UpdateGroupBtn.Enabled= DeleteGroupBtn.Enabled = true;
                        AddChildBtn.Enabled = true;
                        filterTable(Convert.ToInt32(Database.MetWorkspace.GroupManager.groups.Table.Rows[0]["id_group_h"]));
                        GroupControlPanel.Visible = false;
                    }
                    Database.MetWorkspace.GroupManager.groups.FilterByYear(currentYear);
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
                if (Database.MetWorkspace.ChildManager.Delete(Convert.ToInt32(ChildGridView.SelectedRows[0].Cells["id_child"].Value)))
                {
                    if (ChildGridView.Rows.Count == 0)
                    {
                        EditChildBtn.Enabled = DeleteChildBtn.Enabled = false;
                    }
                    Database.MetWorkspace.GroupManager.groups.FilterByYear(currentYear);
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
            //GroupsCombo.SelectedValue = GroupGridView.SelectedRows[0].Cells["group_type_id"].Value;
            childId = -1;
            group_hId = -1;
            childEdit = false;

        }

        private void EditChildBtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            NameTB.Text = ChildGridView.SelectedRows[0].Cells["ChildName_1"].Value.ToString();
            childId = Convert.ToInt32(ChildGridView.SelectedRows[0].Cells["id_child"].Value);
            childJournalId = Convert.ToInt32(ChildGridView.SelectedRows[0].Cells["id_journal"].Value);
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
            group_hId = Convert.ToInt32(ChildGridView.SelectedRows[0].Cells["id_group_h_2"].Value);
            GroupsCombo.SelectedValue = Convert.ToInt32(ChildGridView.SelectedRows[0].Cells["id_group_h_2"].Value);

            childEdit = true;
        }

        private void SaveChildButton_Click(object sender, EventArgs e)
        {
            if (childEdit)
            {
                if (NameTB.Text != "" && FamTB.Text != "")
                {
                    if (Database.MetWorkspace.ChildManager.children.Update(getChild()))
                    {
                        Database.MetWorkspace.ChildManager.childJournal.Update(GetChild_Journal());
                        Database.MetWorkspace.ChildManager.children.UpdateTable();
                        filterTable(Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["id_group_h"].Value));
                        panel1.Visible = false;
                        Database.MetWorkspace.GroupManager.groups.FilterByYear(currentYear);
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
                    //DataRow row = Database.MetWorkspace.GroupManager.groups.Table.Select("id_group = '" + GroupsCombo.SelectedValue + "'")[0];
                    //group_hId = Convert.ToInt32(row["id_group_h"]);
                    if (Database.MetWorkspace.ChildManager.Add(getChild(),GetChild_Journal()))
                    {
                        filterTable(Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["id_group_h"].Value));
                        EditChildBtn.Visible = DeleteChildBtn.Visible = true;
                        panel1.Visible = false;
                        Database.MetWorkspace.GroupManager.groups.FilterByYear(currentYear);
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CancelChildBtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void GroupGridView_Click(object sender, EventArgs e)
        {
            if (GroupGridView.SelectedRows.Count != 0 &&
                GroupGridView.SelectedRows[0].Cells["id_group_h"].Value !=null &&
                GroupGridView.SelectedRows[0].Cells["id_group_h"].Value != DBNull.Value)
            {
                group_hId = Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["id_group_h"].Value);
                filterTable(Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["id_group_h"].Value));
                GroupsCombo.SelectedValue = Convert.ToInt32(GroupGridView.SelectedRows[0].Cells["id_group_h"].Value);
            }
            else
            {
                filterTable(-1);
            }
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            Database.MetWorkspace.GroupManager.groups.FilterGroupsByType(Convert.ToInt32(groupTypeFilter.SelectedValue));
            GroupGridView.DataSource = Database.MetWorkspace.GroupManager.groups.filteredTable;

            //filterTable(Convert.ToInt32(groupTypeFilter.SelectedValue));

            if (GroupGridView.Rows.Count == 0 &&
                 Database.MetWorkspace.GroupManager.groups.Table.Rows[0]["id_group_h"] == DBNull.Value)
            {
                filterTable(-1);
                UpdateGroupBtn.Enabled = DeleteGroupBtn.Enabled = false;
            }
            else
            {
               
                UpdateGroupBtn.Enabled = DeleteGroupBtn.Enabled = true;
                filterTable(Convert.ToInt32(GroupGridView.Rows[0].Cells["id_group_h"].Value));
            }


        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            UpdateGroupBtn.Enabled = DeleteGroupBtn.Enabled = true;
            GroupGridView.DataSource = Database.MetWorkspace.GroupManager.groups.Table;

            if (Database.MetWorkspace.GroupManager.groups.Table.Rows.Count > 0 &&
                Database.MetWorkspace.GroupManager.groups.Table.Rows[0]["id_group_h"] != DBNull.Value)
            {

                filterTable(Convert.ToInt32(Database.MetWorkspace.GroupManager.groups.Table.Rows[0]["id_group_h"]));
                AddChildBtn.Enabled = true;
            }
            else
            {
                filterTable(-1);
                AddChildBtn.Enabled = false;
                UpdateGroupBtn.Enabled = DeleteGroupBtn.Enabled = false;
            }
        }

        private void EditGroupTypes_Click(object sender, EventArgs e)
        {
            UserTypesEdit groupTypes = new UserTypesEdit();
            groupTypes.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void GroupGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeChildGroupForm form = new ChangeChildGroupForm();
            form.ShowDialog();
        }
    }
}
