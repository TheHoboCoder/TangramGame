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
    public partial class GameForm : Form
    {
        private GraphicsElements.GameCanvas gameCanvas;

        private int score = 0;
        private int max_score = 0;

        private Child child;
        private Figure fig;
        private Result.DifficultyTypes difficulty;
        private int classId;

        public GameForm(Figure figure, Child child, Result.DifficultyTypes difficulty, int classId)
        {
            InitializeComponent();

            this.child = child;
            this.fig = figure;
            this.difficulty = difficulty;
            this.classId = classId;

            Random randomizer = new Random();

            List<Tangram.GraphicsElements.TangramFigure> subfigures = figure.TangramElement.Figures.Select(f=>(Tangram.GraphicsElements.TangramFigure)f.Clone()).ToList();
            score = max_score = subfigures.Count();
            while (subfigures.Count() != 0)
            {
                int index = randomizer.Next(0, subfigures.Count());
                Tangram.GraphicsElements.TangramFigure selected = subfigures[index];
                figureToolBox1.Add(selected);
                subfigures.Remove(selected);
            }

             gameCanvas = new GraphicsElements.GameCanvas(figure.TangramElement, difficulty);
            canvasPanel.Controls.Add(gameCanvas);
            gameCanvas.BackColor = Color.White;
            gameCanvas.AllowDrop = true;
            gameCanvas.DragDrop += Drag_drop;
            gameCanvas.DragEnter += Canvas_DragEnter;
            this.DoubleBuffered = true;
        }

        private void Drag_drop(object sender, DragEventArgs e)
        {
            GraphicsElements.Figure fig = figureToolBox1.SelectedFigure;
            GraphicsElements.Figure fig2 = fig.Clone();
            Point point = gameCanvas.PointToClient(new Point(e.X, e.Y));
            //RectangleF bounds = fig2.Path.GetBounds();
            fig2.Location = point;
            if (gameCanvas.PlaceFigure((GraphicsElements.TangramFigure)fig2))
            {
                figureToolBox1.Remove(fig);
                fig.Dispose();
                if(figureToolBox1.FigureCount == 0)
                {
                    MessageBox.Show("ЕЕЕЕ, я победил, еее", "Перемога", MessageBoxButtons.OK, MessageBoxIcon.None);
                    float percentage = ((float)score * 100) / (float)max_score;
                    int normalizedScore = (int)Math.Round(percentage);

                    if(Database.Teacher_Workspace.gameRepository.Add(new Result() {
                        Score = normalizedScore,
                        ChildId = child.Id,
                        FigureId = this.fig.Id,
                        DifficultyType = this.difficulty,
                        GroupId = child.GroupId,
                        ClassId = classId
                    }) != -1)
                    {
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                    }

                }
            }
            else
            {
                if (score != 0) score--;
            }

        }

        private void Canvas_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
            {
                DialogResult res = MessageBox.Show("Игра не была закончена. Сохранить результат игры (0 баллов)?", "Закрытие", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (res)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        e.Cancel = false;
                        Database.Teacher_Workspace.gameRepository.Add(new Result()
                        {
                            Score = 0,
                            ChildId = child.Id,
                            FigureId = this.fig.Id,
                            DifficultyType = this.difficulty,
                            GroupId = child.GroupId,
                            ClassId = classId
                        });
                        break;
                    case DialogResult.No:
                        e.Cancel = false;
                        break;
                }
            }
          

        }
    }
}
