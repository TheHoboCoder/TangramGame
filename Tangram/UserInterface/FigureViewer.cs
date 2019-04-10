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
    public partial class FigureViewer : Form
    {
        BindingSource source;
        bool filteredGroup = false;
        bool mode;
        public Figure SelectedFigure { get; private set; }

        public FigureViewer(bool selectMode)
        {
            InitializeComponent();
            mode = selectMode;
            hint.Visible = selectMode;
            if(selectMode)
               this.figureView.DoubleClick += new System.EventHandler(this.figureView_DoubleClick);

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void AddFigure_Click(object sender, EventArgs e)
        {
            FigureDesigner designer= new FigureDesigner();
            designer.ShowDialog();

            if (designer.currentFigure != null)
            {
                Database.Teacher_Workspace.ViewAdapter.AddFigure(designer.currentFigure);
            }
           
            
            designer.Dispose();
        }

        private void FigureViewer_Load(object sender, EventArgs e)
        {
            source = new BindingSource();
            source.DataSource = Database.Teacher_Workspace.figureGroups.Entities;
            GroupList.DataSource = source;
            GroupList.DisplayMember = "Name";
            GroupList.ValueMember = "Id";
            userFilterCombo.SelectedIndex = 0;
            Database.Teacher_Workspace.InitListView(figureView);
            this.GroupList.SelectedValueChanged += new System.EventHandler(this.GroupList_SelectedValueChanged);
        }

        private void DeleteGroup_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Удалить групу?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes) {
                int deleteid = Convert.ToInt32(GroupList.SelectedValue);
                if (Database.Teacher_Workspace.figureGroups.Delete(Convert.ToInt32(GroupList.SelectedValue)))
                {
                    Database.Teacher_Workspace.ViewAdapter.RemoveGroup(Database.Teacher_Workspace.ViewAdapter.GetGroup(deleteid));
                }
              
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
            Database.Teacher_Workspace.ViewAdapter.AddGroup(groupsEdit.group);
            //GroupList.DataSource = null;
            //GroupList.DataSource = Database.Teacher_Workspace.figureGroups.Entities;
        }

        private void EditGroup_Click(object sender, EventArgs e)
        {
            FigureGroupsEdit groupsEdit = new FigureGroupsEdit(GroupList.SelectedItem as FigureGroup);
            groupsEdit.ShowDialog();
            source.ResetBindings(false);
            Database.Teacher_Workspace.ViewAdapter.GetGroup(groupsEdit.group.Id).Header = groupsEdit.group.Name;
            //GroupList.DataSource = null;
            //GroupList.DataSource = Database.Teacher_Workspace.figureGroups.Entities;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (figureView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = figureView.SelectedItems[0];
                if (Convert.ToInt32(selectedItem.Tag) != Database.Teacher_Workspace.teacher.Id)
                {
                    MessageBox.Show("Вы не являетесь создателем этой фигуры?", "Невозможно удалить фигуру", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult res = MessageBox.Show("Удалить фигуру?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(res == DialogResult.Yes)
                    {
                        int index = Convert.ToInt32(selectedItem.Name.Substring(selectedItem.Name.IndexOf('_') + 1));
                        Database.Teacher_Workspace.Figures.Delete(index);
                        Database.Teacher_Workspace.ViewAdapter.RemoveItem(selectedItem);
                    }
                }
            }
         

        }

        private void editFigure_Click(object sender, EventArgs e)
        {
            if (figureView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = figureView.SelectedItems[0];
                if (Convert.ToInt32(selectedItem.Tag) != Database.Teacher_Workspace.teacher.Id)
                {
                    MessageBox.Show("Вы не являетесь создателем этой фигуры.", "Невозможно изменить фигуру", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                else
                {
                    int index = Convert.ToInt32(selectedItem.Name.Substring(selectedItem.Name.IndexOf('_') + 1));
                    Figure f = Database.Teacher_Workspace.Figures.Entities.Where(ent => ent.Id == index).First();
                    FigureDesigner designer = new FigureDesigner(f);
                    designer.ShowDialog();
                    if (designer.currentFigure != null)
                    {
                        Database.Teacher_Workspace.ViewAdapter.UpdateFigure(designer.currentFigure);
                    }
                       
                    designer.Dispose();
                }
            }
        }

        private void userFilterCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (userFilterCombo.SelectedIndex) {
                case 0:
                    if (!filteredGroup)
                    {
                        Database.Teacher_Workspace.ViewAdapter?.ShowAll();
                    }
                    else
                    {
                        Database.Teacher_Workspace.ViewAdapter.Filter(Convert.ToInt32(GroupList.SelectedValue));
                    }
                    break;
                case 1:
                    if (filteredGroup)
                    {
                        Database.Teacher_Workspace.ViewAdapter.Filter(Convert.ToInt32(GroupList.SelectedValue), false);
                    }
                    else
                    {
                        Database.Teacher_Workspace.ViewAdapter.Filter(false);
                    }
                    break;
                case 2:
                    if (filteredGroup)
                    {
                        Database.Teacher_Workspace.ViewAdapter.Filter(Convert.ToInt32(GroupList.SelectedValue), true);
                    }
                    else
                    {
                        Database.Teacher_Workspace.ViewAdapter.Filter(true);
                    }
                  
                    break;
            }
        }

        private void GroupList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (GroupList.SelectedValue != null)
            {
                filteredGroup = true;
                switch (userFilterCombo.SelectedIndex)
                {
                    case 0:
                        if (!filteredGroup)
                        {
                            Database.Teacher_Workspace.ViewAdapter?.ShowAll();
                        }
                        else
                        {
                            Database.Teacher_Workspace.ViewAdapter.Filter(Convert.ToInt32(GroupList.SelectedValue));
                        }
                        break;
                    case 1:
                        if (filteredGroup)
                        {
                            Database.Teacher_Workspace.ViewAdapter.Filter(Convert.ToInt32(GroupList.SelectedValue), false);
                        }
                        else
                        {
                            Database.Teacher_Workspace.ViewAdapter.Filter(false);
                        }
                        break;
                    case 2:
                        if (filteredGroup)
                        {
                            Database.Teacher_Workspace.ViewAdapter.Filter(Convert.ToInt32(GroupList.SelectedValue), true);
                        }
                        else
                        {
                            Database.Teacher_Workspace.ViewAdapter.Filter(true);
                        }

                        break;
                }
            }
        }

        private void showAllBtn_Click(object sender, EventArgs e)
        {
            filteredGroup = false;
            userFilterCombo.SelectedIndex = 0;
            Database.Teacher_Workspace.ViewAdapter.ShowAll();
        }

        private void figureView_DoubleClick(object sender, EventArgs e)
        {
            if (figureView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = figureView.SelectedItems[0];
                int index = Convert.ToInt32(selectedItem.Name.Substring(selectedItem.Name.IndexOf('_') + 1));
                SelectedFigure= Database.Teacher_Workspace.Figures.Entities.Where(ent => ent.Id == index).First();
                this.Close();
            }
        }

        private void FigureViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(mode  && SelectedFigure == null)
            {
                MessageBox.Show("Выберите фигуру", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
    }
}
