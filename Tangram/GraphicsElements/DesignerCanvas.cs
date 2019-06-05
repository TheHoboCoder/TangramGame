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
        PointF selectedPoint = new PointF();

        bool rotationBegun = false;
        bool rubberSelectionStarted = false;
        RectangleF rubberBandSelection = new RectangleF();

        private Point panPoint = new Point();

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
                    if(value!= gridEnabled)
                    {
                        UpdateGrid();
                    }
                    
                    //this.Image = grid;
                   
                }
                gridEnabled = value;
            }
        }

        public bool GridSnapEnabled { get; set; }
        private const int GridCellSize = 15;

        public float SnapDistance { get; set; }
        private PointF snapPoint = new PointF(0, 0);
        private bool snapped = false;
        private PointF translateVector = new PointF(0, 0);
        private float distance = float.MaxValue;

        private Bitmap grid;

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

                //switch (_currentMode)
                //{
                //    case Mode.PAN:
                //        MouseMove -= DesignerCanvas_MouseMove;
                //        break;
                //    case Mode.SELECT:
                //        MouseMove+= DesignerCanvas_MouseMove;
                //        break;
                //}    

                
                Refresh();    
            }
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
        //Если данная фигура пересекается с другими фигурами, она сдвигается влево, чтобы избежать пересечений
        public void AddFigure(Figure f)
        {
            int count = 0;
            bool sizeChanged = false;
            Rectangle figureBounds = Rectangle.Ceiling(f.Path.GetBounds());
            do
            {
                
                var intersections = figures.Where(fig => fig.Path.GetBounds().IntersectsWith(figureBounds));
                count = intersections.Count();

                
                if (count != 0)
                {
                    intersections.OrderBy(fig => fig.Path.GetBounds().X);
                    f.Location = new PointF(intersections.Last().Path.GetBounds().X + intersections.Last().Path.GetBounds().Width, f.Location.Y);
                    figureBounds = Rectangle.Ceiling(f.Path.GetBounds());
                }
                else
                {
                    break;
                }

                

            }
            while (count != 0);
            
            figures.Add(f);

            figureBounds = Rectangle.Ceiling(f.Path.GetBounds());

            Point translateVector = new Point(0, 0);
            if (figureBounds.X < 0)
            {
                this.Width -= figureBounds.X;
                sizeChanged = true;
                translateVector.X = -figureBounds.X;
            }
            if (figureBounds.Y < 0)
            {
                this.Height -= figureBounds.Y;
                sizeChanged = true;
                //this.Top += topLeft.Y;
                translateVector.Y = -figureBounds.Y;
            }

            if (translateVector.X != 0 ||
               translateVector.Y != 0)
            {
                MoveFigures(translateVector.X, translateVector.Y, figures);
            }

            float deltaW = this.Width - figureBounds.X - figureBounds.Width;
            if (deltaW < 0)
            {
                sizeChanged = true;
                this.Width += (int)Math.Round(-deltaW);
            }

            float deltaH = this.Height - figureBounds.Y - figureBounds.Height;
            if (deltaH < 0)
            {
                sizeChanged = true;
                this.Height += (int)Math.Round(-deltaW);
            }

            figures.OrderBy(cur => cur.Path.GetBounds().Y);

            if (sizeChanged)
            {
                if (GridEnabled) UpdateGrid();
            }
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
                initRotatePoints(previewSelection);
                selectedPoint = e.Location;
                operating = true;
                previewSelection = null;
                notSelected = figures.Except(selectedFigures).ToList();
            }

            

            Refresh();

          
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


        //Перемещает фигуры figures, на dx пикселей по оси X и на dy пикселей по оси Y
        private bool MoveFigures(float dx, float dy, IEnumerable<Figure> figures)
        {

            //if (GridSnapEnabled)
            //{
            //    //float new_dx = (float)Math.Round((float)(dx + figures.First().Location.X) / GridCellSize) * GridCellSize - figures.First().Location.X;
            //    //float new_dy = (float)Math.Round((float)(dy + figures.First().Location.Y) / GridCellSize) * GridCellSize - figures.First().Location.Y;
            //    Figure first = figures.First();

            //    float new_dx = 0, new_dy = 0;
            //    bool fisrtTime = true;
            //    foreach (PointF point in first.Path.PathPoints)
            //    {
            //        float dx_dx = (float)Math.Round((float)(dx + point.X) / GridCellSize) * GridCellSize - point.X;
            //        float dy_dy = (float)Math.Round((float)(dy + point.Y) / GridCellSize) * GridCellSize - point.Y;

            //        if (fisrtTime)
            //        {
            //            new_dx = dx_dx;
            //            new_dy = dy_dy;
            //            fisrtTime = false;
            //        }
            //        else
            //        {
            //            if (dx_dx < new_dx && dx_dx != 0)
            //            {
            //                new_dx = dx_dx;
            //            }

            //            if (dy_dy < new_dy && dy_dy != 0)
            //            {
            //                new_dy = dy_dy;
            //            }
            //        }


            //    }

            //    if (new_dx != 0 || new_dy != 0)
            //    {
            //        selectedPoint.X += dx;
            //        selectedPoint.Y += dy;
            //        //Cursor.Position = this.PointToScreen(Point.Ceiling(selectedPoint));

            //    }
            //    dx = new_dx;
            //    dy = new_dy;

               

            //}


            foreach (Figure f in figures)
            {
                f.Translate(dx, dy);
                //try
                //{
                    //foreach (Figure fig in notSelected)
                    //{
                    //    GeometryTools.IntersectionResult res = GeometryTools.SAT_intersects( f.Path.PathPoints, fig.Path.PathPoints, SnapDistance);

                    //    if (res.intersects)
                    //    {
                    //        f.Translate(res.translateVector.X, res.translateVector.Y);
                    //        this.translateVector = res.translateVector;
                    //        return false;
                    //    }
                    //    else
                    //    {
                    //        if (res.snapped)
                    //        {
                    //            if (!snapped)
                    //            {
                    //                snapped = true;
                    //                distance = res.distance;
                    //                snapPoint = res.snapPoint;
                    //                translateVector = res.translateVector;
                    //            }

                    //            if (snapped && res.distance < distance)
                    //            {
                    //                distance = res.distance;
                    //                snapPoint = res.snapPoint;
                    //                translateVector = res.translateVector;
                    //            }
                    //        }
                    //    else
                    //    {
                    //        snapped = false;
                    //    }
                    //    }
                    //}

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
                        float curX = 0, curY = 0;
                        curX = e.Location.X - selectedPoint.X;
                        curY = e.Location.Y - selectedPoint.Y;


                        if (!MoveFigures(curX, curY, selectedFigures))
                        {
                            PointF cursorPosition = new PointF(e.Location.X + translateVector.X,
                                                               e.Location.Y + translateVector.Y);
                            Cursor.Position = this.PointToScreen(Point.Ceiling(cursorPosition));

                            selectedPoint.X = e.Location.X + translateVector.X;
                            selectedPoint.Y = e.Location.Y + translateVector.Y;
                            //snapped = false;
                            //distance = float.MaxValue;
                            //operating = false;

                            //readyToMove = readyToRotate = false;
                            //rubberSelectionStarted = false;
                            //rotationBegun = false;
                            //angle = 0;
                            //Refresh();
                            //return;

                        }
                        else
                        {
                            if (!GridSnapEnabled)
                            {
                                selectedPoint.X = e.Location.X;
                                selectedPoint.Y = e.Location.Y;
                            }
                          
                        }
                        
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
                if (CurrentMode == Mode.PAN) return;
                
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
            bool sizeChanged = false;
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
                    sizeChanged = true;
                    translateVector.X = -bounds.X;
                }
                if (bounds.Y < 0)
                {
                    this.Height -= bounds.Y;
                    sizeChanged = true;
                    //this.Top += topLeft.Y;
                    translateVector.Y = -bounds.Y;
                }

                notSelected.Clear();

                if(translateVector.X !=0 ||
                   translateVector.Y !=0 )
                {
                    MoveFigures(translateVector.X, translateVector.Y, figures);
                }
                

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
                    sizeChanged = true;
                }
                if (rightBottom.Y > this.Height)
                {
                    this.Height = rightBottom.Y;
                    sizeChanged = true;
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

            if (sizeChanged)
            {
                if (GridEnabled) UpdateGrid();
                Refresh();
            }
           
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
