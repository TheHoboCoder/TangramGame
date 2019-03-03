using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangram.GraphicsElements
{
    class DesignerCanvas:PictureBox
    {

        public DesignerCanvas():base()
        {
            InitializeComponent();
        }

        List<Figure> figures = new List<Figure>();
        List<Figure> selectedFigures = new List<Figure>();
        Figure previewSelection;

        bool operating = false;
        PointF selectedPoint = new PointF();

        bool rubberSelectionStarted = false;
        RectangleF rubberBandSelection = new RectangleF();

        public enum Mode
        {
            MOVE,
            ROTATE
        }

        public Mode CurrentMode { get; set; }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // DesignerCanvas
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DesignerCanvas_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DesignerCanvas_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DesignerCanvas_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DesignerCanvas_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        public void AddFigure(Figure f)
        {
            figures.Add(f);
            Invalidate();
        }
        
            //TODO
            public void AddFigure(Figure f, PointF location)
        {
            f.Location = location;
            figures.Add(f);
            //RectangleF figureBounds = f.Path.GetBounds();
            //var intersectedFigures = figures.Where(cur => cur.Path.GetBounds().IntersectsWith(figureBounds));

            //if (intersectedFigures.Count() == 0)
            //{
            //    figures.Add(f);
            //}
            //else
            //{

            //}
        }

        private void PlaceFigure(RectangleF figureBounds)
        {
            var intersectedFigures = figures.Where(cur => cur.Path.GetBounds().IntersectsWith(figureBounds));
            if (intersectedFigures.Count() == 0)
            {

            }
            else
            {

            }

        }

        private void DesignerCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            bool repaintNeeded = false;
            var selected = selectedFigures.Where(f => f.Path.IsVisible(e.Location));
            if(selected.Count() == 0)
            {
                selectedFigures.Clear();
                repaintNeeded = true;
            }
            else
            {
                selectedPoint = e.Location;
                operating = true;
            }

            if (previewSelection != null)
            {
                if(Control.ModifierKeys != Keys.ControlKey)
                {
                    selectedFigures.Clear();
                }
                selectedFigures.Add(previewSelection);
                selectedPoint = e.Location;
                operating = true;
                previewSelection = null;
                repaintNeeded = true;
            }

            if (repaintNeeded)
                Invalidate();
        }

        private void DesignerCanvas_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (!operating)
                {
                    if (rubberSelectionStarted)
                    {
                        rubberBandSelection.X = Math.Min(e.Location.X, selectedPoint.X);
                        rubberBandSelection.Y = Math.Min(e.Location.Y, selectedPoint.Y);
                        rubberBandSelection.Width = Math.Abs(e.Location.X - selectedPoint.X);
                        rubberBandSelection.Height = Math.Abs(e.Location.Y - selectedPoint.Y);
                        Invalidate();
                    }
                    else
                    {
                        rubberSelectionStarted = true;
                        selectedPoint = e.Location;
                    }
                }
                else
                {
                    PointF cur = new PointF();
                    switch (CurrentMode)
                    {
                         
                        case Mode.MOVE:
                           
                            cur.X = e.Location.X - selectedPoint.X;
                            cur.Y = e.Location.Y - selectedPoint.Y;
                            foreach(Figure f in selectedFigures)
                            {
                                f.Translate(cur.X, cur.Y);
                            }
                            selectedPoint.X = e.Location.X;
                            selectedPoint.Y = e.Location.Y;
                            Invalidate();
                            break;
                            //TODO
                        case Mode.ROTATE:
                            break;
                    }
                }
            }
            else
            {
                var selected = figures.Except(selectedFigures).Where(f => f.Path.IsVisible(e.Location));
                if (selected.Count() != 0)
                {
                    previewSelection = selected.First();
                   
                }
                else
                {
                    previewSelection = null;
                }
                Invalidate();
            }


            
        }

        private void DesignerCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            operating = false;
            if (rubberSelectionStarted)
            {
                var selectedItems = figures.Where(f => f.Path.GetBounds().IntersectsWith(rubberBandSelection));
                selectedFigures = selectedItems.Except(selectedFigures).ToList();
                rubberSelectionStarted = false;
            }
        }

        private void DesignerCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush k = new SolidBrush(Color.AliceBlue);
            Pen p = new Pen(k, 2);

            foreach (Figure figure in figures)
            {
                k.Color = figure.FigureColor;
                e.Graphics.FillPath(k, figure.Path);
            }

            p = new Pen(new SolidBrush(Color.Black), 2);
            foreach (Figure figure in selectedFigures)
            {
              
                e.Graphics.DrawPath(p, figure.Path);
            }

            if (previewSelection != null)
            {
                p.DashStyle = DashStyle.Dash;
                e.Graphics.DrawPath(p, previewSelection.Path);
            }

            if (rubberSelectionStarted)
            {
                p.DashStyle = DashStyle.Solid;
                e.Graphics.DrawRectangle(p, Rectangle.Ceiling(rubberBandSelection));
            }

       

            k.Dispose();
            p.Dispose();
        }
    }
}
