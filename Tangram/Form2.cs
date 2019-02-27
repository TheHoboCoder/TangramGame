using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.GraphicsElements;

namespace Tangram
{
    public partial class Form2 : Form
    {
        Rectangle rect1 = new Rectangle(50, 50, 100, 100);
        Rectangle rect2 = new Rectangle(100, 50, 100, 100);
        GraphicsPath path;
        TangramFigure f;
        float rect1_scale;
        float rect2_scale;

        PointF position = new Point();
        PointF trPos = new Point();
        bool moving = false;

        public Form2()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            path = new GraphicsPath();
            path.StartFigure();
            path.AddLine(0, 0, 100, 0);
            path.AddLine(100, 0, 50, 100);
            path.AddLine(50, 100, 0, 0);
            path.CloseFigure();

            f = new TangramFigure(TangramFigure.FigureTypes.SMALL_TRIANGLE, Color.DodgerBlue, new PointF(10, 10));

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(new SolidBrush(Color.Black), 2);
            Brush k = new SolidBrush(f.FigureColor);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPolygon(pen, f.BoundaryPoints);
            e.Graphics.FillPath(k,f.Path);



            pen.Dispose();
            k.Dispose();

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            f.pivot = f.Location;
            f.RotationAngle = trackBar1.Value;
            pictureBox1.Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            rect2_scale = trackBar2.Value;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (f.Path.IsVisible(e.Location))
            {
                position.X = e.Location.X;
                position.Y = e.Location.Y;
                trPos.Y = f.Location.Y;
                trPos.X = f.Location.X;
                moving = true;
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && moving)
            {
                trPos.X = e.Location.X - position.X;
                trPos.Y = e.Location.Y - position.Y;
                f.Translate(trPos.X,trPos.Y);
                position.X = e.Location.X;
                position.Y = e.Location.Y;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }
    }
}
