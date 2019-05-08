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
        public Tangram.Data.DataModels.FigureGroup AddedGroup { get; private set; }


        Point point = new Point();
        PictureBox draggedFig;
        bool onCanvas = false;

        public FigureDesigner()
        {
            InitializeComponent();
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.BIG_TRIANGLE, Color.Blue, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.MID_TRIANGLE, Color.Blue, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.SMALL_TRIANGLE, Color.Blue, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.RECT, Color.Blue, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.PARALLELOGRAM, Color.Blue, new PointF(0, 0)));

            //designerCanvas.AllowDrop = true;
            //designerCanvas.DragEnter += Canvas_DragEnter;
            //designerCanvas.DragDrop += Canvas_DragDrop;
            figureToolBox1.OnFigureSelect += FigureSelected;
            figureTypeCombo.DataSource = Database.Teacher_Workspace.figureGroups.Entities;
            figureTypeCombo.DisplayMember = "Name";
            figureTypeCombo.ValueMember = "Id";
        }

        public FigureDesigner(Tangram.Data.DataModels.Figure figure)
        {
            InitializeComponent();
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.BIG_TRIANGLE, Color.Blue, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.MID_TRIANGLE, Color.Blue, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.SMALL_TRIANGLE, Color.Blue, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.RECT, Color.Blue, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.PARALLELOGRAM, Color.Blue, new PointF(0, 0)));

            //designerCanvas.AllowDrop = true;
            //designerCanvas.DragEnter += Canvas_DragEnter;
            //designerCanvas.DragDrop += Canvas_DragDrop;
            figureToolBox1.OnFigureSelect += FigureSelected;
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


        private void FigureSelected(PictureBox box, Point location)
        {
            draggedFig = box;
            Point point = PointToClient(Cursor.Position);
            box.Left = (point.X - location.X);
            box.Top = (point.Y - location.Y);
            this.point = location;

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

        private void DraggedFig_Move(object sender, MouseEventArgs e)
        {

            PictureBox pictureBox = sender as PictureBox;
            if (e.Button == MouseButtons.Left)
            {
                draggedFig.Left += e.X - point.X;
                draggedFig.Top += e.Y - point.Y;
                Point currentLocation = designerCanvas.PointToClient(Cursor.Position);
                if (!designerCanvas.Bounds.Contains(currentLocation))
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

        private void DraggedFig_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            Point point = PointToClient(Cursor.Position);
            pictureBox.Left = (point.X - this.point.X);
            pictureBox.Top = (point.Y - this.point.Y);
        }

        private void DraggedFig_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            if (onCanvas)
            {
                GraphicsElements.Figure fig = figureToolBox1.SelectedFigure.Clone();

                Point point = designerCanvas.PointToClient(Cursor.Position);
                point.X = point.X - this.point.X;
                point.Y = point.Y - this.point.Y;

                fig.Translate(point.X, point.Y);
                designerCanvas.AddFigure(fig);
              
            }
            figureToolBox1.Enabled = true;

            Controls.Remove(sender as Control);
            pictureBox.Dispose();
            pictureBox = null;
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
            //fig.Location = new PointF(e.X-this.Left-splitContainer1.Left-canvasPanel.Left-designerCanvas.Left, 
            //                          e.Y- this.Top- splitContainer1.Top -canvasPanel.Top-designerCanvas.Top);
            Point point =  designerCanvas.PointToClient(new Point(e.X, e.Y));
            fig.Location = point;
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
                else
                {
                    currentFigure = null;
                }
                
            }
           
        }

        private void AddFigureGroup_Click(object sender, EventArgs e)
        {
            
            FigureGroupsEdit groupsEdit = new FigureGroupsEdit();
            groupsEdit.ShowDialog();
            AddedGroup = groupsEdit.group;

            figureTypeCombo.DataSource = null;
            figureTypeCombo.DataSource = Database.Teacher_Workspace.figureGroups.Entities;
            figureTypeCombo.DisplayMember = "Name";
            figureTypeCombo.ValueMember = "Id";
            figureTypeCombo.SelectedValue = AddedGroup.Id;


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PickColor_Click(object sender, EventArgs e)
        {
            if (designerCanvas.HasSelection)
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.Color = designerCanvas.FigureColors;
                if(colorDialog.ShowDialog() == DialogResult.OK)
                {
                    designerCanvas.FigureColors = colorDialog.Color;
                }
            }
        }

        private void PanMode_Click(object sender, EventArgs e)
        {
            designerCanvas.CurrentMode = DesignerCanvas.Mode.PAN;
            designerCanvas.Cursor = Cursors.Hand;
        }

        private void SelectMode_Click(object sender, EventArgs e)
        {
            designerCanvas.CurrentMode = DesignerCanvas.Mode.SELECT;
            designerCanvas.Cursor = Cursors.Default;
        }
    }
}
