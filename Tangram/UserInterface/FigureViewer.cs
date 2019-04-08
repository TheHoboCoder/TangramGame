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
    public partial class FigureViewer : Form
    {
        BindingSource source;

        public FigureViewer()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void AddFigure_Click(object sender, EventArgs e)
        {
            FigureDesigner form3 = new FigureDesigner();
            form3.Show();
        }

        private void FigureViewer_Load(object sender, EventArgs e)
        {
            source = new BindingSource();
            source.DataSource = Database.Teacher_Workspace.figureGroups.Entities;
            GroupList.DataSource = source;
            GroupList.DisplayMember = "Name";
            GroupList.ValueMember = "Id";

            Database.Teacher_Workspace.InitListView(figureView);
        }

        private void DeleteGroup_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Удалить групу?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes) {
                Database.Teacher_Workspace.figureGroups.Delete(Convert.ToInt32(GroupList.SelectedValue));
            }
            source.ResetBindings(false);
            //GroupList.DataSource = Database.Teacher_Workspace.figureGroups.Entities;
            //GroupList.
        }

        private void AddGroup_Click(object sender, EventArgs e)
        {
            FigureGroupsEdit groupsEdit = new FigureGroupsEdit();
            groupsEdit.ShowDialog();
            source.ResetBindings(false);
            //GroupList.DataSource = null;
            //GroupList.DataSource = Database.Teacher_Workspace.figureGroups.Entities;
        }

        private void EditGroup_Click(object sender, EventArgs e)
        {
            FigureGroupsEdit groupsEdit = new FigureGroupsEdit(GroupList.SelectedItem as FigureGroup);
            groupsEdit.ShowDialog();
            source.ResetBindings(false);
            //GroupList.DataSource = null;
            //GroupList.DataSource = Database.Teacher_Workspace.figureGroups.Entities;
        }
    }
}
