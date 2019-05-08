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
    public partial class ChangeChildGroupForm : Form
    {
        List<int> startGroupIndexies = new List<int>();
        List<Child_Journal> startChilds = new List<Child_Journal>();


        List<int> endGroupIndexies = new List<int>();
        List<Child_Journal> endChilds = new List<Child_Journal>();

        //List<int> endstartChildIndexies;
        //List<int> endstartSubGroups;

        //DataRow[] startGroupRows;
        //DataRow[] startGroupChilds;
        //DataRow[] endGroupChilds;
        //DataRow[] endGroupRows;

        public ChangeChildGroupForm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChangeChildGroupForm_Load(object sender, EventArgs e)
        {
            DateTime currentTime =  DateTime.Now;
            startYear.Value = currentTime.Year - 1;
            endYear.Value = currentTime.Year;

            UpdateList((int)startYear.Value, ChildList, startGroupCombo, startGroupIndexies, startChilds);
            UpdateList((int)endYear.Value, endChildList, endGroupCombo, endGroupIndexies, endChilds);

            endYear.ValueChanged += EndYearChanged;
            startYear.ValueChanged += StartYearChanged;
        }


        public void EnableControls(ListBox list, ComboBox combo,bool enabled)
        {
            combo.Enabled = enabled;
            list.Enabled = enabled;
            AddToGroupBtn.Enabled = enabled;
            RemoveFromBtn.Enabled = enabled;
        }

        private void UpdateList(int year, ListBox list, ComboBox combo, List<int> groups, List<Child_Journal> childs)
        {
            combo.Items.Clear();
            groups.Clear();

            Database.MetWorkspace.GroupManager.groups.FilterByYear(year);
            DataRow[] GroupRows = Database.MetWorkspace.GroupManager.groups.Table.Select("id_user is not null");

            if (GroupRows.Count() == 0)
            {
                EnableControls(list, combo, false);
            }
            else
            {
              
                foreach (DataRow row in GroupRows)
                {
                    //combo.Items.Add(row);
                    combo.Items.Add(row["group_name"]);
                    groups.Add(Convert.ToInt32(row["id_group_h"]));
                }
                combo.SelectedIndex = 0;
                UpdateChilds(childs, list, groups[0]);
                EnableControls(list, combo, true);
            }
        }

        public void UpdateChilds(List<Child_Journal> childs, ListBox list, int groupId)
        {
            childs.Clear();
            list.Items.Clear();

            //var children  = from child in Database.MetWorkspace.ChildManager.childJournal.Entities
            //         where child.GroupHistoryId == groupId
            //         select child;

            //foreach(var child in children)
            //{
            //    list.Items.Add(Database.MetWorkspace.ChildManager.children.Table.Select("id_child = '" + child.ChildId+ "'")[0]["childName"]);
            //    childs.Add(child);
            //}

            DataRow[] childRows = Database.MetWorkspace.ChildManager.children.Table.Select("id_group_h = '" + groupId + "'");
            foreach (DataRow row in childRows)
            {
                list.Items.Add(row["childName"]);

                Child_Journal journal = new Child_Journal();
                journal.Id = Convert.ToInt32(row["id_journal"]);
                journal.SubGroup = Convert.ToInt32(row["subGroup"]);
                journal.ChildId = Convert.ToInt32(row["id_child"]);
                journal.GroupHistoryId = Convert.ToInt32(row["id_group_h"]);

                childs.Add(journal);
            }
        }

        private void ChangeGroup(List<Child_Journal> selectedChilds, int groupId, List<Child_Journal>  childs,ListBox list)
        {
            if (childs.Count() != 0)
            {
                var original = selectedChilds.Where(row2 => childs.Any(row1 => row2.ChildId != row1.ChildId));

                foreach (Child_Journal child in original)
                {
                    Child_Journal newChild = new Child_Journal();
                    newChild.ChildId = child.ChildId;
                    newChild.SubGroup = child.SubGroup;
                    newChild.GroupHistoryId = groupId;

                    Database.MetWorkspace.ChildManager.childJournal.Add(newChild);
                    

                }
            }
            else
            {
                foreach (Child_Journal child in selectedChilds)
                {
                    Child_Journal newChild = new Child_Journal();
                    newChild.ChildId = child.ChildId;
                    newChild.SubGroup = child.SubGroup;
                    newChild.GroupHistoryId = groupId;
                    Database.MetWorkspace.ChildManager.childJournal.Add(newChild);

                }
            }


           
            Database.MetWorkspace.ChildManager.children.GetData();

        }



        private void AddToGroupBtn_Click(object sender, EventArgs e)
        {
            List<Child_Journal> childs= new List<Child_Journal>();
            foreach(int index in ChildList.SelectedIndices)
            {
                childs.Add(startChilds[index]);
            }
            int groupId = endGroupIndexies[endGroupCombo.SelectedIndex];
            ChangeGroup(childs, groupId, endChilds,endChildList);

            UpdateList((int)endYear.Value, endChildList, endGroupCombo, endGroupIndexies, endChilds);


        }

        private void RemoveFromBtn_Click(object sender, EventArgs e)
        {
            List<Child_Journal> childs = new List<Child_Journal>();
            foreach (int index in endChildList.SelectedIndices)
            {
                childs.Add(endChilds[index]);
            }
            int groupId = startGroupIndexies[startGroupCombo.SelectedIndex];
            ChangeGroup(childs, groupId, startChilds, ChildList);
            UpdateList((int)startYear.Value, ChildList, startGroupCombo, startGroupIndexies, startChilds);
        }

        private void SelectAllStart_Click(object sender, EventArgs e)
        {
            ChildList.BeginUpdate();
            for (int i = 0; i < ChildList.Items.Count; i++)
            {
                ChildList.SetSelected(i, true);
            }
            ChildList.EndUpdate();
        }

        private void SelectAllEnd_Click(object sender, EventArgs e)
        {
            endChildList.BeginUpdate();
            for (int i = 0; i < endChildList.Items.Count; i++)
            {
                endChildList.SetSelected(i, true);
            }
            endChildList.EndUpdate();
        }

        private void EndYearChanged(object sender, EventArgs e)
        {
            UpdateList((int)endYear.Value, endChildList, endGroupCombo, endGroupIndexies, endChilds);
        }

        private void StartYearChanged(object sender, EventArgs e)
        {
            UpdateList((int)startYear.Value, ChildList, startGroupCombo, startGroupIndexies, startChilds);
        }

        private void startGroupCombo_DropDownClosed(object sender, EventArgs e)
        {
            UpdateChilds(startChilds, ChildList, startGroupIndexies[startGroupCombo.SelectedIndex]);
        }

        private void endGroupCombo_DropDownClosed(object sender, EventArgs e)
        {
            UpdateChilds(endChilds, endChildList, endGroupIndexies[endGroupCombo.SelectedIndex]);
        }

        private void RemoveFromEndGroup_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Исключить выбранных детей из группы?","Предупреждение",MessageBoxButtons.YesNo, MessageBoxIcon.Warning)){

                foreach (int index in endChildList.SelectedIndices)
                {
                    if (Database.MetWorkspace.ChildManager.childJournal.Entities.Where(c=>c.ChildId == endChilds[index].ChildId).Count() != 1)
                    {
                        Database.MetWorkspace.ChildManager.childJournal.Delete(endChilds[index].Id);
                    }
                    else
                    {
                        MessageBox.Show("Невозможно исключить ребенка из группы", "Невозможно исключить", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                   
                }
                Database.MetWorkspace.ChildManager.children.GetData();
                UpdateChilds(endChilds, endChildList, endGroupIndexies[endGroupCombo.SelectedIndex]);
                Database.MetWorkspace.GroupManager.groups.FilterByYear((int)endYear.Value);

            }
        }

        private void RemoveFromStartGroup_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Исключить выбранных детей из группы?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {

                foreach (int index in ChildList.SelectedIndices)
                {
                    if (Database.MetWorkspace.ChildManager.childJournal.Entities.Where(c => c.ChildId == startChilds[index].ChildId).Count() != 1)
                    {

                        Database.MetWorkspace.ChildManager.childJournal.Delete(startChilds[index].Id);
                    }
                    else
                    {
                        MessageBox.Show("Невозможно исключить ребенка из группы", "Невозможно исключить", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
                Database.MetWorkspace.ChildManager.children.GetData();
                Database.MetWorkspace.GroupManager.groups.FilterByYear((int)startYear.Value);
                UpdateChilds(startChilds, ChildList, startGroupIndexies[startGroupCombo.SelectedIndex]);
            }
        }

        private void startYear_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
