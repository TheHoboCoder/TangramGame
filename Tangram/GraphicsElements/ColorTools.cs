using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.GraphicsElements
{
    class ColorTools
    {
        static public Color HSBtoRGG(int alpha, int hue, int saturation, int brightness)
        {
            RangeNumber(ref hue, 360, 0);
            RangeNumber(ref saturation, 100, 0);
            RangeNumber(ref brightness, 100, 0);

            int H_I = (hue /60)% 6;
            int Bmin = ((100 - saturation) * brightness) / 100;
            int a = (brightness - Bmin) * ((hue % 60) / 60);
            int Binc = Bmin + a;
            int Bdec = brightness - a;

            int R = 0, G = 0, B= 0;

            switch (H_I) {
                case 0:
                    R = brightness;
                    G = Binc;
                    B = Bmin;
                    break;
                case 1:
                    R = Bdec;
                    G= brightness;
                    B = Bmin;
                    break;
                case 2:
                    R = Bmin;
                    G = brightness;
                    B = Binc;
                    break;
                case 3:
                    R = Bmin;
                    G = Bdec;
                    B = brightness;
                    break;
                case 4:
                    R = Binc;
                    G = Bmin;
                    B = brightness;
                    break;
                case 5:
                    R = brightness;
                    G = Bmin;
                    B = Bdec;
                    break;
            }

            return Color.FromArgb( alpha,R, G, B);

        }


        private static void RangeNumber(ref int number, int max, int min)
        {
            if (number < min) number = min;
            if (number > max) number = max;
        }
    }
}
