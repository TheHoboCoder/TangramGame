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
        static public Color HSBtoRGG(int alpha, float hue, float saturation, float brightness)
        {
            //RangeNumber(ref hue, 360, 0);
            //RangeNumber(ref saturation, 100, 0);
            //RangeNumber(ref brightness, 100, 0);

            //int H_I = (hue /60)% 6;
            //int Bmin = ((100 - saturation) * brightness) / 100;
            //int a = (brightness - Bmin) * ((hue % 60) / 60);
            //int Binc = Bmin + a;
            //int Bdec = brightness - a;

            //int R = 0, G = 0, B= 0;

            //switch (H_I) {
            //    case 0:
            //        R = brightness;
            //        G = Binc;
            //        B = Bmin;
            //        break;
            //    case 1:
            //        R = Bdec;
            //        G= brightness;
            //        B = Bmin;
            //        break;
            //    case 2:
            //        R = Bmin;
            //        G = brightness;
            //        B = Binc;
            //        break;
            //    case 3:
            //        R = Bmin;
            //        G = Bdec;
            //        B = brightness;
            //        break;
            //    case 4:
            //        R = Binc;
            //        G = Bmin;
            //        B = brightness;
            //        break;
            //    case 5:
            //        R = brightness;
            //        G = Bmin;
            //        B = Bdec;
            //        break;
            //}
            //R = R * 255;
            //G = G * 255 ;
            //B = B * 255;
            //return Color.FromArgb( alpha,R, G, B);

            float R = 0, G = 0, B = 0;

            if (saturation == 0)
            {
                R = brightness;
                G = brightness;
                B = brightness;
            }
            else
            {
                int i;
                float f, p, q, t;

                if (hue == 360)
                    hue = 0;
                else
                    hue = hue/ 60;

                i = (int)Math.Truncate(hue);
                f = hue- i;

                p = brightness * (1.0F - saturation);
                q = brightness * (1.0F - (saturation * f));
                t = brightness * (1.0F - (saturation * (1.0F - f)));

                switch (i)
                {
                    case 0:
                        R = brightness;
                        G = t;
                        B = p;
                        break;

                    case 1:
                        R = q;
                        G = brightness;
                        B = p;
                        break;

                    case 2:
                        R = p;
                        G = brightness;
                        B = t;
                        break;

                    case 3:
                        R = p;
                        G = q;
                        B = brightness;
                        break;

                    case 4:
                        R = t;
                        G = p;
                        B = brightness;
                        break;

                    default:
                        R = brightness;
                        G = p;
                        B = q;
                        break;
                }

            }
            return Color.FromArgb( alpha,(byte)(R * 255), (byte)(G * 255), (byte)(B * 255));
        }


        private static void RangeNumber(ref int number, int max, int min)
        {
            if (number < min) number = min;
            if (number > max) number = max;
        }
    }
}
