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


        List<Figure> figures = new List<Figure>();
        List<Figure> selectedFigures = new List<Figure>();
        Figure previewSelection,currentSelection;


        private const float rotatePointsHalfSize = 6;
        private const float rotationRadious = 60;
        List<RectangleF> rotatePoints = new List<RectangleF>();
        private RectangleF previewPoint = new RectangleF();
        private PointF currentRotatePoint = new PointF();
        private double angle = 0;



        bool operating = false;
        bool readyToMove = false;
        bool readyToRotate = false;
        PointF selectedPoint = new PointF();

        bool rotationBegun = false;
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

        private float snapAngle = 45;
        public float SnapAngle
        {
            get
            {
                return snapAngle;
            }
            set
            {
                snapAngle = value;
            }
        }


        private Mode _currentMode;
        public Mode CurrentMode
        {
            get
            {
                return _currentMode;
            }
            set
            {
                
                
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
            //do
            //{
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

            //}
            //while (count != 0);

            figures.Add(f);
            figures.OrderBy(cur => cur.Path.GetBounds().Y);
            Refresh();
        }

       

        private void DesignerCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (readyToMove||readyToRotate)
            {
                operating = true;
                rotationBegun = readyToRotate;
                if (readyToRotate)
                {
                    rotatePoints.Clear();
                    foreach (Figure f in selectedFigures)
                    {
                        f.pivot = currentRotatePoint;
                    }
                }
                selectedPoint = e.Location;
                readyToRotate = readyToMove = false;
                notSelected = figures.Except(selectedFigures);
                return;
            }

            if (Control.ModifierKeys != Keys.Control)
            {
                rotatePoints.Clear();
                selectedFigures.Clear();
                
            }

            if (previewSelection != null)
            {
                selectedFigures.Add(previewSelection);
                initRotatePoints(previewSelection);
                selectedPoint = e.Location;
                operating = true;
                previewSelection = null;
            }

            Refresh();

          
        }

        private void UpdateRubberBand()
        {
            var selectedItems = figures.Where(f => f.Path.GetBounds().IntersectsWith(rubberBandSelection));
            selectedFigures = selectedItems.ToList();
            Refresh();
        }

        private void CreateRubberBand(PointF mouseLocation)
        {
            rubberBandSelection.X = Math.Min(mouseLocation.X, selectedPoint.X);
            rubberBandSelection.Y = Math.Min(mouseLocation.Y, selectedPoint.Y);
            rubberBandSelection.Width = Math.Abs(mouseLocation.X - selectedPoint.X);
            rubberBandSelection.Height = Math.Abs(mouseLocation.Y - selectedPoint.Y);
        }

        IEnumerable<Figure> notSelected;

        private void MoveFigures(float dx, float dy, IEnumerable<Figure> figures)
        {
           
            foreach (Figure f in figures)
            {
                f.Translate(dx, dy);
                //try
                //{
                //    foreach(Figure fig in notSelected)
                //    {
                //       GeometryTools.IntersectionResult res=  GeometryTools.CAT_Intersects(fig.Path.PathPoints, f.Path.PathPoints,4);
                //        if (res.intersects)
                //        {
                //            f.Translate(-curX, -curY);
                //        }
                //    }
                   
                //}
                //catch(Exception ex)
                //{
                //    MessageBox.Show("fuck you " + ex.ToString());
                //}
            }
            for(int i = 0, count = rotatePoints.Count();i<count;i++)
            {
                var point = rotatePoints[i];
                point.X += dx;
                point.Y += dy;
                rotatePoints[i] = point;
            }
          
            Refresh();
        }


        private void RotateFigures(PointF mouseLocation)
        {

            PointF vector = new PointF(mouseLocation.X - currentRotatePoint.X, currentRotatePoint.Y + rotationRadious - mouseLocation.Y);
            if (Math.Abs(vector.X) > rotationRadious)
            {
                vector.X = rotationRadious * Math.Sign(vector.X);
            }
            if (Math.Abs(vector.Y) > rotationRadious)
            {
                vector.Y = rotationRadious * Math.Sign(vector.Y);
            }
            float dotProduct = vector.Y * rotationRadious;
            float distance = (float)Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
            double radianAngle = Math.Acos(dotProduct / (distance * rotationRadious));
            double angle = (180 / Math.PI) * radianAngle;

            if (vector.X < 0)
            {
                angle = 360-angle;
            }

            bool angleSnapOn = (Control.ModifierKeys == Keys.Shift && snapAngle!=0);
           
            foreach (Figure f in selectedFigures)
            {
                if (angleSnapOn)
                {
                    float previewAngle = f.RotationAngle + (float)(angle - f.RotationAngle);
                    f.RotationAngle =(float)(Math.Round( previewAngle / snapAngle) * snapAngle);
                }
                else
                {
                    f.Rotate((float)(angle - this.angle));
                }
               
            }
            this.angle = angle;
            //selectedPoint.X = mouseLocation.X;
            //selectedPoint.Y = mouseLocation.Y;
            Refresh();
        }

        private void initRotatePoints(Figure f)
        {
            foreach (PointF cur in f.Path.PathPoints)
            {
                rotatePoints.Add(new RectangleF(cur.X - rotatePointsHalfSize,
                                 cur.Y - rotatePointsHalfSize,
                                 rotatePointsHalfSize * 2,
                                 rotatePointsHalfSize * 2));
            }
            rotatePoints.Add(new RectangleF(f.BoundaryCenter.X - rotatePointsHalfSize,
                                 f.BoundaryCenter.Y - rotatePointsHalfSize,
                                 rotatePointsHalfSize * 2,
                                 rotatePointsHalfSize * 2));
        }

        private void initRSelection()
        {
            foreach(Figure f in selectedFigures)
            {
                initRotatePoints(f);
            }
        }

        private void DesignerCanvas_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (!operating)
                {
                    if (rubberSelectionStarted)
                    {
                        CreateRubberBand(e.Location);
                        UpdateRubberBand();
                    }
                    else
                    {
                        rubberSelectionStarted = true;
                        selectedPoint = e.Location;
                    }
                }
                else
                {
                    if (!rotationBegun)
                    {
                        float curX = e.Location.X - selectedPoint.X;
                        float curY = e.Location.Y - selectedPoint.Y;
                        MoveFigures(curX,curY,selectedFigures);
                        selectedPoint.X = e.Location.X;
                        selectedPoint.Y = e.Location.Y;
                    }
                    else
                    {
                        RotateFigures(e.Location);
                    }
                    //switch (CurrentMode)
                    //{
                         
                    //    case Mode.MOVE:
                    //        MoveFigures(e.Location);
                    //        break;
                    //    case Mode.ROTATE:
                    //        RotateFigures(e.Location);
                    //        break;
                    //}
                }
            }
            else
            {
                var rotate = rotatePoints.Where(p => p.Contains(e.Location));

                if (rotate.Count() != 0 && rotatePoints.Count()!=0)
                {
                    this.Cursor = Cursors.Cross;
                    readyToRotate = true;
                    previewPoint = rotate.First();
                    currentRotatePoint = new PointF(previewPoint.X + rotatePointsHalfSize, previewPoint.Y + rotatePointsHalfSize);
                    Refresh();
                    return;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    readyToRotate = false;
                }

                if (previewSelection!=null && previewSelection.Path.IsVisible(e.Location) ||
                     currentSelection != null && currentSelection.Path.IsVisible(e.Location))
                {
                    return;
                }

                var preview = figures.Except(selectedFigures).Where(f => f.Path.IsVisible(e.Location));
                
                if (preview.Count() != 0)
                {
                    Cursor = Cursors.SizeAll;
                    previewSelection = preview.First();

                    Refresh();
                    preview = null;
                    return;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    previewSelection = null;
                }

                var selected = selectedFigures.Where(f => f.Path.IsVisible(e.Location));

                
                if (selected.Count() != 0)
                {
                    this.Cursor = Cursors.SizeAll;
                    currentSelection = selected.First();
                    rotatePoints.Clear();
                    initRotatePoints(currentSelection);
                    readyToMove = true;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    currentSelection = null;
                    readyToMove = false;
                }

               Refresh();
            }
        }

        

        private void DesignerCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (operating || rotationBegun)
            {
                //if (rotationBegun)
                //{
                //    initRotatePoints(currentSelection);
                //}
                var selectionBox = selectedFigures.OrderBy(f => f.Path.GetBounds().X).ThenBy(f => f.Path.GetBounds().Y);
                Point topLeft = Point.Ceiling(selectionBox.First().Path.PathPoints.OrderBy(p => p.X).ThenBy(p => p.Y).First());

                Point translateVector = new Point(0, 0);

                if (topLeft.X < 0)
                {
                    this.Width -= topLeft.X;
                    translateVector.X = -topLeft.X;
                }
                if (topLeft.Y < 0)
                {
                    this.Height -= topLeft.Y;
                    //this.Top += topLeft.Y;
                    translateVector.Y = -topLeft.Y;
                }

                MoveFigures(translateVector.X, translateVector.Y, figures);

                if (selectedFigures.Count >= 2)
                {
                    Point rightBottom = Point.Ceiling(selectionBox.Last().Path.PathPoints.OrderByDescending(p => p.X).ThenByDescending(p => p.Y).First());
                    if (rightBottom.X > this.Width)
                    {
                        this.Width = rightBottom.X;
                    }
                    if (rightBottom.Y > this.Height)
                    {
                        this.Height = rightBottom.Y;
                    }
                }
            }

            operating = false;

            readyToMove = readyToRotate = false;
            rubberSelectionStarted = false;
            rotationBegun = false;
            angle = 0;
            Refresh();
        }

        

        private void DesignerCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush, 2);

            
            
            pen.DashStyle = DashStyle.Solid;
            foreach (Figure figure in figures)
            {
                brush.Color = figure.FigureColor;
                e.Graphics.FillPath(brush, figure.Path);
            }
            //pen = new Pen(new SolidBrush(Color.Black), 2);

            brush.Color = Color.Black;
            pen.Brush = brush;
            pen.Width = 2;

            foreach (Figure figure in selectedFigures)
            {
                
                e.Graphics.DrawPath(pen, figure.Path);
            }

            if (previewSelection != null)
            {
                pen.DashStyle = DashStyle.Dash;
                e.Graphics.DrawPath(pen, previewSelection.Path);
            }

            if (rubberSelectionStarted)
            {
                pen.DashStyle = DashStyle.Solid;
                e.Graphics.DrawRectangle(pen, Rectangle.Ceiling(rubberBandSelection));
                
            }

             brush.Color = Color.Gray;
             pen.Brush = brush;
             pen.Width =  3;

             foreach (RectangleF point in rotatePoints)
             {
                e.Graphics.DrawEllipse(pen, point);
             }
            brush.Color = Color.OrangeRed;
             if (readyToRotate||rotationBegun)
             {
                 e.Graphics.FillEllipse(brush, new RectangleF(previewPoint.X-2,previewPoint.Y-2,previewPoint.Width+4,previewPoint.Height+4));
                if (rotationBegun)
                {
                    brush.Color = Color.DarkSeaGreen;
                    pen.Brush = brush;
                    e.Graphics.DrawPie(pen, currentRotatePoint.X - rotationRadious,
                                               currentRotatePoint.Y,
                                               rotationRadious * 2,
                                               rotationRadious * 2,
                                               -90,
                                               (float)angle);

                    brush.Color = Color.LawnGreen;
                    //pen.Brush = brush;
                    //pen.DashStyle = DashStyle.Dash;
                    //e.Graphics.DrawEllipse(pen, currentRotatePoint.X - rotationRadious,
                    //                           currentRotatePoint.Y,
                    //                           rotationRadious * 2,
                    //                           rotationRadious * 2);
                   
                    brush.Color = Color.DarkViolet;
                    e.Graphics.DrawString(Math.Round(angle,2).ToString()+"", this.Font, brush, currentRotatePoint.X, currentRotatePoint.Y + rotationRadious);
                }
            }
              
            pen.Dispose();
            brush.Dispose();
        }

    }
}
