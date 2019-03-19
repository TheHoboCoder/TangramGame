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
            //canvas = new Bitmap(this.Width, this.Height);
            //gr = Graphics.FromImage(canvas);
            selectionPen =  new Pen(new SolidBrush(Color.Black), 2);
            previewPen = new Pen(new SolidBrush(Color.Black), 2);
            previewPen.DashStyle = DashStyle.Dash;
            selectionPen.Alignment = previewPen.Alignment = PenAlignment.Inset;
        }

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
            this.Resize += new System.EventHandler(this.DesignerCanvas_Resize);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private Bitmap canvas;
        private Graphics gr;

        List<Figure> figures = new List<Figure>();
        List<Figure> selectedFigures = new List<Figure>();
        Figure previewSelection;


        private const float rotatePointsHalfSize = 6;
        private const float rotateWheelBigRadius = 30;
        private const float rotateWheelSmallRadius = 18;
        private const float rotateWheelRadius = (rotateWheelBigRadius + rotateWheelSmallRadius) / 2;
        List<RectangleF> rotatePoints = new List<RectangleF>();
        private RectangleF currentPoint = new RectangleF();
        private RectangleF previewPoint = new RectangleF();
        private RectangleF wheelBounds = new RectangleF();
        private PointF currentRotatePoint = new PointF();


        private bool previewPointSelected = false;
        private bool onWheel = false;

        bool operating = false;
        PointF selectedPoint = new PointF();

        bool rubberSelectionStarted = false;
        RectangleF rubberBandSelection = new RectangleF();

        private Pen selectionPen,previewPen;

        public enum Mode
        {
            MOVE,
            ROTATE
        }

        public bool GridEnabled { get; set; }

        public bool GridSnapEnabled { get; set; }
        private const float GridCellSize = 15;
        public bool AngleSnapEnabled { get; set; }
        public float SnapAngle { get; set; }

        private Mode _currentMode;
        public Mode CurrentMode
        {
            get
            {
                return _currentMode;
            }
            set
            {
                if (_currentMode != value)
                {
                    switch (value)
                    {
                        case Mode.MOVE:
                            rotatePoints.Clear();
                            break;
                        case Mode.ROTATE:

                            foreach (Figure f in selectedFigures)
                            {
                                foreach (PointF cur in f.Path.PathPoints)
                                {
                                    rotatePoints.Add(new RectangleF(cur.X - rotatePointsHalfSize,
                                                     cur.Y - rotatePointsHalfSize,
                                                     rotatePointsHalfSize * 2,
                                                     rotatePointsHalfSize * 2));
                                }
                            }
                            if (selectedFigures.Count() != 0)
                            {
                                currentRotatePoint = selectedFigures.First().BoundaryCenter;
                            }
                            foreach (Figure f in selectedFigures)
                            {
                                f.pivot = currentRotatePoint;
                            }

                            break;
                    }
                }
                
                _currentMode = value;
                
                Refresh();
                
            }
        }


        private void DesignerCanvas_Resize(object sender, EventArgs e)
        {


        }

        public void AddFigure(Figure f)
        {
            int count = 0;
            do
            {
                var intersections = figures.Where(fig => fig.Path.GetBounds().IntersectsWith(f.Path.GetBounds()));
                count = intersections.Count();
                if (count != 0)
                {
                    intersections.OrderBy(fig => fig.Path.GetBounds().X);
                    f.Location = new PointF(intersections.Last().Path.GetBounds().X + intersections.Last().Path.GetBounds().Width, f.Location.Y);
                }

                float delta = this.Width - f.Path.GetBounds().X - f.Path.GetBounds().Width;
                if (delta < 0)
                {
                    this.Width +=(int)Math.Round(-delta);
                }

            }
            while (count != 0);

            figures.Add(f);
            figures.OrderBy(cur => cur.Path.GetBounds().Y);
            Refresh();
        }

        #region drawing
        private void Fill(Figure f)
        {
            if (f == null) return;
            using (Brush c = new SolidBrush(f.FigureColor))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.FillPath(c, f.Path);
            }      
        }

        private void DrawRubberBand()
        {
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            gr.CompositingMode = CompositingMode.SourceOver;
            using (Brush br = new SolidBrush(Color.FromArgb(120, Color.Blue)))
            {
                gr.FillRectangle(br, Rectangle.Ceiling(rubberBandSelection));
            }  
            using (Pen p =  new Pen(new SolidBrush(Color.FromArgb(200, Color.Blue)), 2))
            {
                p.Alignment = PenAlignment.Inset;
                gr.DrawRectangle(p, Rectangle.Ceiling(rubberBandSelection));
            }
            gr.CompositingMode = CompositingMode.SourceCopy;
        }

        private void Clear(Figure f)
        {
            if (f == null) return;
            using (Brush c = new SolidBrush(Color.Transparent))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.FillPath(c, f.Path);
            }
        }

        private void Draw(Figure f)
        {
            if (f == null) return;
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            gr.DrawPath(selectionPen, f.Path);
        }

        private void PreviewSelectionOn(Figure f)
        {
            if (f == null) return;
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            gr.DrawPath(previewPen, f.Path);
        }

        private void RepaintAll()
        {
            gr.Clear(Color.Transparent);
            foreach(Figure f in figures)
            {
                Draw(f);
            }
        }
        #endregion

        private void DesignerCanvas_MouseDown(object sender, MouseEventArgs e)
        {

            if (previewPointSelected)
            {
                currentRotatePoint = new PointF(previewPoint.X + rotatePointsHalfSize, previewPoint.Y + rotatePointsHalfSize);
                currentPoint = previewPoint;
                wheelBounds = new RectangleF(currentRotatePoint.X - rotateWheelRadius,
                                             currentRotatePoint.Y - rotateWheelRadius,
                                             rotateWheelRadius * 2,
                                             rotateWheelRadius * 2);
                foreach (Figure f in selectedFigures)
                {
                    f.pivot = currentRotatePoint;
                }
                return;
            }

            if (onWheel)
            {
                selectedPoint = e.Location;
                operating = true;
                return;
            }


            var selected = selectedFigures.Where(f => f.Path.IsVisible(e.Location));
            if(selected.Count() == 0)
            {
                if (previewSelection != null)
                {
                    if (Control.ModifierKeys != Keys.Control)
                    {
                        if(CurrentMode == Mode.ROTATE)
                        {
                            rotatePoints.Clear();
                        }
                        selectedFigures.Clear();
                    }

                    selectedFigures.Add(previewSelection);

                    if (CurrentMode == Mode.ROTATE)
                    {
                       foreach(PointF cur in previewSelection.Path.PathPoints)
                       {
                            rotatePoints.Add(new RectangleF(cur.X - rotatePointsHalfSize,
                                             cur.Y - rotatePointsHalfSize,
                                             rotatePointsHalfSize * 2,
                                             rotatePointsHalfSize * 2));
                       }
                       currentRotatePoint = previewSelection.BoundaryCenter;
                       currentPoint = new RectangleF(currentRotatePoint.X - rotatePointsHalfSize,
                                                    currentRotatePoint.Y - rotatePointsHalfSize,
                                                    rotatePointsHalfSize * 2,
                                                     rotatePointsHalfSize * 2);
                        wheelBounds = new RectangleF(currentRotatePoint.X - rotateWheelRadius,
                                                     currentRotatePoint.Y - rotateWheelRadius,
                                                     rotateWheelRadius * 2,
                                                     rotateWheelRadius * 2);
                        foreach (Figure f in selectedFigures)
                       {
                            f.pivot = currentRotatePoint;
                       }
                    }
                    selectedPoint = e.Location;
                    operating = true;
                    previewSelection = null;
                    Invalidate();
                }
                else
                {
                    selectedFigures.Clear();
                }
                Invalidate();
            }
            else
            {
                selectedPoint = e.Location;
                operating = true;
            }

             Refresh();
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
                        Refresh();
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
                            Refresh();
                            break;
                        case Mode.ROTATE:

                            float cathet = Math.Abs(currentRotatePoint.Y - selectedPoint.Y);
                            float hyp = GeometryTools.GetDistance(currentRotatePoint, selectedPoint);
                            double angle = Math.Asin(cathet / hyp);
                            cathet = Math.Abs(currentRotatePoint.Y - e.Location.Y);
                            hyp = GeometryTools.GetDistance(currentRotatePoint, e.Location);
                            double angle2 = Math.Asin(cathet / hyp);
                            foreach (Figure f in selectedFigures)
                            {
                                f.Rotate((float)(angle-angle2));
                            }
                            //selectedPoint.X = e.Location.X;
                            //selectedPoint.Y = e.Location.Y;
                            Refresh();
                            break;
                    }
                }
            }
            else
            {
                var selected = figures.Except(selectedFigures).Where(f => f.Path.IsVisible(e.Location));

                if (selected.Count() != 0)
                {
                    switch (CurrentMode)
                    {
                        case Mode.MOVE:
                           this.Cursor = Cursors.SizeAll;
                        break;
                        case Mode.ROTATE:
                            //this.Cursor = Cursors.
                            break;
                    }
                   
                    previewSelection = selected.First();
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    previewSelection = null;
                }

                if(CurrentMode == Mode.ROTATE)
                {
                    var previewPoints = rotatePoints.Where(p => p.Contains(e.Location));
                    if (previewPoints.Count() != 0)
                    {
                        previewPoint = previewPoints.First();
                        previewPointSelected = true;
                    }
                    else
                    {
                        previewPointSelected = false;
                    }
                    float distance = GeometryTools.GetDistance(currentRotatePoint, e.Location);
                    if(distance>=rotateWheelSmallRadius && distance <= rotateWheelBigRadius)
                    {
                        onWheel = true;
                    }
                    else
                    {
                        onWheel = false;
                    }
                }
               Refresh();
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
            Refresh();
        }

        

        private void DesignerCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush k = new SolidBrush(Color.Blue);
            Pen p = new Pen(k, 1);

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

            if(CurrentMode == Mode.ROTATE)
            {
                p = new Pen(new SolidBrush(Color.Gray), 3);
                foreach (RectangleF point in rotatePoints)
                {
                    e.Graphics.DrawEllipse(p, point);
                }
                p = new Pen(new SolidBrush(Color.OrangeRed), 3);
                if (previewPointSelected)
                {
                    e.Graphics.DrawEllipse(p, previewPoint);
                }
                k = new SolidBrush(Color.OrangeRed);

                e.Graphics.FillEllipse(k, currentPoint);

                if (onWheel)
                {
                    p = new Pen(new SolidBrush(Color.Green), 4);
                }
                else
                {
                    p = new Pen(new SolidBrush(Color.Green), 2);
                }

                e.Graphics.DrawEllipse(p, wheelBounds);
                e.Graphics.DrawEllipse(p, new RectangleF(selectedPoint.X, selectedPoint.Y, 10, 10));
            }
            


            k.Dispose();
            p.Dispose();
        }

    }
}
