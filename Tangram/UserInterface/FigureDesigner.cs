using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.Data;
using Tangram.GraphicsElements;

namespace Tangram.UserInterface
{
    public partial class FigureDesigner : Form
    {
        bool editMode = false;
        public Tangram.Data.DataModels.Figure currentFigure { get; private set; }

        public FigureDesigner()
        {
            InitializeComponent();
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.BIG_TRIANGLE, Color.Yellow, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.MID_TRIANGLE, Color.Violet, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.SMALL_TRIANGLE, Color.Green, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.RECT, Color.Red, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.PARALLELOGRAM, Color.Blue, new PointF(0, 0)));

            designerCanvas.AllowDrop = true;
            designerCanvas.DragEnter += Canvas_DragEnter;
            designerCanvas.DragDrop += Canvas_DragDrop;
            figureTypeCombo.DataSource = Database.Teacher_Workspace.figureGroups.Entities;
            figureTypeCombo.DisplayMember = "Name";
            figureTypeCombo.ValueMember = "Id";
        }

        public FigureDesigner(Tangram.Data.DataModels.Figure figure)
        {
            InitializeComponent();
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.BIG_TRIANGLE, Color.Yellow, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.MID_TRIANGLE, Color.Violet, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.SMALL_TRIANGLE, Color.Green, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.RECT, Color.Red, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.PARALLELOGRAM, Color.Blue, new PointF(0, 0)));

            designerCanvas.AllowDrop = true;
            designerCanvas.DragEnter += Canvas_DragEnter;
            designerCanvas.DragDrop += Canvas_DragDrop;
            designerCanvas.Init(figure.TangramElement.Figures.Cast<Figure>().ToList(), figure.TangramElement.FigureSize);
            FigureNameTB.Text = figure.FigureName;
            currentFigure = figure;
            figureTypeCombo.DataSource = Database.Teacher_Workspace.figureGroups.Entities;
            figureTypeCombo.DisplayMember = "Name";
            figureTypeCombo.ValueMember = "Id";
            figureTypeCombo.SelectedValue = figure.Group_id;
            //figureTypeCombo.SelectedValue = Database.Teacher_Workspace.figureGroups.Entities.Where(ent => ent.Id == figure.Group_id).First();
            editMode = true;
        }


            private void Canvas_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetType() == typeof(Figure))
            //{
                e.Effect = DragDropEffects.Copy;
            //}
            //else
            //{
            //    e.Effect = DragDropEffects.None;
            //}
        }

        private void Canvas_DragDrop(object sender, DragEventArgs e)
        {
           
            Figure fig = figureToolBox1.SelectedFigure.Clone();
             //PointF location = new PointF();
            //location.X = e.X - canvasPanel.Left - designerCanvas.Left;
            //location.Y= e.Y - canvasPanel.Top- designerCanvas.Top;
            //fig.Location = location;
            //fig.Location = new PointF(e.X - canvasPanel.Location.X, e.Y - canvasPanel.Location.Y);
            fig.Location = new PointF(e.X-this.Left-splitContainer1.Left-canvasPanel.Left-designerCanvas.Left, 
                                      e.Y- this.Top- splitContainer1.Top -canvasPanel.Top-designerCanvas.Top);
            designerCanvas.AddFigure(fig);

                    
        }

        private void FigureDesigner_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            if (FigureNameTB.Text == "")
            {
                MessageBox.Show("Введите название фигуры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Size size = new Size();
                List<Figure> f = designerCanvas.packFigures(out size);
                if (f.Count() == 0)
                {
                    MessageBox.Show("Не было выбрано ни одной фигуры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (editMode)
                    {
                        currentFigure.TangramElement.Figures = f.Cast<TangramFigure>().ToList();
                        currentFigure.TangramElement.FigureSize = size;
                        currentFigure.FigureName = FigureNameTB.Text.Trim();
                        currentFigure.Group_id = Convert.ToInt32(figureTypeCombo.SelectedValue);
                        if (Database.Teacher_Workspace.Figures.Update(currentFigure))
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        TangramElement element = new TangramElement(f.Cast<TangramFigure>().ToList(), size);
                        currentFigure = new Data.DataModels.Figure();
                        currentFigure.FigureName = FigureNameTB.Text.Trim();
                        currentFigure.Group_id = Convert.ToInt32(figureTypeCombo.SelectedValue);
                        currentFigure.User_id = Database.Teacher_Workspace.teacher.Id;
                        currentFigure.TangramElement = element;
                        if (Database.Teacher_Workspace.Figures.Add(currentFigure)!=-1)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                   
                    //using (FileStream file = new FileStream("figure.dat", FileMode.OpenOrCreate))
                    //{
                    //    byte[] data = TangramElement.Serialize(element);
                    //    file.Write(data, 0, data.Count());
                    //}
                   
                }
               
            }



        }

        private void FigureDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
            {
                DialogResult res = MessageBox.Show("Закрыть окно? Изменения не будут сохраненны", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
           
        }
    }
}
