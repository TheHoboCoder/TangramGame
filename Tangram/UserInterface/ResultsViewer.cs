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

namespace Tangram.UserInterface
{
    public partial class ResultsViewer : UserControl
    {
        bool timeSelected = false;

        private G

        public ResultsViewer()
        {
            InitializeComponent();
        }


        private void ResultsViewer_Load(object sender, EventArgs e)
        {
           
            

           
            

            periodCombo.SelectedIndex = 0;
            Database.MetWorkspace.Results.GetInfo();
            if (Database.userRepository.currentUser.UserType == Data.DataModels.User.UserTypes.VOSP)
            {
                teacherFilterCombo.DisplayMember = "Initials";
                teacherFilterCombo.ValueMember = "Id";
                teacherFilterCombo.SelectedItem = Database.userRepository.currentUser;
                teacherFilterCombo.Enabled = false;
                teacherCheckBox.Checked = true;
                teacherCheckBox.Enabled = false;
                Database.Teacher_Workspace.gameRepository.FilterByTeacherId(Convert.ToInt32(teacherFilterCombo.SelectedValue));
                ResultGridView.DataSource = Database.MetWorkspace.Results.filteredTable;

                childFilterCombo.DisplayMember = "FullName";
                childFilterCombo.ValueMember = "Id";

                childFilterCombo.DataSource = Database.Teacher_Workspace.children;

            }
            else
            {
                Database.userRepository.FilterUsersByType(Data.DataModels.User.UserTypes.VOSP);
                teacherFilterCombo.DisplayMember = "usersInitials";
                teacherFilterCombo.ValueMember = "id_user";
                teacherFilterCombo.DataSource = Database.userRepository.filteredTable;
                childFilterCombo.DisplayMember = "childName";
                childFilterCombo.ValueMember = "id_child";
                childFilterCombo.DataSource = Database.MetWorkspace.ChildManager.children.Table;
                ResultGridView.DataSource = Database.MetWorkspace.Results.Table;
            }
        }

        private void ShowAllBtn_Click(object sender, EventArgs e)
        {
            if (Database.userRepository.currentUser.UserType == Data.DataModels.User.UserTypes.VOSP)
            {
                Database.MetWorkspace.Results.FilterByTeacherId(Convert.ToInt32(teacherFilterCombo.SelectedValue));
                ResultGridView.DataSource = Database.MetWorkspace.Results.filteredTable;
            }
            else
            {
                ResultGridView.DataSource = Database.MetWorkspace.Results.Table;
            }
                
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            endDate.MinDate = startDate.Value;
        }

        private void periodCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(periodCombo.SelectedIndex){

                case 0:
                    timeSelected = false;
                    startDate.Enabled = endDate.Enabled = false;
                    break;
                case 1:
                    timeSelected = true;
                    endDate.Value = DateTime.Now;
                    startDate.Value = new DateTime(endDate.Value.Year, endDate.Value.Month, 1);
                    startDate.Enabled = endDate.Enabled = false;
                    break;
                case 2:
                    timeSelected = true;
                    DateTime cur = DateTime.Now;
                    DateTime month = new DateTime(cur.Year, cur.Month, 1);
                    startDate.Value = month.AddMonths(-1);
                    endDate.Value = month.AddDays(-1);
                    startDate.Enabled = endDate.Enabled = false;
                    break;
                case 3:
                    timeSelected = true;
                    startDate.Value = GroupsRepository.GetWorkYearStart(GroupsRepository.GetWorkYear(DateTime.Now));
                    endDate.Value = GroupsRepository.GetWorkYearEnd(GroupsRepository.GetWorkYear(DateTime.Now));
                    startDate.Enabled = endDate.Enabled = false;
                    break;
                case 4:
                    timeSelected = true;
                    startDate.Enabled = endDate.Enabled = true;
                    break;

            }
        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            if(childCheckBox.Checked && teacherCheckBox.Checked && timeSelected)
            {
                Database.MetWorkspace.Results.Filter(Convert.ToInt32(childFilterCombo.SelectedValue), Convert.ToInt32(teacherFilterCombo.SelectedValue), startDate.Value, endDate.Value);
            }

            if(childCheckBox.Checked && teacherCheckBox.Checked && !timeSelected)
            {
                Database.MetWorkspace.Results.Filter(Convert.ToInt32(childFilterCombo.SelectedValue), Convert.ToInt32(teacherFilterCombo.SelectedValue));
            }

            if (!childCheckBox.Checked && teacherCheckBox.Checked && timeSelected)
            {
                Database.MetWorkspace.Results.FilterTeacher(Convert.ToInt32(teacherFilterCombo.SelectedValue), startDate.Value, endDate.Value);
            }

            if (childCheckBox.Checked && !teacherCheckBox.Checked && timeSelected)
            {
                Database.MetWorkspace.Results.FilterChild(Convert.ToInt32(childFilterCombo.SelectedValue), startDate.Value, endDate.Value);
            }

            if (childCheckBox.Checked && !teacherCheckBox.Checked && !timeSelected)
            {
                Database.MetWorkspace.Results.FilterByChildId(Convert.ToInt32(childFilterCombo.SelectedValue));
            }

            if (!childCheckBox.Checked && teacherCheckBox.Checked && !timeSelected)
            {
                Database.MetWorkspace.Results.FilterByTeacherId(Convert.ToInt32(teacherFilterCombo.SelectedValue));
            }

            if (!childCheckBox.Checked && !teacherCheckBox.Checked && timeSelected)
            {
                Database.MetWorkspace.Results.FilterByPeriod(startDate.Value, endDate.Value);
            }
            ResultGridView.DataSource = Database.MetWorkspace.Results.filteredTable;

        }
    }
}
