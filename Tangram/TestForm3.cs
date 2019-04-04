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

namespace Tangram
{
    public partial class TestForm3 : Form
    {
        public TestForm3()
        {
            InitializeComponent();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = colorPreview.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            colorPreview.BackColor = colorDialog1.Color;
        }

        private void TestForm3_Load(object sender, EventArgs e)
        {
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.BIG_TRIANGLE, Color.Yellow, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.MID_TRIANGLE, Color.Violet, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.SMALL_TRIANGLE, Color.Green, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.RECT, Color.Red, new PointF(0, 0)));
            figureToolBox1.Add(new TangramFigure(TangramFigure.FigureTypes.PARALLELOGRAM, Color.Blue, new PointF(0, 0)));

            figureTypeCombo.Items.Add("Большой треугольник");
            figureTypeCombo.Items.Add("Средний треугольник");
            figureTypeCombo.Items.Add("Маленький треугольник");
            figureTypeCombo.Items.Add("Квадрат");
            figureTypeCombo.Items.Add("Параллелограмм");
            figureTypeCombo.SelectedIndex = 0;
            designerCanvas1.GridEnabled = true;
            designerCanvas1.SnapAngle = 45;
            designerCanvas1.CurrentMode = DesignerCanvas.Mode.ROTATE;
            KeyPreview = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            TangramFigure.FigureTypes type = TangramFigure.FigureTypes.BIG_TRIANGLE;
            switch (figureTypeCombo.SelectedIndex) {
                case 0:
                    type = TangramFigure.FigureTypes.BIG_TRIANGLE;
                    break;
                case 1:
                    type = TangramFigure.FigureTypes.MID_TRIANGLE;
                    break;
                case 2:
                    type = TangramFigure.FigureTypes.SMALL_TRIANGLE;
                    break;
                case 3:
                    type = TangramFigure.FigureTypes.RECT;
                    break;
                case 4:
                    type = TangramFigure.FigureTypes.PARALLELOGRAM;
                    break;
            }

            designerCanvas1.AddFigure(new TangramFigure(type, colorPreview.BackColor, designerCanvas1.Location));

        }

        private void TestForm3_FormClosed(object sender, FormClosedEventArgs e)
        {
            //designerCanvas1.Dispose();
        }

        private void TestForm3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 88)
            //{
            //    designerCanvas1.CurrentMode = designerCanvas1.CurrentMode++;
            //}
        }

        private void TestForm3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TestForm3_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.X)
            {
                switch (designerCanvas1.CurrentMode)
                {
                    case DesignerCanvas.Mode.ROTATE:
                        designerCanvas1.CurrentMode = DesignerCanvas.Mode.MOVE;
                        break;
                    case DesignerCanvas.Mode.MOVE:
                        designerCanvas1.CurrentMode = DesignerCanvas.Mode.ROTATE;
                        break;



                }
            }
        }
    }
}
