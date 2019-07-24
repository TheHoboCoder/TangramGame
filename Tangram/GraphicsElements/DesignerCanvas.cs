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
        private const float HUE_SHIFT = 2.0F;

        List<Figure> figures = new List<Figure>();
        List<Figure> selectedFigures = new List<Figure>();
        List<Figure> notSelected = new List<Figure>();
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
        PointF deltaMove = new PointF();
        PointF selectedPoint = new PointF();

        bool rotationBegun = false;
        bool rubberSelectionStarted = false;
        RectangleF rubberBandSelection = new RectangleF();

        private Point panPoint = new Point();

        public bool GridSnapEnabled { get; set; }
        private const int GridCellSize = 15;

        public float SnapDistance { get; set; }
        private PointF snapPoint = new PointF(0, 0);
        private bool snapped = false;
        private PointF translateVector = new PointF(0, 0);
        private float distance = float.MaxValue;

        private Bitmap grid;

        public enum Mode
        {
            SELECT,
            PAN
        }

        private bool gridEnabled = false;

        public bool GridEnabled
        {
            get
            {
                return gridEnabled;
            }
            set
            {
                if (!value)
                {
                    this.Image = null;
                }
                else
                {
                    if (value != gridEnabled)
                    {
                        UpdateGrid();
                    }

                    //this.Image = grid;

                }
                gridEnabled = value;
            }
        }



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

        private void UpdateGrid()
        {
            //this.Image = null;
            grid?.Dispose();
            grid = new Bitmap(Width, Height);

            const float WIDTH = 1.0F;
            const float WIDTH_ACCENT = 2.0F;
            using (Graphics gr = Graphics.FromImage(grid))
            {
                gr.Clear(Color.Transparent);
                SolidBrush br = new SolidBrush(Color.FromArgb(110, Color.Blue));
                Pen pen = new Pen(br, WIDTH);

                int i = 1;
                int vPos = 0, hPos = 0;
                do
                {
                    hPos += GridCellSize;
                    vPos += GridCellSize;
                    if (hPos < Width)
                    {
                        if (i % 5 == 0)
                        {
                            pen.Width = WIDTH_ACCENT;
                        }

                        gr.DrawLine(pen, new Point(hPos, 0), new Point(hPos, Height));
                        pen.Width = WIDTH;
                    }

                    if (vPos < Height)
                    {
                        if (i % 5 == 0)
                        {
                            pen.Width = WIDTH_ACCENT;
                        }

                        gr.DrawLine(pen, new Point(0, vPos), new Point(Width, vPos));
                        pen.Width = WIDTH;
                    }

                    ++i;
                }
                while (hPos < Width || vPos < Height);

                pen.Dispose();
                br.Dispose();
            }

            this.Image = grid;
        }


       



        private void DesignerCanvas_Resize(object sender, EventArgs e)
        {

            
        }

        //Инициализирует рабочую область, используя список фигур f и размер рабочей области size
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

        //Добавлят фигуру на рабочую область. 
        public void AddFigure(Figure f)
        {
            figures.Add(f);
            checkOverflowFigures(new List<Figure> { f});
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

                initDeltaMove(e.Location);

                readyToRotate = readyToMove = false;
                notSelected = figures.Except(selectedFigures).ToList();

                return;
            }

            if (Control.ModifierKeys != Keys.Control)
            {
                rotatePoints.Clear();
                selectedFigures.Clear();
                
            }

            if (previewSelection != null)
            {
                rotatePoints.Clear();
                selectedFigures.Add(previewSelection);
                currentSelection = previewSelection;
                
                initRotatePoints(previewSelection);
                initDeltaMove(e.Location);
                operating = true;
                previewSelection = null;
                notSelected = figures.Except(selectedFigures).ToList();
            }


            Refresh();

          
        }

        private void GetSnapPoint()
        {
            if (notSelected.Count == 0) return;

            float distance = float.MaxValue;
            this.snapped = false;
            foreach(Figure movedFigure in selectedFigures)
            {
                foreach (Figure staticFigure in notSelected)
                {

                    GeometryTools.SnapResult res = GeometryTools.GetSnapPoint(movedFigure.Path.PathPoints,
                                                           staticFigure.Path.PathPoints, 
                                                           SnapDistance);
                    if (!res.snapped) continue;

                    if (res.distance < distance)
                    {
                        distance = res.distance;
                        this.snapPoint = res.snapPoint;
                        this.translateVector = res.translateVector;
                        this.snapped = true;
                    }

                }
                
            }
        }


        private void initDeltaMove(PointF mouseLocaction)
        {
            if (GridSnapEnabled)
            {
                selectedPoint = getNearestPathPoint(currentSelection.Path, mouseLocaction);
            }
            else
            {
                selectedPoint = currentSelection.Path.PathPoints[0];
            }
            deltaMove.X = selectedPoint.X - mouseLocaction.X;
            deltaMove.Y = selectedPoint.Y - mouseLocaction.Y;
        }

        private PointF getNearestPathPoint(GraphicsPath path, PointF checkPoint)
        {
            PointF nearest = path.PathPoints[0];
            float nearestDist = GeometryTools.GetDistance(checkPoint, nearest);

            for(int i = 1, count = path.PathPoints.Count(); i<count; i++)
            {
                float dist = GeometryTools.GetDistance(checkPoint, path.PathPoints[i]);
                if (dist < nearestDist)
                {
                    nearestDist = dist;
                    nearest = path.PathPoints[i];
                }
            }

            return nearest;
        }
        //Находит все фигуры, которые пересекаются с рамкой выделения,  выделяет их.
        private void UpdateRubberBand()
        {
            var selectedItems = figures.Where(f => f.Path.GetBounds().IntersectsWith(rubberBandSelection));
            selectedFigures = selectedItems.ToList();
            Refresh();
        }

        //Обновляет координаты рамки выделения
        private void CreateRubberBand(PointF mouseLocation)
        {
            rubberBandSelection.X = Math.Min(mouseLocation.X, selectedPoint.X);
            rubberBandSelection.Y = Math.Min(mouseLocation.Y, selectedPoint.Y);
            rubberBandSelection.Width = Math.Abs(mouseLocation.X - selectedPoint.X);
            rubberBandSelection.Height = Math.Abs(mouseLocation.Y - selectedPoint.Y);
        }

        

        private bool MoveFigures(PointF mouseLocation, IEnumerable<Figure> figures)
        {
            PointF location = new PointF(mouseLocation.X + deltaMove.X, mouseLocation.Y + deltaMove.Y);

            if (GridSnapEnabled)
            {
                location.X = (float)Math.Round(location.X / GridCellSize) * GridCellSize;
                location.Y = (float)Math.Round(location.Y / GridCellSize) * GridCellSize;
            }

            location.X = location.X - selectedPoint.X;
            location.Y = location.Y - selectedPoint.Y;

            foreach (Figure f in figures)
            {
                f.Translate(location.X, location.Y);
            }

            selectedPoint.X += location.X;
            selectedPoint.Y += location.Y;

            for (int i = 0, count = rotatePoints.Count(); i < count; i++)
            {
                RectangleF point = rotatePoints[i];
                point.X += location.X;
                point.Y += location.Y;
                rotatePoints[i] = point;
            }

            GetSnapPoint();
            Refresh();
            return true;
        }

        //Перемещает фигуры figures, на dx пикселей по оси X и на dy пикселей по оси Y
        private bool MoveFigures(float dx, float dy, IEnumerable<Figure> figures)
        {
            foreach (Figure f in figures)
            {
                f.Translate(dx, dy);
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


        //вращает фигуры
        private void RotateFigures(PointF mouseLocation)
        {
            //вычисляет  координаты вектора, направленного из текущей точки вращения в текущеее положение мыши
            PointF vector = new PointF(mouseLocation.X - currentRotatePoint.X, currentRotatePoint.Y + rotationRadious - mouseLocation.Y);
            if (Math.Abs(vector.X) > rotationRadious)
            {
                vector.X = rotationRadious * Math.Sign(vector.X);
            }
            if (Math.Abs(vector.Y) > rotationRadious)
            {
                vector.Y = rotationRadious * Math.Sign(vector.Y);
            }
            //вычисляет скалярное произведения вектора и ортогонального вектора длиной rotationRadious
            float dotProduct = vector.Y * rotationRadious;
            //вычисляет длину вектора
            float distance = (float)Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
            //вычисляет угол в радианах между вектором и осью OY
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

                        MoveFigures(e.Location, selectedFigures);
                    }
                    else
                    {
                        RotateFigures(e.Location);
                    }
                }
            }
            else
            {
                if (CurrentMode == Mode.PAN) return;

                if (isHoverOnRotatePoints(e.Location))
                {
                    Refresh();
                    return;
                }

                if (previewSelection!=null && previewSelection.Path.IsVisible(e.Location) ||
                     this.selected &&  currentSelection.Path.IsVisible(e.Location))
                {
                    Cursor = Cursors.SizeAll;
                    if (this.selected)
                    {
                        readyToMove = true;
                    }
                    return;
                }

                if (isHoverOnNotSelected(e.Location))
                {
                    Refresh();
                    return;
                }
                isHoverOnSelected(e.Location);
                Refresh();


            }
        }


        private bool isHoverOnRotatePoints(Point location)
        {
            var rotate = rotatePoints.Where(p => p.Contains(location));

            if (rotate.Count() != 0 && rotatePoints.Count() != 0)
            {
                this.Cursor = Cursors.Cross;
                readyToRotate = true;
                previewPoint = rotate.First();
                currentRotatePoint = new PointF(previewPoint.X + rotatePointsHalfSize, previewPoint.Y + rotatePointsHalfSize);
                return true;
            }
            else
            {
                this.Cursor = Cursors.Default;
                readyToRotate = false;
                return false;
            }
        }

        private bool isHoverOnNotSelected(Point location)
        {
            var preview = figures.Except(selectedFigures).Where(f => f.Path.IsVisible(location));

            if (preview.Count() != 0)
            {
                Cursor = Cursors.SizeAll;
                previewSelection = preview.First();

                preview = null;
                return true;
            }
            else
            {
                this.Cursor = Cursors.Default;
                previewSelection = null;
                return false;
            }
        }

        private bool isHoverOnSelected(Point location)
        {
            var selected = selectedFigures.Where(f => f.Path.IsVisible(location));

            if (selected.Count() != 0)
            {
                this.Cursor = Cursors.SizeAll;
                currentSelection = selected.First();
                rotatePoints.Clear();
                initRotatePoints(currentSelection);
                readyToMove = true;
                this.selected = true;
                return true;
            }
            else
            {
                this.Cursor = Cursors.Default;
                //currentSelection = null;
                this.selected = false;
                readyToMove = false;
                return false;
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

        private void checkOverflowFigures(List<Figure> figures)
        {
            bool sizeChanged = false;
            RectangleF boundingBox = getBoundingBox(figures);
            Rectangle bounds = Rectangle.Ceiling(boundingBox);

            Point translateVector = new Point(0, 0);
            if (bounds.X < 0)
            {
                this.Width -= bounds.X;
                sizeChanged = true;
                translateVector.X = -bounds.X;
            }

            if (bounds.Y < 0)
            {
                this.Height -= bounds.Y;
                sizeChanged = true;
                translateVector.Y = -bounds.Y;
            }

            if (translateVector.X != 0 ||
               translateVector.Y != 0)
            {
                MoveFigures(translateVector.X, translateVector.Y, this.figures);
            }

            Point rightBottom = new Point(bounds.X + bounds.Width, bounds.Y + bounds.Height);

            if (rightBottom.X > this.Width)
            {
                this.Width = rightBottom.X;
                sizeChanged = true;
            }
            if (rightBottom.Y > this.Height)
            {
                this.Height = rightBottom.Y;
                sizeChanged = true;
            }

            if (sizeChanged)
            {
                if (GridEnabled) UpdateGrid();
                Refresh();
            }
        }

        private void DesignerCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (snapped)
            {
                foreach (Figure f in selectedFigures)
                {
                    f.Translate(this.translateVector.X, this.translateVector.Y);
                }

                for(int i=0; i<rotatePoints.Count();i++)
                {
                    RectangleF point = rotatePoints[i];
                    point.X += this.translateVector.X;
                    point.Y += this.translateVector.Y;
                    rotatePoints[i] = point;
                }

                snapped = false;
                distance = float.MaxValue;
            }

            if (operating || rotationBegun)
            {
                checkOverflowFigures(selectedFigures);
                notSelected.Clear();
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
                //float hue = figure.FigureColor.GetHue() + HUE_SHIFT;
                //if(hue > 360)
                //{
                //    hue = figure.FigureColor.GetHue() - HUE_SHIFT;
                //}
                //float brightness = figure.FigureColor.GetBrightness() - BRIGHTNESS_SHIFT;
                //if (brightness < 0)
                //{
                //    brightness = figure.FigureColor.GetBrightness() + BRIGHTNESS_SHIFT;
                //}
                brush.Color = ColorTools.ColorFromAhsb(255, figure.FigureColor.GetHue(), figure.FigureColor.GetSaturation(),
                    BRIGHTNESS_SHIFT);
                pen.Brush = brush;
                e.Graphics.DrawPath(pen, figure.Path);
            }

            if (previewSelection != null)
            {
                //float hue = previewSelection.FigureColor.GetHue() + HUE_SHIFT;
                //if (hue > 360)
                //{
                //    hue = previewSelection.FigureColor.GetHue() - HUE_SHIFT;
                //}
                //float brightness = previewSelection.FigureColor.GetBrightness() - BRIGHTNESS_SHIFT;
                //if (brightness < 0)
                //{
                //    brightness = previewSelection.FigureColor.GetBrightness() + BRIGHTNESS_SHIFT;
                //}
                brush.Color = ColorTools.ColorFromAhsb(255, previewSelection.FigureColor.GetHue(), previewSelection.FigureColor.GetSaturation(),
                   BRIGHTNESS_SHIFT);
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
