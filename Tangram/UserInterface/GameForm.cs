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
        //холст для отображения фигуры
        private GraphicsElements.GameCanvas gameCanvas;

        private int score = 0;
        private int max_score = 0;

        //форма для выбора  баллов
        private ScoreSetter scoreSetter;

        Point point = new Point();
        //панель с фигурой
        PictureBox draggedFig;
        //показывает, находится ли панель с фигурой над холстом
        bool onCanvas = false;


        //конструктор формы
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
            gameCanvas.Size = figure.TangramElement.FigureSize;


            gameCanvas.BackColor = Color.White;

            ChildName.Text = child.FullName;

            this.DoubleBuffered = true;
           
        }




        //Обработчик выбора фигуры на панели фигур, добавляет панель с изображением фигуры на форму.
        private void FigureSelected(PictureBox box, Point location)
        {
            draggedFig = box;
            Point point = PointToClient(Cursor.Position);
            box.Left = (point.X - location.X);
            box.Top = (point.Y - location.Y);
            this.point = location;

            draggedFig.Region = new Region(figureToolBox1.SelectedFigure.Path);


            this.Controls.Add(draggedFig);
            draggedFig.BringToFront();
            draggedFig.BackColor = Color.White;
            ((Bitmap)draggedFig.Image).MakeTransparent();
            draggedFig.MouseMove += DraggedFig_Move;
            draggedFig.MouseUp += DraggedFig_MouseUp;
            draggedFig.MouseLeave += DraggedFig_MouseLeave;
            draggedFig.Focus();
            draggedFig.Select();
        }

        //Обработчик перемещения панели с фигурой.
        private void DraggedFig_Move(object sender, MouseEventArgs e)
        {

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

        //Обработчик выхода курсора мыши за панель с фигурой.
        private void DraggedFig_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            Point point = PointToClient(Cursor.Position);
            pictureBox.Left = (point.X - this.point.X);
            pictureBox.Top = (point.Y - this.point.Y);
            //this.point = point;

            
            //figureToolBox1.Enabled = true;

            //Controls.Remove(sender as Control);
            //pictureBox.Dispose();
            //pictureBox = null;
        }

        //Обработчик отпускания клавиши мыши над панелью с фигурой.
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

            if (figureToolBox1.FigureCount == 0)
            {
                SuccesForm form = new SuccesForm();
                form.ShowDialog();
                DialogResult res = scoreSetter.ShowDialog();
                if (res == DialogResult.OK)
                {
                    this.DialogResult = res;
                    this.Close();
                }
            }
        }

        //обработчик закрытия формы
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
            {
                DialogResult res = MessageBox.Show("Сохранить результаты игры?","Закрытие",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
                switch (res) {
                    case DialogResult.Yes:
                        DialogResult scoreRes = scoreSetter.ShowDialog();
                        e.Cancel = scoreRes != DialogResult.OK;
                        break;
                    case DialogResult.No:
                        e.Cancel = false;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }

        }

        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
