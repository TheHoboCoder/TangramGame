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

namespace Tangram
{
    public partial class Form2 : Form
    {
        Rectangle rect1 = new Rectangle(50, 50, 100, 100);
        Rectangle rect2 = new Rectangle(100, 50, 100, 100);
        GraphicsPath path;
        float rect1_scale;
        float rect2_scale;

        Point position = new Point();
        Point trPos = new Point();
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

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(new SolidBrush(Color.Black), 2);
            Brush k = new SolidBrush(Color.Yellow);

            //e.Graphics.InterpolationMode = InterpolationMode.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

             GraphicsContainer container = e.Graphics.BeginContainer();
            e.Graphics.RotateTransform(rect1_scale);
            e.Graphics.FillRectangle(k, rect1);
            e.Graphics.EndContainer(container);

           
            container = e.Graphics.BeginContainer();

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.RotateTransform(rect2_scale);
            using (Matrix m = new Matrix())
            {
                m.Reset();
                m.Translate(trPos.X,trPos.Y);
                path.Transform(m);
            };
           
            k = new SolidBrush(Color.Blue);


            e.Graphics.FillPath(k, path);
            e.Graphics.DrawRectangle(pen, (int)Math.Round(path.GetBounds().X),
                                                                            (int)Math.Round(path.GetBounds().Y),
                                                                            (int)Math.Round(path.GetBounds().Width),
                                                                            (int)Math.Round(path.GetBounds().Height));
            //e.Graphics.FillRectangle(new SolidBrush(Color.Red), rect2);
            e.Graphics.EndContainer(container);

            container = e.Graphics.BeginContainer();
            e.Graphics.RotateTransform(rect2_scale);
            e.Graphics.EndContainer(container);

            pen.Dispose();
            k.Dispose();

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            rect1_scale = trackBar1.Value;
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
            if (path.IsVisible(e.Location))
            {
                position.X = e.Location.X;
                position.Y = e.Location.Y;
                moving = true;
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && moving)
            {
                trPos.X = e.Location.X - position.X;
                trPos.Y = e.Location.Y - position.Y;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }
    }
}
