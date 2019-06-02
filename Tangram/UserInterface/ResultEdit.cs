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
    public partial class ResultEdit : Form
    {
        //текущий результат
        private Result currentResult;

        //конструктор формы
        public ResultEdit(Result res)
        {
            InitializeComponent();

            currentResult = res;
            childCombo.DataSource = Database.Teacher_Workspace.children;
            childCombo.ValueMember = "Id";
            childCombo.DisplayMember = "FullName";

            childCombo.SelectedValue = res.ChildId;

            ChildScoreUpDown.Value = res.Score;
            difficultyCombo.SelectedIndex = (int)(res.DifficultyType);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Обработчик нажатия на кнопку «Сохранить», сохраняет результаты игр
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            currentResult.ChildId = Convert.ToInt32(childCombo.SelectedValue);
            currentResult.DifficultyType = (Result.DifficultyTypes)difficultyCombo.SelectedIndex;
            currentResult.Score = (int)ChildScoreUpDown.Value;

            if (Database.GameRepository.Update(currentResult))
            {
                this.Close();
            }

        }

        //Обработчик нажатия на кнопку «Отмена», закрывает форму
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
