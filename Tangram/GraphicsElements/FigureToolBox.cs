using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Tangram.GraphicsElements
{
    public partial class FigureToolBox : FlowLayoutPanel
    {

        public delegate void FigureSelected(PictureBox figurePicture,Point location);

        public event FigureSelected OnFigureSelect;


        public int FigureCount { get { return figures.Count(); } }
        private List<Figure> figures = new List<Figure>();

        private List<Bitmap> normalBitmap = new List<Bitmap>();
        private List<Bitmap> hoverBitmap = new List<Bitmap>();

        private Figure selectedFigure;
        public Figure SelectedFigure
        {
            get
            {
                return selectedFigure;
            }
        }

        private const float BRIGHTNES_SHIFT = 0.1F;

        public void Remove(Figure figure)
        {
           
            int pos = figures.IndexOf(figure);
            PictureBox b = Controls[pos] as PictureBox;
            Controls.Remove(b);
            b.Dispose();
            normalBitmap[pos].Dispose();
            normalBitmap.RemoveAt(pos);
            hoverBitmap[pos].Dispose();
            hoverBitmap.RemoveAt(pos);

            figures.Remove(figure);
            figure.Dispose();
            figure = null;
        }

        public void Add(Figure figure)
        {
            RectangleF rectangle = figure.Path.GetBounds();
            figure.Translate(-rectangle.X, -rectangle.Y);
            figures.Add(figure);

            Bitmap image = figure.GetImage(figure.FigureColor);
            normalBitmap.Add(image);
            //image.Save("figure_" + normalBitmap.Count() + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            float hue = figure.FigureColor.GetHue();
            float saturation = figure.FigureColor.GetSaturation() ;
            
            float brightness = figure.FigureColor.GetBrightness() + BRIGHTNES_SHIFT;
            if (brightness > 1.0F)
            {
                brightness = figure.FigureColor.GetBrightness() - BRIGHTNES_SHIFT;
            }
            //Color color = ColorTools.HSBtoRGG(255, hue, saturation, figure.FigureColor.GetBrightness());

            hoverBitmap.Add(figure.GetImage(ColorTools.ColorFromAhsb(255, hue, saturation, brightness)));


            PictureBox figurePicture = new PictureBox();
            figurePicture.SizeMode = PictureBoxSizeMode.AutoSize;
            figurePicture.Image = normalBitmap[normalBitmap.Count()-1];

            figurePicture.MouseEnter += Figure_enter;
            figurePicture.MouseLeave += Figure_leave;
            figurePicture.MouseDown += Figure_mouse_down;
            this.Controls.Add(figurePicture);

        }


        public void Figure_enter(object c, EventArgs e)
        {
            PictureBox pictureBox = c as PictureBox;
            int pos = Controls.IndexOf(pictureBox);
            pictureBox.Image = hoverBitmap[pos];
            pictureBox.Refresh();
        }


        public void Figure_leave(object c, EventArgs e)
        {
            PictureBox pictureBox = c as PictureBox;
            int pos = Controls.IndexOf(pictureBox);
            pictureBox.Image = normalBitmap[pos];
            pictureBox.Refresh();
        }

        public void Figure_mouse_down(object c, MouseEventArgs e)
        {
            PictureBox pictureBox = c as PictureBox;

            PictureBox clonedPicture = new PictureBox();
            clonedPicture.SizeMode = PictureBoxSizeMode.AutoSize;

            int pos = Controls.IndexOf(pictureBox);

            selectedFigure = figures[pos];
            clonedPicture.Image = (Image)normalBitmap[pos].Clone();
            //pictureBox.DoDragDrop(Controls[pos], DragDropEffects.Copy);
            this.Enabled = false;
            OnFigureSelect?.Invoke(clonedPicture, e.Location);
            //OnFigureSelect2(figures[pos].Clone(), e.Location);
        }

        public FigureToolBox()
        {
            InitializeComponent();
            DoubleBuffered = true;
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //UpdateStyles();
            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            Refresh();
        }

        private void FigureToolBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(new SolidBrush(Color.Gray), RoundedRect(this.Bounds, 20));
        }

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
