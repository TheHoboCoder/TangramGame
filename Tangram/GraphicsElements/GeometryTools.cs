using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.GraphicsElements
{
    public static class GeometryTools
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
            result.By = -lineEquation.Ax;
            result.C = lineEquation.By * -point.X + lineEquation.Ax * point.Y;//возможно, неправильно считает

            return result;
        }

        public class LinesIsParallelException : ArgumentException
        {
            public LinesIsParallelException() : base("Lines are parallel or are same")
            {

            }
        }
        /// <summary>
        /// Вычисляет точку пересечения двух прямых по их уравнениям.
        /// Если прямые параллельны или одинаковы, будет выброшено исключение LinesIsParallelException.
        /// </summary>
        /// <param name="first">Общее уравнение первой прямой.</param>
        /// <param name="second">Общее уравнение второй прямой.</param>
        /// <returns></returns>
        static public PointF Intersection(LineEquation first, LineEquation second)
        {
            PointF point = new PointF();

            double p = first.Ax / second.Ax;

            if( second.By * p == first.By || (second.By == 0 && first.By == 0))
            {
                throw new LinesIsParallelException();
            }

            if(first.By == 0)
            {
                point.X = -first.C / first.Ax;
                point.Y = -(second.C +point.X * second.Ax) / second.By;
                return point;
            }

            if(second.By == 0)
            {
                point.X = -second.C / second.Ax;
                point.Y = -(first.C +point.X * first.Ax) / first.By;
                return point;
            }


           
                double operand2 = first.Ax + (second.Ax * first.By) /  -second.By;
                if(operand2 == 0)
                {
                    throw new LinesIsParallelException();
                }
                double operand1 = -first.C - (second.C * first.By) / -second.By;
                double x = operand1 / operand2;
                double y = (-first.C - first.Ax * x) / first.By; //TODO: division by zero
                point.X = (float)x;
                point.Y = (float)y;


            //if(first.Ax==second.Ax && 
            //    first.By == second.By &&
            //    first.C == second.C)
            //{
            //    throw new ArgumentException("Lines are the same");
            //}

            //float del = -second.By * first.Ax - second.Ax;
            //if (del == 0)
            //{
            //    throw new DivideByZeroException("Lines are parallel");
            //}
            //point.X = (second.C + second.By * first.C) / del;
            //point.Y = (-first.C - first.Ax * point.X) / first.By;
            return point;

        }


        public struct IntersectionResult
        {
            public bool intersects;
            public bool snapped;
            public PointF snapPoint;
            public PointF translateVector;
            public float distance;

        }

        static public IntersectionResult SAT_intersects(PointF[] testPolygon, PointF[] staticPolygon,float snapDistance)
        {
            IntersectionResult result = new IntersectionResult();
            result.intersects = false;
            result.snapped = false;
            result.snapPoint = new PointF();
            result.translateVector = new PointF();
            result.distance = float.MaxValue;

            bool firstTime = true;

            for (int i = 0, count = testPolygon.Count(); i<count-1; i++)
            {
                LineEquation eq = GetLineEquation(testPolygon[i], testPolygon[i + 1]);
                LineEquation normal = GetNormal(eq, testPolygon[i]);

                PolygonProjection testProjection = GetProjection(testPolygon, normal, i);
                PolygonProjection staticProjection = GetProjection(staticPolygon, normal);

                IntersectionResult res = new IntersectionResult();

                if (normal.By == 0)
                {
                    if (testProjection.startPoint.Y <= staticProjection.startPoint.Y)
                    {
                        res = PolygonIntersection(staticProjection.startPoint,
                                                                    testProjection.endPoint,
                                                                    true,
                                                                    testProjection.endPoints,
                                                                    staticProjection.startPoints,
                                                                    snapDistance);

                    }
                    else
                    {
                        res = PolygonIntersection(testProjection.startPoint,
                                                                 staticProjection.endPoint,
                                                                 true,
                                                                 staticProjection.endPoints,
                                                                 testProjection.startPoints,
                                                                 snapDistance);
                    }
                }
                else
                {
                    if (testProjection.startPoint.X <= staticProjection.startPoint.X)
                    {
                         res = PolygonIntersection(staticProjection.startPoint,
                                                                     testProjection.endPoint,
                                                                     false,
                                                                     testProjection.endPoints,
                                                                     staticProjection.startPoints,
                                                                     snapDistance);

                    }
                    else
                    {
                         res = PolygonIntersection(testProjection.startPoint,
                                                                  staticProjection.endPoint,
                                                                  false,
                                                                  staticProjection.endPoints,
                                                                  testProjection.startPoints,
                                                                  snapDistance);
                    }
                }

                if (firstTime)
                {
                    result = res;
                    firstTime = false;
                    continue;
                }

                //TODO
                if(!res.intersects && result.intersects)
                {
                    result = res;
                }
                else
                {
                    if(res.snapped && !result.snapped)
                    {
                        result = res;
                    }

                    if(res.snapped && result.snapped && res.distance < result.distance)
                    {
                        result = res;
                    }
                }
                
            }

            //firstTime = true;

            for (int i = 0, count = staticPolygon.Count(); i < count - 1; i++)
            {
                LineEquation eq = GetLineEquation(staticPolygon[i], staticPolygon[i + 1]);
                LineEquation normal = GetNormal(eq, staticPolygon[i]);

                PolygonProjection testProjection = GetProjection(testPolygon, normal);
                PolygonProjection staticProjection = GetProjection(staticPolygon, normal,i);

                IntersectionResult res = new IntersectionResult();

                if (normal.By == 0)
                {
                    if (testProjection.startPoint.Y <= staticProjection.startPoint.Y)
                    {
                        res = PolygonIntersection(staticProjection.startPoint,
                                                                    testProjection.endPoint,
                                                                    true,
                                                                    testProjection.endPoints,
                                                                    staticProjection.startPoints,
                                                                    snapDistance);

                    }
                    else
                    {
                        res = PolygonIntersection(testProjection.startPoint,
                                                                 staticProjection.endPoint,
                                                                 true,
                                                                 staticProjection.endPoints,
                                                                 testProjection.startPoints,
                                                                 snapDistance);
                    }
                }
                else
                {
                    if (testProjection.startPoint.X <= staticProjection.startPoint.X)
                    {
                        res = PolygonIntersection(staticProjection.startPoint,
                                                                    testProjection.endPoint,
                                                                    false,
                                                                    testProjection.endPoints,
                                                                    staticProjection.startPoints,
                                                                    snapDistance);

                    }
                    else
                    {
                        res = PolygonIntersection(testProjection.startPoint,
                                                                 staticProjection.endPoint,
                                                                 false,
                                                                 staticProjection.endPoints,
                                                                 testProjection.startPoints,
                                                                 snapDistance);
                    }
                }

                //if (firstTime)
                //{
                //    result = res;
                //    firstTime = false;
                //    continue;
                //}

                if (!res.intersects && result.intersects)
                {
                    result = res;
                }
                else
                {
                    if (res.snapped && !result.snapped)
                    {
                        result = res;
                    }

                    if (res.snapped && result.snapped && res.distance < result.distance)
                    {
                        result = res;
                    }
                }

            }


            return result;
        }

        static public IntersectionResult PolygonIntersection(PointF startPoint, PointF endPoint, bool vertical, List<PointF> testPolygonPoints, List<PointF> staticPolygonPoints, float snapDistance)
        {
            IntersectionResult intersection = new IntersectionResult();

            intersection.intersects = false;
            intersection.snapped = false;
            intersection.snapPoint = new PointF();
            intersection.translateVector = new PointF();
            intersection.distance = float.MaxValue;


            intersection.distance = GetDistance(startPoint, endPoint);

            if (vertical)
            {
                if (startPoint.Y < endPoint.Y)
                {
                    intersection.intersects = true;
                    //intersection.translateVector = new PointF(endPoint.X -startPoint.X, endPoint.Y-startPoint.Y);
                    intersection.translateVector = new PointF( startPoint.X - endPoint.X, startPoint.Y - endPoint.Y);
                    return intersection;
                }
            }
            else
            {
                if (startPoint.X < endPoint.X)
                {
                    intersection.intersects = true;
                    //intersection.translateVector = new PointF(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
                    intersection.translateVector = new PointF(startPoint.X - endPoint.X, startPoint.Y - endPoint.Y);
                    return intersection;
                }
            }

            if ( snapDistance>=intersection.distance)
            {
                if (staticPolygonPoints.Count() == 1)
                {
                    if (testPolygonPoints.Count() == 1)
                    {
                        float distance = GetDistance(staticPolygonPoints[0], testPolygonPoints[0]);
                        if (distance <= snapDistance)
                        {
                            intersection.snapped = true;
                            intersection.snapPoint = staticPolygonPoints[0];
                            intersection.translateVector = new PointF(staticPolygonPoints[0].X - testPolygonPoints[0].X,
                                                                      staticPolygonPoints[0].Y - testPolygonPoints[0].Y);
                        }
                    }
                    else
                    {
                        LineEquation eq = GetLineEquation(testPolygonPoints[0], testPolygonPoints[1]);
                        LineEquation normal = GetNormal(eq, staticPolygonPoints[0]);
                        PointF point = Intersection(eq, normal);

                        if (point.X >= Math.Min(testPolygonPoints[0].X, testPolygonPoints[1].X) &&
                           point.X <= Math.Max(testPolygonPoints[0].X, testPolygonPoints[1].X) &&
                           point.Y >= Math.Min(testPolygonPoints[0].Y, testPolygonPoints[1].Y) &&
                           point.Y <= Math.Max(testPolygonPoints[0].Y, testPolygonPoints[1].Y))
                        {
                            intersection.snapped = true;
                            intersection.snapPoint = point;
                            intersection.translateVector = new PointF(staticPolygonPoints[0].X - point.X,
                                                                      staticPolygonPoints[0].Y - point.Y);
                        }
                        else
                        {
                            for (int i = 0, count = testPolygonPoints.Count(); i < count; i++)
                            {
                                float distance = GetDistance(staticPolygonPoints[0], testPolygonPoints[i]);
                                if (distance <= snapDistance)
                                {
                                    intersection.snapped = true;
                                    intersection.snapPoint = staticPolygonPoints[0];
                                    intersection.translateVector = new PointF(staticPolygonPoints[0].X - testPolygonPoints[i].X,
                                                                              staticPolygonPoints[0].Y - testPolygonPoints[i].Y);
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0, count = testPolygonPoints.Count(); i < count; i++)
                    {
                        LineEquation eq = GetLineEquation(staticPolygonPoints[0], staticPolygonPoints[1]);
                        LineEquation normal = GetNormal(eq, testPolygonPoints[i]);
                        PointF point = Intersection(eq, normal);

                        if (point.X >= Math.Min(staticPolygonPoints[0].X, staticPolygonPoints[1].X) &&
                           point.X <= Math.Max(staticPolygonPoints[0].X, staticPolygonPoints[1].X) &&
                           point.Y >= Math.Min(staticPolygonPoints[0].Y, staticPolygonPoints[1].Y) &&
                           point.Y <= Math.Max(staticPolygonPoints[0].Y, staticPolygonPoints[1].Y))
                        {
                            intersection.snapped = true;
                            intersection.snapPoint = point;
                            intersection.translateVector = new PointF( point.X-testPolygonPoints[i].X,
                                                                      point.Y -staticPolygonPoints[i].Y);
                        }
                        else
                        {
                            float distance = GetDistance(staticPolygonPoints[0], testPolygonPoints[i]);
                            if (distance <= snapDistance)
                            {
                                intersection.snapped = true;
                                intersection.snapPoint = staticPolygonPoints[0];
                                intersection.translateVector = new PointF(staticPolygonPoints[0].X - testPolygonPoints[i].X,
                                                                          staticPolygonPoints[0].Y - testPolygonPoints[i].Y);
                            }
                        }
                    }
                }
            }


            return intersection;
        }



        //static public IntersectionResult CAT_Intersects(PointF[] polygon, PointF[] move_polygon,float snapValue)
        //{
        //    int pointIndex = 0;
        //    int polygonCount = polygon.Count();
        //    int movePolygonCount = move_polygon.Count();

        //    IntersectionResult result = new IntersectionResult();
        //    result.intersects = false;
        //    result.snapped = false;
        //    result.snapPoint = new PointF();
        //    float lastSnapDistance = 0;

        //    bool decending = false;
        //    bool vertical = false;

        //    while (pointIndex+1 < polygonCount)
        //    {
        //        decending = false;
        //        vertical = false;

        //        LineEquation lineEq = GetLineEquation(polygon[pointIndex], polygon[pointIndex + 1]);
        //        LineEquation normal = GetNormal(lineEq, polygon[pointIndex]);

        //        if (normal.By == 0)
        //        {
        //            vertical = true;
        //        }
        //        else
        //        {
        //            decending = -normal.Ax/ normal.By <0;
        //        }

        //        PolygonProjection first = getPolygonProjection(polygon, pointIndex, normal, vertical, decending, polygon[pointIndex]);
        //        PolygonProjection second = getPolygonProjection(move_polygon, pointIndex, normal, vertical, decending, polygon[pointIndex]);

        //        if (vertical||!decending)
        //        {
        //            if (first.startPoint.Y > second.startPoint.Y)
        //            {
        //                //intersects tho
        //                if (second.startPoint.Y < first.endPoint.Y)
        //                {
        //                    result.intersects = true;
        //                }
        //                else
        //                {
        //                    result.intersects = false;
        //                    float distance = GetDistance(second.startPoint, first.endPoint);
        //                    if (distance <= snapValue)
        //                    {
        //                        if (second.startPoints.Count == 1 && first.endPoints.Count == 2)
        //                        {
        //                                LineEquation eq = GetLineEquation(first.endPoints[0], first.endPoints[1]);
        //                                if (!result.snapped || lastSnapDistance > distance)
        //                                {
        //                                    result.snapped = true;
        //                                    result.snapPoint = Intersection(eq, GetNormal(eq, second.startPoints[0]));
        //                                    lastSnapDistance = distance;
        //                                }

        //                        }
        //                        else
        //                        {
        //                            float minDistance = 1000000;
        //                            PointF choosenPoint = new PointF();
        //                            for (int i = 0; i < second.startPoints.Count(); i++)
        //                            {
        //                                for (int y = 0; y < first.endPoints.Count(); y++)
        //                                {
        //                                    float dist = GetDistance(second.startPoints[i], first.endPoints[i]);
        //                                    if (dist < minDistance)
        //                                    {
        //                                        minDistance = dist;
        //                                        choosenPoint = first.endPoints[i];
        //                                    }
        //                                }
        //                            }

        //                            if (minDistance <= snapValue)
        //                            {
        //                                if (!result.snapped|| lastSnapDistance > minDistance)
        //                                {
        //                                    result.snapped = true;
        //                                    lastSnapDistance = minDistance;
        //                                    result.snapPoint = choosenPoint;
        //                                }

        //                            }
        //                        }
        //                    }

        //                }
        //            }
        //            else
        //            {
        //                if (first.startPoint.Y < second.endPoint.Y)
        //                {
        //                    result.intersects = true;
        //                    break;
        //                }
        //                else
        //                {
        //                    result.intersects = false;
        //                    float distance = GetDistance(first.startPoint, second.endPoint);
        //                    if (distance <= snapValue)
        //                    {
        //                        if (second.endPoints.Count == 1 && first.startPoints.Count == 2)
        //                        {
        //                            LineEquation eq = GetLineEquation(first.startPoints[0], first.startPoints[1]);
        //                            if (!result.snapped || lastSnapDistance > distance)
        //                            {
        //                                result.snapped = true;
        //                                result.snapPoint = Intersection(eq, GetNormal(eq, second.endPoints[0]));
        //                                lastSnapDistance = distance;
        //                            }

        //                        }
        //                        else
        //                        {
        //                            float minDistance = 1000000;
        //                            PointF choosenPoint = new PointF();
        //                            for (int i = 0; i < second.endPoints.Count(); i++)
        //                            {
        //                                for (int y = 0; y < first.startPoints.Count(); y++)
        //                                {
        //                                    float dist = GetDistance(second.endPoints[i], first.startPoints[i]);
        //                                    if (dist < minDistance)
        //                                    {
        //                                        minDistance = dist;
        //                                        choosenPoint = first.startPoints[i];
        //                                    }
        //                                }
        //                            }

        //                            if (minDistance <= snapValue)
        //                            {
        //                                if (!result.snapped || lastSnapDistance > minDistance)
        //                                {
        //                                    result.snapped = true;
        //                                    lastSnapDistance = minDistance;
        //                                    result.snapPoint = choosenPoint;
        //                                }

        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (first.startPoint.Y < second.startPoint.Y)
        //            {
        //                //intersects tho
        //                if (second.startPoint.Y > first.endPoint.Y)
        //                {
        //                    result.intersects = true;
        //                }
        //                else
        //                {
        //                    result.intersects = false;
        //                    float distance = GetDistance(second.startPoint, first.endPoint);
        //                    if (distance <= snapValue)
        //                    {
        //                        if (second.startPoints.Count == 1 && first.endPoints.Count == 2)
        //                        {
        //                            LineEquation eq = GetLineEquation(first.endPoints[0], first.endPoints[1]);
        //                            if (!result.snapped || lastSnapDistance > distance)
        //                            {
        //                                result.snapped = true;
        //                                result.snapPoint = Intersection(eq, GetNormal(eq, second.startPoints[0]));
        //                                lastSnapDistance = distance;
        //                            }

        //                        }
        //                        else
        //                        {
        //                            float minDistance = 1000000;
        //                            PointF choosenPoint = new PointF();
        //                            for (int i = 0; i < second.startPoints.Count(); i++)
        //                            {
        //                                for (int y = 0; y < first.endPoints.Count(); y++)
        //                                {
        //                                    float dist = GetDistance(second.startPoints[i], first.endPoints[i]);
        //                                    if (dist < minDistance)
        //                                    {
        //                                        minDistance = dist;
        //                                        choosenPoint = first.endPoints[i];
        //                                    }
        //                                }
        //                            }

        //                            if (minDistance <= snapValue)
        //                            {
        //                                if (!result.snapped || lastSnapDistance > minDistance)
        //                                {
        //                                    result.snapped = true;
        //                                    lastSnapDistance = minDistance;
        //                                    result.snapPoint = choosenPoint;
        //                                }

        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (first.startPoint.Y > second.endPoint.Y)
        //                {
        //                    result.intersects = true;
        //                }
        //                else
        //                {
        //                    result.intersects = false;
        //                    float distance = GetDistance(first.startPoint, second.endPoint);
        //                    if (distance <= snapValue)
        //                    {
        //                        if (second.endPoints.Count == 1 && first.startPoints.Count == 2)
        //                        {
        //                            LineEquation eq = GetLineEquation(first.startPoints[0], first.startPoints[1]);
        //                            if (!result.snapped || lastSnapDistance > distance)
        //                            {
        //                                result.snapped = true;
        //                                result.snapPoint = Intersection(eq, GetNormal(eq, second.endPoints[0]));
        //                                lastSnapDistance = distance;
        //                            }

        //                        }
        //                        else
        //                        {
        //                            float minDistance = 1000000;
        //                            PointF choosenPoint = new PointF();
        //                            for (int i = 0; i < second.endPoints.Count(); i++)
        //                            {
        //                                for (int y = 0; y < first.startPoints.Count(); y++)
        //                                {
        //                                    float dist = GetDistance(second.endPoints[i], first.startPoints[i]);
        //                                    if (dist < minDistance)
        //                                    {
        //                                        minDistance = dist;
        //                                        choosenPoint = first.startPoints[i];
        //                                    }
        //                                }
        //                            }

        //                            if (minDistance <= snapValue)
        //                            {
        //                                if (!result.snapped || lastSnapDistance > minDistance)
        //                                {
        //                                    result.snapped = true;
        //                                    lastSnapDistance = minDistance;
        //                                    result.snapPoint = choosenPoint;
        //                                }

        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        pointIndex++;  
        //    }

        //    pointIndex = 0;
        //    while (pointIndex + 1 < movePolygonCount)
        //    {
        //        decending = false;
        //        vertical = false;

        //        LineEquation lineEq = GetLineEquation(move_polygon[pointIndex], move_polygon[pointIndex + 1]);
        //        LineEquation normal = GetNormal(lineEq, move_polygon[pointIndex]);

        //        if (normal.By == 0)
        //        {
        //            vertical = true;
        //        }
        //        else
        //        {
        //            decending = -normal.Ax / normal.By < 0;
        //        }

        //        PolygonProjection first = getPolygonProjection(polygon, pointIndex, normal, vertical, decending, polygon[pointIndex]);
        //        PolygonProjection second = getPolygonProjection(move_polygon, pointIndex, normal, vertical, decending, polygon[pointIndex]);

        //        if (vertical || !decending)
        //        {
        //            if (first.startPoint.Y > second.startPoint.Y)
        //            {
        //                //intersects tho
        //                if (second.startPoint.Y < first.endPoint.Y)
        //                {
        //                    result.intersects = true;
        //                }
        //                else
        //                {
        //                    result.intersects = false;
        //                    float distance = GetDistance(second.startPoint, first.endPoint);
        //                    if (distance <= snapValue)
        //                    {
        //                        if (second.startPoints.Count == 1 && first.endPoints.Count == 2)
        //                        {
        //                            LineEquation eq = GetLineEquation(first.endPoints[0], first.endPoints[1]);
        //                            if (!result.snapped || lastSnapDistance > distance)
        //                            {
        //                                result.snapped = true;
        //                                result.snapPoint = Intersection(eq, GetNormal(eq, second.startPoints[0]));
        //                                lastSnapDistance = distance;
        //                            }

        //                        }
        //                        else
        //                        {
        //                            float minDistance = 1000000;
        //                            PointF choosenPoint = new PointF();
        //                            for (int i = 0; i < second.startPoints.Count(); i++)
        //                            {
        //                                for (int y = 0; y < first.endPoints.Count(); y++)
        //                                {
        //                                    float dist = GetDistance(second.startPoints[i], first.endPoints[i]);
        //                                    if (dist < minDistance)
        //                                    {
        //                                        minDistance = dist;
        //                                        choosenPoint = first.endPoints[i];
        //                                    }
        //                                }
        //                            }

        //                            if (minDistance <= snapValue)
        //                            {
        //                                if (!result.snapped || lastSnapDistance > minDistance)
        //                                {
        //                                    result.snapped = true;
        //                                    lastSnapDistance = minDistance;
        //                                    result.snapPoint = choosenPoint;
        //                                }

        //                            }
        //                        }
        //                    }

        //                }
        //            }
        //            else
        //            {
        //                if (first.startPoint.Y < second.endPoint.Y)
        //                {
        //                    result.intersects = true;
        //                }
        //                else
        //                {
        //                    result.intersects = false;
        //                    float distance = GetDistance(first.startPoint, second.endPoint);
        //                    if (distance <= snapValue)
        //                    {
        //                        if (second.endPoints.Count == 1 && first.startPoints.Count == 2)
        //                        {
        //                            LineEquation eq = GetLineEquation(first.startPoints[0], first.startPoints[1]);
        //                            if (!result.snapped || lastSnapDistance > distance)
        //                            {
        //                                result.snapped = true;
        //                                result.snapPoint = Intersection(eq, GetNormal(eq, second.endPoints[0]));
        //                                lastSnapDistance = distance;
        //                            }

        //                        }
        //                        else
        //                        {
        //                            float minDistance = 1000000;
        //                            PointF choosenPoint = new PointF();
        //                            for (int i = 0; i < second.endPoints.Count(); i++)
        //                            {
        //                                for (int y = 0; y < first.startPoints.Count(); y++)
        //                                {
        //                                    float dist = GetDistance(second.endPoints[i], first.startPoints[i]);
        //                                    if (dist < minDistance)
        //                                    {
        //                                        minDistance = dist;
        //                                        choosenPoint = first.startPoints[i];
        //                                    }
        //                                }
        //                            }

        //                            if (minDistance <= snapValue)
        //                            {
        //                                if (!result.snapped || lastSnapDistance > minDistance)
        //                                {
        //                                    result.snapped = true;
        //                                    lastSnapDistance = minDistance;
        //                                    result.snapPoint = choosenPoint;
        //                                }

        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (first.startPoint.Y < second.startPoint.Y)
        //            {
        //                //intersects tho
        //                if (second.startPoint.Y > first.endPoint.Y)
        //                {
        //                    result.intersects = true;
        //                }
        //                else
        //                {
        //                    result.intersects = false;
        //                    float distance = GetDistance(second.startPoint, first.endPoint);
        //                    if (distance <= snapValue)
        //                    {
        //                        if (second.startPoints.Count == 1 && first.endPoints.Count == 2)
        //                        {
        //                            LineEquation eq = GetLineEquation(first.endPoints[0], first.endPoints[1]);
        //                            if (!result.snapped || lastSnapDistance > distance)
        //                            {
        //                                result.snapped = true;
        //                                result.snapPoint = Intersection(eq, GetNormal(eq, second.startPoints[0]));
        //                                lastSnapDistance = distance;
        //                            }

        //                        }
        //                        else
        //                        {
        //                            float minDistance = 1000000;
        //                            PointF choosenPoint = new PointF();
        //                            for (int i = 0; i < second.startPoints.Count(); i++)
        //                            {
        //                                for (int y = 0; y < first.endPoints.Count(); y++)
        //                                {
        //                                    float dist = GetDistance(second.startPoints[i], first.endPoints[i]);
        //                                    if (dist < minDistance)
        //                                    {
        //                                        minDistance = dist;
        //                                        choosenPoint = first.endPoints[i];
        //                                    }
        //                                }
        //                            }

        //                            if (minDistance <= snapValue)
        //                            {
        //                                if (!result.snapped || lastSnapDistance > minDistance)
        //                                {
        //                                    result.snapped = true;
        //                                    lastSnapDistance = minDistance;
        //                                    result.snapPoint = choosenPoint;
        //                                }

        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (first.startPoint.Y > second.endPoint.Y)
        //                {
        //                    result.intersects = true;
        //                }
        //                else
        //                {
        //                    result.intersects = false;
        //                    float distance = GetDistance(first.startPoint, second.endPoint);
        //                    if (distance <= snapValue)
        //                    {
        //                        if (second.endPoints.Count == 1 && first.startPoints.Count == 2)
        //                        {
        //                            LineEquation eq = GetLineEquation(first.startPoints[0], first.startPoints[1]);
        //                            if (!result.snapped || lastSnapDistance > distance)
        //                            {
        //                                result.snapped = true;
        //                                result.snapPoint = Intersection(eq, GetNormal(eq, second.endPoints[0]));
        //                                lastSnapDistance = distance;
        //                            }

        //                        }
        //                        else
        //                        {
        //                            float minDistance = 1000000;
        //                            PointF choosenPoint = new PointF();
        //                            for (int i = 0; i < second.endPoints.Count(); i++)
        //                            {
        //                                for (int y = 0; y < first.startPoints.Count(); y++)
        //                                {
        //                                    float dist = GetDistance(second.endPoints[i], first.startPoints[i]);
        //                                    if (dist < minDistance)
        //                                    {
        //                                        minDistance = dist;
        //                                        choosenPoint = first.startPoints[i];
        //                                    }
        //                                }
        //                            }

        //                            if (minDistance <= snapValue)
        //                            {
        //                                if (!result.snapped || lastSnapDistance > minDistance)
        //                                {
        //                                    result.snapped = true;
        //                                    lastSnapDistance = minDistance;
        //                                    result.snapPoint = choosenPoint;
        //                                }

        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        pointIndex++;
        //    }


        //    return result;
        //}

        //static IntersectionResult CheckIntersection(PointF[] test_polygon,)
        //{
            
        //};


        public struct PolygonProjection
        {
            public PointF startPoint;
            public PointF endPoint;
            public List<PointF> startPoints;
            public List<PointF> endPoints;
        }

        static public PolygonProjection GetProjection(PointF[] polygon, LineEquation axis, int index = -1)
        {
            PolygonProjection result = new PolygonProjection();

            result.startPoint = new PointF();
            result.endPoint = new PointF();

            PointF preview = new PointF();
            preview = Intersection(GetNormal(axis, polygon[0]), axis);

            //if (index == -1)
            //{
            //    preview = Intersection(GetNormal(axis, polygon[0]), axis);
            //}
            //else
            //{
            //    preview = polygon[index];
               
                
            //}

            result.startPoint.X = preview.X;
            result.startPoint.Y = preview.Y;
            result.endPoint.X = preview.X;
            result.endPoint.Y = preview.Y;

            result.startPoints = new List<PointF>();
            result.endPoints = new List<PointF>();

            bool vertical = axis.By == 0;

            for(int i =0, polygonCount = polygon.Count(); i<polygonCount; i++)
            {
                PointF projection = new PointF();

                //if (index != -1 && i == index || i == index + 1)
                //{
                //    projection.X = preview.X;
                //    projection.Y = preview.Y;
                //}
                //else
                //{
                    projection = Intersection(GetNormal(axis, polygon[i]), axis);
                //}

               

                if (result.endPoint.X == projection.X &&
                    result.endPoint.Y == projection.Y)
                {
                    result.endPoints.Add(polygon[i]);
                }

                if (result.startPoint.X == projection.X &&
                   result.startPoint.Y == projection.Y)
                {
                    result.startPoints.Add(polygon[i]);
                }

                if (vertical)
                {
                    if (projection.Y < result.startPoint.Y)
                    {
                        result.startPoint = projection;
                        result.startPoints.Clear();
                        result.startPoints.Add(polygon[i]);
                    }
                    if(projection.Y > result.endPoint.Y)
                    {
                        result.endPoint = projection;
                        result.endPoints.Clear();
                        result.endPoints.Add(polygon[i]);
                    }
                }
                else
                {
                    if (projection.X < result.startPoint.X)
                    {
                        result.startPoint = projection;
                        result.startPoints.Clear();
                        result.startPoints.Add(polygon[i]);
                    }
                    if (projection.X > result.endPoint.X)
                    {
                        result.endPoint = projection;
                        result.endPoints.Clear();
                        result.endPoints.Add(polygon[i]);
                    }
                }
            }

            return result;
        }

        //static private PolygonProjection getPolygonProjection(PointF[] polygon, int index, LineEquation normal, bool vertical, bool decending,  PointF point)
        //{

        //    PointF lastPoint = new PointF();
        //    PolygonProjection result = new PolygonProjection();
        //    result.startPoint = point;
        //    result.endPoint = point;
        //    result.startPoints = new List<PointF>();
        //    result.endPoints = new List<PointF>();

        //    for (int i = index + 2, polygonCount = polygon.Count(); i < polygonCount; i++)
        //    {
        //        bool online = false;
        //        PointF projection = Intersection(GetNormal(normal, polygon[i]), normal);

        //        if (i != index + 2)
        //        {
        //            if (lastPoint.X == result.endPoint.X && lastPoint.Y == result.endPoint.Y)
        //            {
        //                result.endPoints.Add(polygon[i]);
        //            }

        //            if (lastPoint.X == result.startPoint.X && lastPoint.Y == result.startPoint.Y)
        //            {
        //                result.startPoints.Add(polygon[i]);
        //            }
        //        }

        //        if (vertical)
        //        {
        //            if (projection.Y > result.endPoint.Y)
        //            {
        //                result.endPoint.X = projection.X;
        //                result.endPoint.Y = projection.Y;
        //                result.endPoints.Clear();
        //                result.endPoints.Add(polygon[i]);
        //            }

        //            if (projection.Y < result.startPoint.Y)
        //            {
        //                result.startPoint.X = projection.X;
        //                result.startPoint.Y = projection.Y;
        //            }
        //        }
        //        else
        //        {
        //            if (decending)
        //            {
        //                if (projection.Y < result.endPoint.Y)
        //                {
        //                    result.endPoint.X = projection.X;
        //                    result.endPoint.Y = projection.Y;
        //                    result.endPoints.Clear();
        //                    result.endPoints.Add(polygon[i]);
        //                }

        //                if (projection.Y > result.startPoint.Y)
        //                {
        //                    result.startPoint.X = projection.X;
        //                    result.startPoint.Y = projection.Y;
        //                }
        //            }
        //            else
        //            {
        //                if (projection.Y > result.endPoint.Y)
        //                {
        //                    result.endPoint.X = projection.X;
        //                    result.endPoint.Y = projection.Y;
        //                    result.endPoints.Clear();
        //                    result.endPoints.Add(polygon[i]);
        //                }

        //                if (projection.Y < result.startPoint.Y)
        //                {
        //                    result.startPoint.X = projection.X;
        //                    result.startPoint.Y = projection.Y;
        //                }
        //            }
        //        }

        //        lastPoint = projection;
               
        //    }
        //    return result;
        //}
        

    }
}
