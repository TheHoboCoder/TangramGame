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
            //if(first.X==second.X && first.Y == second.Y)
            //{
            //    throw new ArgumentException("Points are equal");
            //}

            return (float)Math.Sqrt(Math.Pow(second.X - first.X, 2) + Math.Pow(second.Y - first.Y, 2));
        }

        /// <summary>
        /// Общее уравнение прямой - A*x+B*y+C=0
        /// </summary>
        public struct LineEquation
        {
            public float Ax;
            public float By;
            public float C;
        }
        /// <summary>
        /// Возвращает общее уравнение прямой, проходящей через данные точки.
        /// Общее уравнение прямой - A*x+B*y+C=0
        /// </summary>
        /// <param name="first">Точка X1</param>
        /// <param name="second">Точка X2</param>
        /// <returns>
        /// </returns>
        static public LineEquation GetLineEquation(PointF first, PointF second)
        {
            //if (first.X == second.X && first.Y == second.Y)
            //{
            //    throw new ArgumentException("Points are equal");
            //}

            float[] result = new float[3];

            LineEquation line = new LineEquation();
            line.Ax = second.Y - first.Y;
            line.By = -(second.X - first.X);
            line.C = line.Ax * -first.X + line.By * -first.Y;
            return line;
        }

        /// <summary>
        /// Вычисляет координату Y точки, лежащей на данной прямой, по общему уравнению этой прямой и координате X.
        /// </summary>
        /// <param name="lineEquation">Общее уравнение прямой.</param>
        /// <param name="X">Координата X</param>
        /// <returns>Координата Y</returns>
        static public float GetY(LineEquation lineEquation,float X)
        {
            return -(lineEquation.Ax * X + lineEquation.C) / lineEquation.By;
        }

        /// <summary>
        /// Проверяет, находится ли данная точка на прямой, заданной данным общим уравнением прямой.
        /// </summary>
        /// <param name="lineEquation">Общее уравнение прямой.</param>
        /// <param name="point">Точка для проверки</param>
        /// <returns></returns>
        static public bool Contains(LineEquation lineEquation, PointF point)
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
        /// </returns>
        static public LineEquation GetNormal(LineEquation lineEquation,PointF point)
        {
            LineEquation result = new LineEquation();
            result.Ax = lineEquation.By;
            result.By = lineEquation.Ax;
            result.C = result.By * -point.X + result.Ax * -point.Y;
            return result;
        }

        /// <summary>
        /// Вычисляет точку пересечения двух прямых по их уравнениям.
        /// Если прямые параллельны, будет выброшено исключение DividedByZeroException.
        /// </summary>
        /// <param name="first">Общее уравнение первой прямой.</param>
        /// <param name="second">Общее уравнение второй прямой.</param>
        /// <returns></returns>
        static public PointF Intersection(LineEquation first, LineEquation second)
        {
            PointF point = new PointF();

            if(first.Ax==second.Ax && 
                first.By == second.By &&
                first.C == second.C)
            {
                throw new ArgumentException("Lines are the same");
            }

            float del = -second.By * first.Ax - second.Ax;
            if (del == 0)
            {
                throw new DivideByZeroException("Lines are parallel");
            }
            point.X = (second.C + second.By * first.C) / del;
            point.Y = (-first.C - first.Ax * point.X) / first.By;
            return point;

        }


        public struct IntersectionResult
        {
            public bool intersects;
            public PointF snapPoint;
            public bool snapped;
        }

        static public IntersectionResult CAT_Intersects(PointF[] polygon, PointF[] move_polygon,float snapValue)
        {
            int pointIndex = 0;
            int polygonCount = polygon.Count();
            int movePolygonCount = move_polygon.Count();

            IntersectionResult result = new IntersectionResult();
            result.intersects = false;
            result.snapped = false;
            result.snapPoint = new PointF();
            float lastSnapDistance = 0;

            bool decending = false;
            bool vertical = false;

            while (pointIndex+1 < polygonCount)
            {
                decending = false;
                vertical = false;

                LineEquation lineEq = GetLineEquation(polygon[pointIndex], polygon[pointIndex + 1]);
                LineEquation normal = GetNormal(lineEq, polygon[pointIndex]);

                if (normal.By == 0)
                {
                    vertical = true;
                }
                else
                {
                    decending = -normal.Ax/ normal.By <0;
                }

                PolygonProjection first = getPolygonProjection(polygon, pointIndex, normal, vertical, decending, polygon[pointIndex]);
                PolygonProjection second = getPolygonProjection(move_polygon, pointIndex, normal, vertical, decending, polygon[pointIndex]);

                if (vertical||!decending)
                {
                    if (first.startPoint.Y > second.startPoint.Y)
                    {
                        //intersects tho
                        if (second.startPoint.Y < first.endPoint.Y)
                        {
                            result.intersects = true;
                        }
                        else
                        {
                            result.intersects = false;
                            float distance = GetDistance(second.startPoint, first.endPoint);
                            if (distance <= snapValue)
                            {
                                if (second.startPoints.Count == 1 && first.endPoints.Count == 2)
                                {
                                        LineEquation eq = GetLineEquation(first.endPoints[0], first.endPoints[1]);
                                        if (!result.snapped || lastSnapDistance > distance)
                                        {
                                            result.snapped = true;
                                            result.snapPoint = Intersection(eq, GetNormal(eq, second.startPoints[0]));
                                            lastSnapDistance = distance;
                                        }

                                }
                                else
                                {
                                    float minDistance = 1000000;
                                    PointF choosenPoint = new PointF();
                                    for (int i = 0; i < second.startPoints.Count(); i++)
                                    {
                                        for (int y = 0; y < first.endPoints.Count(); y++)
                                        {
                                            float dist = GetDistance(second.startPoints[i], first.endPoints[i]);
                                            if (dist < minDistance)
                                            {
                                                minDistance = dist;
                                                choosenPoint = first.endPoints[i];
                                            }
                                        }
                                    }

                                    if (minDistance <= snapValue)
                                    {
                                        if (!result.snapped|| lastSnapDistance > minDistance)
                                        {
                                            result.snapped = true;
                                            lastSnapDistance = minDistance;
                                            result.snapPoint = choosenPoint;
                                        }

                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        if (first.startPoint.Y < second.endPoint.Y)
                        {
                            result.intersects = true;
                            break;
                        }
                        else
                        {
                            result.intersects = false;
                            float distance = GetDistance(first.startPoint, second.endPoint);
                            if (distance <= snapValue)
                            {
                                if (second.endPoints.Count == 1 && first.startPoints.Count == 2)
                                {
                                    LineEquation eq = GetLineEquation(first.startPoints[0], first.startPoints[1]);
                                    if (!result.snapped || lastSnapDistance > distance)
                                    {
                                        result.snapped = true;
                                        result.snapPoint = Intersection(eq, GetNormal(eq, second.endPoints[0]));
                                        lastSnapDistance = distance;
                                    }

                                }
                                else
                                {
                                    float minDistance = 1000000;
                                    PointF choosenPoint = new PointF();
                                    for (int i = 0; i < second.endPoints.Count(); i++)
                                    {
                                        for (int y = 0; y < first.startPoints.Count(); y++)
                                        {
                                            float dist = GetDistance(second.endPoints[i], first.startPoints[i]);
                                            if (dist < minDistance)
                                            {
                                                minDistance = dist;
                                                choosenPoint = first.startPoints[i];
                                            }
                                        }
                                    }

                                    if (minDistance <= snapValue)
                                    {
                                        if (!result.snapped || lastSnapDistance > minDistance)
                                        {
                                            result.snapped = true;
                                            lastSnapDistance = minDistance;
                                            result.snapPoint = choosenPoint;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (first.startPoint.Y < second.startPoint.Y)
                    {
                        //intersects tho
                        if (second.startPoint.Y > first.endPoint.Y)
                        {
                            result.intersects = true;
                        }
                        else
                        {
                            result.intersects = false;
                            float distance = GetDistance(second.startPoint, first.endPoint);
                            if (distance <= snapValue)
                            {
                                if (second.startPoints.Count == 1 && first.endPoints.Count == 2)
                                {
                                    LineEquation eq = GetLineEquation(first.endPoints[0], first.endPoints[1]);
                                    if (!result.snapped || lastSnapDistance > distance)
                                    {
                                        result.snapped = true;
                                        result.snapPoint = Intersection(eq, GetNormal(eq, second.startPoints[0]));
                                        lastSnapDistance = distance;
                                    }

                                }
                                else
                                {
                                    float minDistance = 1000000;
                                    PointF choosenPoint = new PointF();
                                    for (int i = 0; i < second.startPoints.Count(); i++)
                                    {
                                        for (int y = 0; y < first.endPoints.Count(); y++)
                                        {
                                            float dist = GetDistance(second.startPoints[i], first.endPoints[i]);
                                            if (dist < minDistance)
                                            {
                                                minDistance = dist;
                                                choosenPoint = first.endPoints[i];
                                            }
                                        }
                                    }

                                    if (minDistance <= snapValue)
                                    {
                                        if (!result.snapped || lastSnapDistance > minDistance)
                                        {
                                            result.snapped = true;
                                            lastSnapDistance = minDistance;
                                            result.snapPoint = choosenPoint;
                                        }

                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (first.startPoint.Y > second.endPoint.Y)
                        {
                            result.intersects = true;
                        }
                        else
                        {
                            result.intersects = false;
                            float distance = GetDistance(first.startPoint, second.endPoint);
                            if (distance <= snapValue)
                            {
                                if (second.endPoints.Count == 1 && first.startPoints.Count == 2)
                                {
                                    LineEquation eq = GetLineEquation(first.startPoints[0], first.startPoints[1]);
                                    if (!result.snapped || lastSnapDistance > distance)
                                    {
                                        result.snapped = true;
                                        result.snapPoint = Intersection(eq, GetNormal(eq, second.endPoints[0]));
                                        lastSnapDistance = distance;
                                    }

                                }
                                else
                                {
                                    float minDistance = 1000000;
                                    PointF choosenPoint = new PointF();
                                    for (int i = 0; i < second.endPoints.Count(); i++)
                                    {
                                        for (int y = 0; y < first.startPoints.Count(); y++)
                                        {
                                            float dist = GetDistance(second.endPoints[i], first.startPoints[i]);
                                            if (dist < minDistance)
                                            {
                                                minDistance = dist;
                                                choosenPoint = first.startPoints[i];
                                            }
                                        }
                                    }

                                    if (minDistance <= snapValue)
                                    {
                                        if (!result.snapped || lastSnapDistance > minDistance)
                                        {
                                            result.snapped = true;
                                            lastSnapDistance = minDistance;
                                            result.snapPoint = choosenPoint;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }

                pointIndex++;  
            }

            pointIndex = 0;
            while (pointIndex + 1 < movePolygonCount)
            {
                decending = false;
                vertical = false;

                LineEquation lineEq = GetLineEquation(move_polygon[pointIndex], move_polygon[pointIndex + 1]);
                LineEquation normal = GetNormal(lineEq, move_polygon[pointIndex]);

                if (normal.By == 0)
                {
                    vertical = true;
                }
                else
                {
                    decending = -normal.Ax / normal.By < 0;
                }

                PolygonProjection first = getPolygonProjection(polygon, pointIndex, normal, vertical, decending, polygon[pointIndex]);
                PolygonProjection second = getPolygonProjection(move_polygon, pointIndex, normal, vertical, decending, polygon[pointIndex]);

                if (vertical || !decending)
                {
                    if (first.startPoint.Y > second.startPoint.Y)
                    {
                        //intersects tho
                        if (second.startPoint.Y < first.endPoint.Y)
                        {
                            result.intersects = true;
                        }
                        else
                        {
                            result.intersects = false;
                            float distance = GetDistance(second.startPoint, first.endPoint);
                            if (distance <= snapValue)
                            {
                                if (second.startPoints.Count == 1 && first.endPoints.Count == 2)
                                {
                                    LineEquation eq = GetLineEquation(first.endPoints[0], first.endPoints[1]);
                                    if (!result.snapped || lastSnapDistance > distance)
                                    {
                                        result.snapped = true;
                                        result.snapPoint = Intersection(eq, GetNormal(eq, second.startPoints[0]));
                                        lastSnapDistance = distance;
                                    }

                                }
                                else
                                {
                                    float minDistance = 1000000;
                                    PointF choosenPoint = new PointF();
                                    for (int i = 0; i < second.startPoints.Count(); i++)
                                    {
                                        for (int y = 0; y < first.endPoints.Count(); y++)
                                        {
                                            float dist = GetDistance(second.startPoints[i], first.endPoints[i]);
                                            if (dist < minDistance)
                                            {
                                                minDistance = dist;
                                                choosenPoint = first.endPoints[i];
                                            }
                                        }
                                    }

                                    if (minDistance <= snapValue)
                                    {
                                        if (!result.snapped || lastSnapDistance > minDistance)
                                        {
                                            result.snapped = true;
                                            lastSnapDistance = minDistance;
                                            result.snapPoint = choosenPoint;
                                        }

                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        if (first.startPoint.Y < second.endPoint.Y)
                        {
                            result.intersects = true;
                        }
                        else
                        {
                            result.intersects = false;
                            float distance = GetDistance(first.startPoint, second.endPoint);
                            if (distance <= snapValue)
                            {
                                if (second.endPoints.Count == 1 && first.startPoints.Count == 2)
                                {
                                    LineEquation eq = GetLineEquation(first.startPoints[0], first.startPoints[1]);
                                    if (!result.snapped || lastSnapDistance > distance)
                                    {
                                        result.snapped = true;
                                        result.snapPoint = Intersection(eq, GetNormal(eq, second.endPoints[0]));
                                        lastSnapDistance = distance;
                                    }

                                }
                                else
                                {
                                    float minDistance = 1000000;
                                    PointF choosenPoint = new PointF();
                                    for (int i = 0; i < second.endPoints.Count(); i++)
                                    {
                                        for (int y = 0; y < first.startPoints.Count(); y++)
                                        {
                                            float dist = GetDistance(second.endPoints[i], first.startPoints[i]);
                                            if (dist < minDistance)
                                            {
                                                minDistance = dist;
                                                choosenPoint = first.startPoints[i];
                                            }
                                        }
                                    }

                                    if (minDistance <= snapValue)
                                    {
                                        if (!result.snapped || lastSnapDistance > minDistance)
                                        {
                                            result.snapped = true;
                                            lastSnapDistance = minDistance;
                                            result.snapPoint = choosenPoint;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (first.startPoint.Y < second.startPoint.Y)
                    {
                        //intersects tho
                        if (second.startPoint.Y > first.endPoint.Y)
                        {
                            result.intersects = true;
                        }
                        else
                        {
                            result.intersects = false;
                            float distance = GetDistance(second.startPoint, first.endPoint);
                            if (distance <= snapValue)
                            {
                                if (second.startPoints.Count == 1 && first.endPoints.Count == 2)
                                {
                                    LineEquation eq = GetLineEquation(first.endPoints[0], first.endPoints[1]);
                                    if (!result.snapped || lastSnapDistance > distance)
                                    {
                                        result.snapped = true;
                                        result.snapPoint = Intersection(eq, GetNormal(eq, second.startPoints[0]));
                                        lastSnapDistance = distance;
                                    }

                                }
                                else
                                {
                                    float minDistance = 1000000;
                                    PointF choosenPoint = new PointF();
                                    for (int i = 0; i < second.startPoints.Count(); i++)
                                    {
                                        for (int y = 0; y < first.endPoints.Count(); y++)
                                        {
                                            float dist = GetDistance(second.startPoints[i], first.endPoints[i]);
                                            if (dist < minDistance)
                                            {
                                                minDistance = dist;
                                                choosenPoint = first.endPoints[i];
                                            }
                                        }
                                    }

                                    if (minDistance <= snapValue)
                                    {
                                        if (!result.snapped || lastSnapDistance > minDistance)
                                        {
                                            result.snapped = true;
                                            lastSnapDistance = minDistance;
                                            result.snapPoint = choosenPoint;
                                        }

                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (first.startPoint.Y > second.endPoint.Y)
                        {
                            result.intersects = true;
                        }
                        else
                        {
                            result.intersects = false;
                            float distance = GetDistance(first.startPoint, second.endPoint);
                            if (distance <= snapValue)
                            {
                                if (second.endPoints.Count == 1 && first.startPoints.Count == 2)
                                {
                                    LineEquation eq = GetLineEquation(first.startPoints[0], first.startPoints[1]);
                                    if (!result.snapped || lastSnapDistance > distance)
                                    {
                                        result.snapped = true;
                                        result.snapPoint = Intersection(eq, GetNormal(eq, second.endPoints[0]));
                                        lastSnapDistance = distance;
                                    }

                                }
                                else
                                {
                                    float minDistance = 1000000;
                                    PointF choosenPoint = new PointF();
                                    for (int i = 0; i < second.endPoints.Count(); i++)
                                    {
                                        for (int y = 0; y < first.startPoints.Count(); y++)
                                        {
                                            float dist = GetDistance(second.endPoints[i], first.startPoints[i]);
                                            if (dist < minDistance)
                                            {
                                                minDistance = dist;
                                                choosenPoint = first.startPoints[i];
                                            }
                                        }
                                    }

                                    if (minDistance <= snapValue)
                                    {
                                        if (!result.snapped || lastSnapDistance > minDistance)
                                        {
                                            result.snapped = true;
                                            lastSnapDistance = minDistance;
                                            result.snapPoint = choosenPoint;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }

                pointIndex++;
            }


            return result;
        }

        


        private struct PolygonProjection
        {
            public PointF startPoint;
            public PointF endPoint;
            public List<PointF> startPoints;
            public List<PointF> endPoints;
        }

        static private PolygonProjection getPolygonProjection(PointF[] polygon, int index, LineEquation normal, bool vertical, bool decending,  PointF point)
        {

            PointF lastPoint = new PointF();
            PolygonProjection result = new PolygonProjection();
            result.startPoint = point;
            result.endPoint = point;
            result.startPoints = new List<PointF>();
            result.endPoints = new List<PointF>();

            for (int i = index + 2, polygonCount = polygon.Count(); i < polygonCount; i++)
            {
                bool online = false;
                PointF projection = Intersection(GetNormal(normal, polygon[i]), normal);

                if (i != index + 2)
                {
                    if (lastPoint.X == result.endPoint.X && lastPoint.Y == result.endPoint.Y)
                    {
                        result.endPoints.Add(polygon[i]);
                    }

                    if (lastPoint.X == result.startPoint.X && lastPoint.Y == result.startPoint.Y)
                    {
                        result.startPoints.Add(polygon[i]);
                    }
                }

                if (vertical)
                {
                    if (projection.Y > result.endPoint.Y)
                    {
                        result.endPoint.X = projection.X;
                        result.endPoint.Y = projection.Y;
                        result.endPoints.Clear();
                        result.endPoints.Add(polygon[i]);
                    }

                    if (projection.Y < result.startPoint.Y)
                    {
                        result.startPoint.X = projection.X;
                        result.startPoint.Y = projection.Y;
                    }
                }
                else
                {
                    if (decending)
                    {
                        if (projection.Y < result.endPoint.Y)
                        {
                            result.endPoint.X = projection.X;
                            result.endPoint.Y = projection.Y;
                            result.endPoints.Clear();
                            result.endPoints.Add(polygon[i]);
                        }

                        if (projection.Y > result.startPoint.Y)
                        {
                            result.startPoint.X = projection.X;
                            result.startPoint.Y = projection.Y;
                        }
                    }
                    else
                    {
                        if (projection.Y > result.endPoint.Y)
                        {
                            result.endPoint.X = projection.X;
                            result.endPoint.Y = projection.Y;
                            result.endPoints.Clear();
                            result.endPoints.Add(polygon[i]);
                        }

                        if (projection.Y < result.startPoint.Y)
                        {
                            result.startPoint.X = projection.X;
                            result.startPoint.Y = projection.Y;
                        }
                    }
                }

                lastPoint = projection;
               
            }
            return result;
        }
        

    }
}
