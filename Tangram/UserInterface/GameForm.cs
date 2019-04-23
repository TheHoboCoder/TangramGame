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

        private ScoreSetter scoreSetter;

        Point point = new Point();
        PictureBox draggedFig;
        bool onCanvas = false;

        public GameForm(Figure figure, Child child, Result.DifficultyTypes difficulty, int classId)
        {
            InitializeComponent();

            scoreSetter = new ScoreSetter(figure, child, difficulty, classId);


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

            figureToolBox1.OnFigureSelect += FigureSelected;

            gameCanvas = new GraphicsElements.GameCanvas(figure.TangramElement, difficulty);

            canvasPanel.Controls.Add(gameCanvas);
            gameCanvas.BackColor = Color.White;

            ChildName.Text = child.FullName;

            this.DoubleBuffered = true;
           
        }


        private void FigureSelected(PictureBox box, Point location)
        {
            draggedFig = box;
            Point point = PointToClient(Cursor.Position);
            box.Left = (point.X- location.X);
            box.Top = (point.Y- location.Y);
            this.point = location;
            
            this.Controls.Add(draggedFig);
            draggedFig.BringToFront();
            draggedFig.BackColor = Color.Transparent;
            draggedFig.MouseMove += DraggedFig_Move;
            draggedFig.MouseUp += DraggedFig_MouseUp;
            draggedFig.Focus();
            draggedFig.Select();
        }

        private void DraggedFig_Move(object sender, MouseEventArgs e){

            PictureBox pictureBox = sender as PictureBox;
            if (e.Button == MouseButtons.Left)
            {
                draggedFig.Left += e.X - point.X;
                draggedFig.Top += e.Y - point.Y;
                Point currentLocation = gameCanvas.PointToClient(Cursor.Position);
                if (!gameCanvas.Bounds.Contains(currentLocation))
                {
                    pictureBox.Cursor = Cursors.No;
                    onCanvas = false;
                }
                else
                {
                    pictureBox.Cursor = Cursors.Default;
                    onCanvas = true;
                }
            }
        }

        private void DraggedFig_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            if (onCanvas)
            {
                GraphicsElements.Figure fig = figureToolBox1.SelectedFigure.Clone();

                Point point = gameCanvas.PointToClient(Cursor.Position);
                point.X = point.X - this.point.X;
                point.Y = point.Y - this.point.Y;

                fig.Translate(point.X, point.Y);


                if (gameCanvas.PlaceFigure((GraphicsElements.TangramFigure)fig))
                {
                    figureToolBox1.Remove(figureToolBox1.SelectedFigure);
                    if (figureToolBox1.FigureCount == 0)
                    {
                        MessageBox.Show("Ураа", "Победа", MessageBoxButtons.OK, MessageBoxIcon.None);
                        DialogResult res = scoreSetter.ShowDialog();
                        if(res == DialogResult.OK)
                        {
                            this.DialogResult = res;
                            this.Close();
                        }
                    }
                }
                else
                {
                    if (score != 0) score--;
                }


            }

            figureToolBox1.Enabled = true;

            Controls.Remove(sender as Control);
            pictureBox.Dispose();
            pictureBox = null;
        }


        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
            {
                DialogResult res = scoreSetter.ShowDialog();
                e.Cancel = res != DialogResult.OK;
            }

        }
    }
}
