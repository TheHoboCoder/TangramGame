using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.GraphicsElements
{
    public class ColorTools
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

        /// <summary>
        /// Переводит цвет из цветого пространства HSB в RGB
        /// </summary>
        /// <param name="a"></param>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Color ColorFromAhsb(int a, float h, float s, float b)
        {
            if (0 > a || 255 < a) { throw new ArgumentOutOfRangeException("a", a,"InvalidAlpha"); }
            if (0f > h || 360f < h) { throw new ArgumentOutOfRangeException("h", h, "InvalidHue"); }
            if (0f > s || 1f < s) { throw new ArgumentOutOfRangeException("s", s, "InvalidSaturation"); }
            if (0f > b || 1f < b) { throw new ArgumentOutOfRangeException("b", b, "InvalidBrightness"); }

            if (0 == s){
                return Color.FromArgb(a, Convert.ToInt32(b * 255), Convert.ToInt32(b * 255), Convert.ToInt32(b * 255));
            }
            float fMax, fMid, fMin; int iSextant, iMax, iMid, iMin;
            if (0.5 < b)
            {
                fMax = b - (b * s) + s; fMin = b + (b * s) - s;
            }
            else
            {
              fMax = b + (b * s); fMin = b - (b * s);
            }
            iSextant = (int)Math.Floor(h / 60f);
            if (300f <= h)
            {
                h -= 360f;
            }
            h /= 60f;
            h -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = h * (fMax - fMin) + fMin;
            }
            else
            {
                fMid = fMin - h * (fMax - fMin);
            }
            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant)
            {
                case 1: return Color.FromArgb(a, iMid, iMax, iMin);
                case 2: return Color.FromArgb(a, iMin, iMax, iMid);
                case 3: return Color.FromArgb(a, iMin, iMid, iMax);
                case 4: return Color.FromArgb(a, iMid, iMin, iMax);
                case 5: return Color.FromArgb(a, iMax, iMin, iMid);
                default: return Color.FromArgb(a, iMax, iMid, iMin);
            }
        }

        private static void RangeNumber(ref int number, int max, int min)
        {
            if (number < min) number = min;
            if (number > max) number = max;
        }
    }
}
