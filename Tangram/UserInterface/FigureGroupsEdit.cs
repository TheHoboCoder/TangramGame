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
    public partial class FigureGroupsEdit : Form
    {
        private bool editMode= false;
        public FigureGroup group { get; private set;  }

        public FigureGroupsEdit()
        {
            InitializeComponent();
            editMode = false;
        }

        public FigureGroupsEdit(FigureGroup currentGroup)
        {
            InitializeComponent();
            group = currentGroup;
            LevelTB.Text = currentGroup.Name;

            if (currentGroup.Comment != null)
            {
                CommentTB.Text = currentGroup.Comment;
            }
            editMode = true;
        }


        //Обработчик нажатия на кнопку «Сохранить», в зависимости от режима сохраняет либо изменяет группу фигур
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (LevelTB.Text == "")
            {
                MessageBox.Show( "Заполните поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (editMode)
                {
                    group.Name = LevelTB.Text;
                    group.Comment = CommentTB.Text;
                    if (Database.Teacher_Workspace.figureGroups.Update(group))
                    {
                        this.Close();
                    }
                }
                else
                {
                    group = new FigureGroup()
                    {
                        Name = LevelTB.Text,
                        Comment = CommentTB.Text
                    };
                    if (Database.Teacher_Workspace.figureGroups.Add(group) != -1)
                    {
                        this.Close();
                    }

                }
            }
        }

        //Обработчик нажатия на кнопку
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
