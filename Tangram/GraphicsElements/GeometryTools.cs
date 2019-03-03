using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.GraphicsElements
{
    static class GeometryTools
    {
        /// <summary>
        /// Вычисляет расстояние между точками.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        static public float GetDistance(PointF first, PointF second)
        {
            if(first.X==second.X && first.Y == second.Y)
            {
                throw new ArgumentException("Points are equal");
            }

            return (float)Math.Sqrt(Math.Pow(second.X - first.X, 2) + Math.Pow(second.Y - first.Y, 2));
        }

        /// <summary>
        /// Возвращает общее уравнение прямой, проходящей через данные точки.
        /// Общее уравнение прямой - A*x+B*y+C=0
        /// </summary>
        /// <param name="first">Точка X1</param>
        /// <param name="second">Точка X2</param>
        /// <returns>
        /// result[0] - коэффициент A
        /// result[1] - коэффициент B
        /// result[2] - коэффициент c
        /// </returns>
        static public float[] GetLineEquation(PointF first, PointF second)
        {
            if (first.X == second.X && first.Y == second.Y)
            {
                throw new ArgumentException("Points are equal");
            }

            float[] result = new float[3];

            result[0] = second.Y - first.Y;
            result[1] = -(second.X - first.X);
            result[2] = result[0] * -first.X + result[1] * -first.Y;
            return result;
        }

        /// <summary>
        /// Вычисляет координату Y точки, лежащей на данной прямой, по общему уравнению этой прямой и координате X.
        /// </summary>
        /// <param name="lineEquation">Общее уравнение прямой.</param>
        /// <param name="X">Координата X</param>
        /// <returns>Координата Y</returns>
        static public float GetY(float[] lineEquation,float X)
        {
            if(lineEquation.Count() != 3)
            {
                throw new ArgumentException("Wrong equation format.");
            }
            return -(lineEquation[0] * X + lineEquation[2]) / lineEquation[1];
        }

        /// <summary>
        /// Проверяет, находится ли данная точка на прямой, заданной данным общим уравнением прямой.
        /// </summary>
        /// <param name="lineEquation">Общее уравнение прямой.</param>
        /// <param name="point">Точка для проверки</param>
        /// <returns></returns>
        static public bool Contains(float[] lineEquation, PointF point)
        {
            return point.Y == GetY(lineEquation, point.X);
        }

        /// <summary>
        /// Проверяет, находится ли данная точка на данном отрезке.
        /// </summary>
        /// <param name="start">Координата начала отрезка.</param>
        /// <param name="end">Координата конца отрезка.</param>
        /// <param name="point">Точка для проверки.</param>
        /// <returns></returns>
        static public bool SegmentContains(PointF start, PointF end,PointF point)
        {
            if (start.X == end.X && start.Y == end.Y)
            {
                throw new ArgumentException("Points are equal");
            }

            return point.X>=Math.Min(start.X,end.X) &&
                   point.X<=Math.Max(start.X, end.X)&&
                   point.Y>= Math.Min(start.Y, end.Y) &&
                   point.Y<= Math.Max(start.Y, end.Y) &&
                   point.Y == GetY(GetLineEquation(start,end), point.X);
        }

        /// <summary>
        /// Вычисляет уравнение перпендикуляра к данной прямой, проходящего через заданную точку.
        /// Общее уравнение прямой - A*x+B*y+C=0
        /// </summary>
        /// <param name="lineEquation">Общее уравнение первой прямой</param>
        /// <param name="point">Точка, через которую проходит перепендикуляр.</param>
        /// <returns>
        /// result[0] - коэффициент A
        /// result[1] - коэффициент B
        /// result[2] - коэффициент c
        /// </returns>
        static public float[] GetNormal(float[] lineEquation,PointF point)
        {
            float[] result = new float[3];
            result[0] = lineEquation[1];
            result[1] = lineEquation[0];
            result[2] = result[1] * -point.X + result[0] * -point.Y;
            return result;
        }

        /// <summary>
        /// Вычисляет точку пересечения двух прямых по их уравнениям.
        /// Если прямые параллельны, будет выброшено исключение DividedByZeroException.
        /// </summary>
        /// <param name="first">Общее уравнение первой прямой.</param>
        /// <param name="second">Общее уравнение второй прямой.</param>
        /// <returns></returns>
        static public PointF Intersection(float[] first, float[] second)
        {
            PointF point = new PointF();

            if(first[0]==second[0] && 
                first[1] == second[1] &&
                first[2] == second[2])
            {
                throw new ArgumentException("Lines are the same");
            }

            float del = -second[1] * first[0] - second[0];
            if (del == 0)
            {
                throw new DivideByZeroException("Lines are parallel");
            }
            point.X = (second[2] + second[1] * first[2]) / del;
            point.Y = (-first[2] - first[0] * point.X) / first[1];
            return point;

        }


    }
}
