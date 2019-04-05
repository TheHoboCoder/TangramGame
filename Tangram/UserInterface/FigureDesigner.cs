using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.GraphicsElements;

namespace Tangram.UserInterface
{
    public partial class FigureDesigner : Form
    {
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
    }
}
