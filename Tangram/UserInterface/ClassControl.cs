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
    public partial class ClassControl : Form
    {
        bool figureSelected = false;
        private Figure current;

        public ClassControl()
        {
            InitializeComponent();
        }

        private void ClassControl_Load(object sender, EventArgs e)
        {
            difficultyCombo.SelectedIndex = 0;

            childCombo.DataSource = Database.Teacher_Workspace.childrenInGroup;
            childCombo.DisplayMember = "FullName";
            childCombo.ValueMember = "Id";
            childCombo.SelectedIndex = 0;
            figurePicture.Width = figurePicture.Width = 250;
        }

        //Обработчик нажатия на кнопку "Завершить занятие"
        //закрывает данную форму и открывает главную форму приложения
        private void endClass_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Завершить занятие?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Database.Teacher_Workspace.EndClass();
                MainForm form = new MainForm();
                this.DialogResult = DialogResult.OK;
                form.Show();
                this.Close();
                
            }
            
        }

        //Обработчик нажатия на кнопку "Начать игру"
        //Если фигура выбрана, то открывает форму с игрой
        private void StartGame_Click(object sender, EventArgs e)
        {
            if (!figureSelected)
            {
                MessageBox.Show("Выберите фигуру", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Result.DifficultyTypes difficulty = (Result.DifficultyTypes)difficultyCombo.SelectedIndex;
                GameForm form = new GameForm(current, (Child)childCombo.SelectedItem, difficulty, Database.Teacher_Workspace.CurrentClassId);
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        //Обработчик нажатия на кнопку "Выбор фигуры"
        //Открывает форму для просмотра фигур
        private void selectFigure_Click(object sender, EventArgs e)
        {
            FigureViewer viewer = new FigureViewer(true);
            viewer.ShowDialog();
            current = viewer.SelectedFigure;
            if (figurePicture.Image != null) figurePicture.Image.Dispose();
            figurePicture.Image = current.TangramElement.getIcon(panel1.Width,Color.White);
            figureSelected = true;
        }

        //событие при закрытии формы
        private void ClassControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
            {
                if (MessageBox.Show("Завершить занятие?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    MainForm form = new MainForm();
                    form.Show();
                    e.Cancel = false;
                    this.Dispose();

                }
                else
                {
                    e.Cancel = true;
                }
            }
          
        }
    }
}
