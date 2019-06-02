using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.Data.DataModels;
using Tangram.Data;

namespace Tangram.UserInterface
{
    public partial class ScoreSetter : Form
    {

        private Child child; //ребенок
        private Figure fig; //фигура
        private Result.DifficultyTypes difficulty;//уровень сложности
        private int classId; // идетификатор занятия

        public ScoreSetter(Figure figure, Child child, Result.DifficultyTypes difficulty, int classId)
        {
            InitializeComponent();

            this.child = child;
            this.fig = figure;
            this.difficulty = difficulty;
            this.classId = classId;
            this.ChildNameL.Text = child.FullName;
        }

        //Обработчик нажатия на кнопку "Отмена", закрывает форму
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        //Обработчик нажатия на кнопку "Сохранить", сохраняет результаты игры и закрывает форму
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (Database.GameRepository.Add(new Result()
            {
                Score = (int)ChildScoreUpDown.Value,
                ChildId = child.Id,
                FigureId = this.fig.Id,
                DifficultyType = this.difficulty,
                GroupId = Database.Teacher_Workspace.TeacherGroup,
                ClassId = classId
            }) != -1)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
