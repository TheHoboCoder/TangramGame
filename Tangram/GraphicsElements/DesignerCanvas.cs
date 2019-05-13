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
            translateVector = new PointF(0, 0);
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

        private const float BRIGHTNESS_SHIFT = 0.2F;
        List<Figure> figures = new List<Figure>();
        List<Figure> selectedFigures = new List<Figure>();
        Figure previewSelection,currentSelection;
        private bool selected = false;

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

        private Point panPoint = new Point();

        public enum Mode
        {
            SELECT,
            PAN
        }

        public bool GridEnabled { get; set; }

        public bool GridSnapEnabled { get; set; }
        private const float GridCellSize = 15;

        public float SnapDistance { get; set; }
        private PointF snapPoint = new PointF(0, 0);
        private bool snapped = false;
        private PointF translateVector = new PointF(0, 0);
        private float distance = float.MaxValue;

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

        public void Init(List<Figure> f, Size size)
        {
            figures?.Clear();
            selectedFigures?.Clear();
            previewSelection = currentSelection = null;
            operating = false;
            readyToMove = readyToRotate = false;
            this.Width = size.Width;
            this.Height = size.Height;
            figures.AddRange(f);
            Refresh();
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
            if(CurrentMode == Mode.PAN)
            {
                panPoint = e.Location;
                return;
            }

            if (readyToMove||readyToRotate)
            {
                if(e.Button == MouseButtons.Right)
                {
                    DeleteSelected();
                    return;
                }
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

        private bool MoveFigures(float dx, float dy, IEnumerable<Figure> figures)
        {
           
            foreach (Figure f in figures)
            {
                f.Translate(dx, dy);
                //try
                //{
                //    foreach (Figure fig in notSelected)
                //    {
                //        GeometryTools.IntersectionResult res = GeometryTools.SAT_intersects(fig.Path.PathPoints, f.Path.PathPoints, SnapDistance);

                //        if (res.intersects)
                //        {
                //            f.Translate(res.translateVector.X, res.translateVector.Y);
                //            this.translateVector = res.translateVector;
                //            return false;
                //        }
                //        else
                //        {
                //            if (res.snapped)
                //            {
                //                if (!snapped)
                //                {
                //                    snapped = true;
                //                    distance = res.distance;
                //                    snapPoint = res.snapPoint;
                //                    translateVector = res.translateVector;
                //                }

                //                if(snapped && res.distance < distance)
                //                {
                //                    distance = res.distance;
                //                    snapPoint = res.snapPoint;
                //                    translateVector = res.translateVector;
                //                }
                //            }
                //        }
                //    }

                //}
                //catch (Exception ex)
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
            return true;
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
            if(radianAngle == Double.NaN)
            {
                throw new Exception("nan!");
            }
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
                if (CurrentMode == Mode.PAN)
                {
                    this.Top +=  e.Location.Y- panPoint.Y;
                    this.Left +=  e.Location.X-panPoint.X;
                    return;
                }

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
                        if (!MoveFigures(curX, curY, selectedFigures))
                        {
                            PointF cursorPosition = new PointF(e.Location.X + translateVector.X,
                                                               e.Location.Y + translateVector.Y);
                            Cursor.Position = Point.Ceiling(cursorPosition);

                            snapped = false;
                            distance = float.MaxValue;
                            operating = false;

                            readyToMove = readyToRotate = false;
                            rubberSelectionStarted = false;
                            rotationBegun = false;
                            angle = 0;
                            Refresh();
                            return;

                        }
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
                     this.selected && /*currentSelection != null &&*/ currentSelection.Path.IsVisible(e.Location))
                {
                    Cursor = Cursors.SizeAll;
                    if (this.selected) { readyToMove = true; }
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
                    this.selected = true;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //currentSelection = null;
                    this.selected = false;
                    readyToMove = false;
                }

               Refresh();
            }
        }

        
        private RectangleF getBoundingBox(List<Figure> figures)
        {
            
            
            if (figures.Count() == 1)
            {
                return figures[0].Path.GetBounds();
            }
            else
            {
                RectangleF bounds = figures[0].Path.GetBounds();
                for(int i=1, count = figures.Count(); i<count; i++)
                {
                    bounds = RectangleF.Union(bounds, figures[i].Path.GetBounds());
                }
                return bounds;
            }
            //RectangleF bounds = new RectangleF();

            //var sortedX = figures.OrderBy(f => f.Path.GetBounds().X);
            //var sortedY= figures.OrderBy(f => f.Path.GetBounds().Y);

            //bounds.X = sortedX.First().Path.GetBounds().X;

            //if (sortedX.Count() >= 2)
            //{  
            //    bounds.Width = sortedX.Last().Path.GetBounds().X + sortedX.Last().Path.GetBounds().Width - bounds.X;
            //}
            //else
            //{
            //    bounds.Width = sortedX.First().Path.GetBounds().Width;
            //}

            //bounds.Y = sortedY.First().Path.GetBounds().Y;

            //if (sortedY.Count() >= 2)
            //{
            //    bounds.Height = sortedY.Last().Path.GetBounds().Y + sortedY.Last().Path.GetBounds().Height - bounds.Y;
            //}
            //else
            //{
            //    bounds.Height = sortedY.First().Path.GetBounds().Height;
            //}
            ////float leftX = f.First().Path.GetBounds().X;
            ////float leftY = f.First().Path.GetBounds().Y;
            ////float rightX = f.First().Path.GetBounds().Width + leftX;
            ////float rightY = f.First().Path.GetBounds().Height + leftY;

            //////bounds.X = f.First().Path.GetBounds().X;
            //////bounds.Y = f.First().Path.GetBounds().Y;
            //////bounds.Width = f.First().Path.GetBounds().Width;
            //////bounds.Height = f.First().Path.GetBounds().Height;
            ////bool skip = true;

            ////foreach(Figure cur in f)
            ////{
            ////    if (skip)
            ////    {
            ////        skip = false;
            ////        continue;
            ////    }

            ////    RectangleF curBounds = cur.Path.GetBounds();


            ////    if (curBounds.X + curBounds.Width > rightX)
            ////    {
            ////        rightX = curBounds.X + curBounds.Width;
            ////    }

            ////    if (curBounds.X < leftX)
            ////    {
            ////        leftX = curBounds.X;
            ////    }

            ////    if (curBounds.Y + curBounds.Height > rightY)
            ////    {
            ////        rightY = curBounds.Y + curBounds.Height;
            ////    }
            ////    if (curBounds.Y < leftY)
            ////    {
            ////        rightY = curBounds.Y;
            ////    }
            ////}

            ////bounds.X = leftX;
            ////bounds.Y````````````` = leftY;
            ////bounds.Width = rightX - leftX;
            ////bounds.Height = rightY - leftY;

            //return bounds;
        }

        public List<Figure> packFigures(out Size size)
        {
            if (figures.Count == 0) {
                size = new Size(0, 0);
                return new List<Figure>();
            }

            List<Figure> packedFigures = new List<Figure>();
            packedFigures.AddRange(figures.ToArray());
            //foreach(Figure f in figures)
            //{
            //    packedFigures.Add(f.Clone());
            //}
            RectangleF rectangle = getBoundingBox(packedFigures);
            foreach(Figure f in packedFigures)
            {
                f.Translate(-rectangle.X, -rectangle.Y);
            }
            size = Size.Ceiling(rectangle.Size);
            return packedFigures;
        }

        private void DesignerCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (operating || rotationBegun)
            {
                if (snapped)
                {
                    foreach(Figure f in selectedFigures)
                    {
                        f.Translate(this.translateVector.X, this.translateVector.Y);
                    }
                    snapped = false;
                    distance = float.MaxValue;
                }
                //if (rotationBegun)
                //{
                //    initRotatePoints(currentSelection);
                //}
                RectangleF boundingBox = getBoundingBox(selectedFigures);
                Rectangle bounds = Rectangle.Ceiling(boundingBox);
                //var selectionBox = selectedFigures.OrderBy(f => f.Path.GetBounds().X).ThenBy(f => f.Path.GetBounds().Y);
                //RectangleF bounds = selectedFigures.First().Path.GetBounds();
                //Point topLeft = Point.Ceiling(bounds.Location);
                //if (selectionBox.Count()>=2)
                //{
                //    RectangleF secondBounds = selectionBox.ElementAt(1).Path.GetBounds();
                //    if (secondBounds.Y < bounds.Y)
                //    {
                //        topLeft.Y = (int)Math.Round(secondBounds.Y);
                //    }
                //}
                   
                Point translateVector = new Point(0, 0);
                if (bounds.X < 0)
                {
                    this.Width -= bounds.X;
                    translateVector.X = -bounds.X;
                }
                if (bounds.Y < 0)
                {
                    this.Height -= bounds.Y;
                    //this.Top += topLeft.Y;
                    translateVector.Y = -bounds.Y;
                }

                MoveFigures(translateVector.X, translateVector.Y, figures);

                //if (selectionBox.Count() >= 2)
                //{
                //    bounds = selectedFigures.Last().Path.GetBounds();
                //    RectangleF secondBounds = selectionBox.ElementAt(selectionBox.Count() -2).Path.GetBounds();
                //    if (secondBounds.Y > bounds.Y)
                //    {
                //        bounds.Y = (int)Math.Round(secondBounds.Y);
                //    }
                //}

                Point rightBottom = new Point(bounds.X + bounds.Width, bounds.Y + bounds.Height);
               
                if (rightBottom.X > this.Width)
                {
                    this.Width = rightBottom.X;
                }
                if (rightBottom.Y > this.Height)
                {
                    this.Height = rightBottom.Y;
                }

                if (currentSelection != null)
                {
                    this.initRotatePoints(currentSelection);
                }
            }

            operating = false;

            readyToMove = readyToRotate = false;
            rubberSelectionStarted = false;
            rotationBegun = false;
            angle = 0;
            Refresh();
        }


        public void DeleteSelected()
        {
           foreach(Figure f in selectedFigures)
            {
                figures.Remove(f);
            }
            selectedFigures.Clear();
            rotatePoints.Clear();
            operating = false;

            readyToMove = readyToRotate = false;
            rubberSelectionStarted = false;
            rotationBegun = false;
            selected = false;
            angle = 0;
            Refresh();
        }


        public void TranslateAll(PointF vector)
        {
            foreach(Figure f in selectedFigures)
            {
                f.Translate(vector.X, vector.Y);
            }
            Refresh();
        }

        public void Rotate(float angle)
        {

        }


        public bool HasSelection {
            get
            {
                return selectedFigures != null && selectedFigures.Count >= 1;
            }
        }

        public Color FigureColors {

            get
            {
                if (selectedFigures.Count >= 1)
                {
                    return selectedFigures[0].FigureColor;
                }
                else
                {
                    return Color.Orange;
                }
            }
            set
            {
                foreach(Figure f in selectedFigures)
                {
                    f.FigureColor = value;
                }
                Refresh();
            }
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
                brush.Color = ColorTools.ColorFromAhsb(255, figure.FigureColor.GetHue(), figure.FigureColor.GetSaturation(),
                    figure.FigureColor.GetBrightness() - BRIGHTNESS_SHIFT);
                pen.Brush = brush;
                e.Graphics.DrawPath(pen, figure.Path);
            }

            if (previewSelection != null)
            {
                brush.Color = ColorTools.ColorFromAhsb(255, previewSelection.FigureColor.GetHue(), previewSelection.FigureColor.GetSaturation(),
                   previewSelection.FigureColor.GetBrightness() - BRIGHTNESS_SHIFT);
                pen.DashStyle = DashStyle.Dash;
                pen.Brush = brush;
                e.Graphics.DrawPath(pen, previewSelection.Path);
            }

            pen.DashStyle = DashStyle.Solid;
            if (rubberSelectionStarted)
            {
                brush.Color = Color.FromArgb(180, Color.Blue);
                pen.Brush = brush;
                e.Graphics.DrawRectangle(pen, Rectangle.Ceiling(rubberBandSelection));
                brush.Color = Color.FromArgb(100, Color.Blue);
                e.Graphics.FillRectangle(brush, Rectangle.Ceiling(rubberBandSelection));

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
            brush.Color = Color.LawnGreen;
            pen.Brush = brush;

            if (snapped)
            {
                e.Graphics.DrawRectangle(pen, this.snapPoint.X - 5,
                                              this.snapPoint.Y - 5,
                                              10, 10);
            }
              
            pen.Dispose();
            brush.Dispose();
        }

    }
}
