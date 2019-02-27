using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tangram.GraphicsElements
{
    abstract class Figure:IDisposable
    {
        protected void  Reset(PointF pos)
        {
            Init(boundaryPoints, path);
            this.Location = pos;
        }

        protected void Reset(PointF pos,PointF pivot,float angle)
        {
            Init(boundaryPoints, path);

            float deltaX = pivot.X - pos.X;
            float deltaY = pivot.Y - pos.Y;

            this.pivot = new PointF(pos.X+deltaX,pos.Y+deltaY);
            this.RotationAngle = angle;
            this.Location = pos;
        }

        protected  abstract void Init(PointF[] boundary, GraphicsPath p);
        
        /*Точки, ограничивающие данную фигуру(прямоугольник)
        *boundaryPoints[0] - левая верхняя точка* 
        *boundaryPoints[1] - правая верхняя точка и тд
        *при инициализации, после поворота все может измениться, но положение фигуры мы 
        *всегда считаем равным boundaryPoints[0]
        */

        private PointF[] boundaryPoints = new PointF[4];
        public PointF[] BoundaryPoints { get { return boundaryPoints; } }

        public Color FigureColor { get; set; }
        

        /// <summary>
        /// Возвращает самую левую точку прямоугольника
        /// </summary>
        public PointF LeftMostBoundary
        {
            get
            {
                return findPoint(boundaryPoints, true, false);
            }
        }
        /// <summary>
        /// Возвращает самую правую точку прямоугольника
        /// </summary>
        public PointF RightMostBoundary
        {
            get
            {
                return findPoint(boundaryPoints, true, true);
            }
        }
        /// <summary>
        /// Возвращает самую верхнюю точку прямоугольника
        /// </summary>
        public PointF TopMostBoundary
        {
            get
            {
                return findPoint(boundaryPoints, false, false);
            }
        }
        /// <summary>
        /// Возвращает самую нижнюю точку прямоугольника
        /// </summary>
        public PointF BottomMostBoundary
        {
            get
            {
                return findPoint(boundaryPoints, false, true);
            }
        }
        /// <summary>
        ///  Возвращает самую левую точку фигуры
        /// </summary>
        public PointF LeftMostCoord
        {
            get
            {
                return findPoint(path.PathPoints, true, false);
            }
        }
        /// <summary>
        /// Возвращает самую правую точку фигуры
        /// </summary>
        public PointF RightMostCoord
        {
            get
            {
                return findPoint(path.PathPoints, true, true);
            }
        }
        /// <summary>
        /// Возвращает самую верхнюю точку фигуры
        /// </summary>
        public PointF TopMostCoord
        {
            get
            {
                return findPoint(path.PathPoints, false, false);
            }
        }
        /// <summary>
        /// Возвращает самую нижнюю точку фигуры
        /// </summary>
        public PointF BottomMostCoord
        {
            get
            {
                return findPoint(path.PathPoints, false, true);
            }
        }

        /// <summary>
        /// поиск точки в массиве точек
        /// </summary>
        /// <param name="arr">массив точек</param>
        /// <param name="X"> ищем координату Х</param>
        /// <param name="max"> поиск максимального </param>
        /// <returns></returns>
        private PointF findPoint(PointF[] arr, bool X,bool max )
        {
            PointF found = new Point();
            found.X = arr[0].X;
            found.Y = arr[0].Y;

            foreach(PointF cur in arr)
            {
                if (X)
                {
                    if (max)
                    {
                        if(cur.X>found.X)
                        {
                            found.X = cur.X;
                            found.Y = cur.Y;
                        }
                    }
                    else
                    {
                        if (cur.X < found.X)
                        {
                            found.X = cur.X;
                            found.Y = cur.Y;
                        }
                    }
                }
                else
                {
                    if (max)
                    {
                        if (cur.Y > found.Y)
                        {
                            found.X = cur.X;
                            found.Y = cur.Y;
                        }
                    }
                    else
                    {

                        if (cur.Y < found.Y)
                        {
                            found.X = cur.X;
                            found.Y = cur.Y;
                        }
                    }
                }
            }
            return found;
        }

        /// <summary>
        /// Возвращает координату центра фигуры
        /// </summary>
        public PointF BoundaryCenter
        {
            get
            {
                //вычисляем середину диагонали прямоугольника, координаты которого представлены в массиве boundaryPoints
                float x = (boundaryPoints[0].X - boundaryPoints[2].X)/2;
                float y = (boundaryPoints[0].Y - boundaryPoints[2].Y) / 2;
                return new PointF(x, y);
            }
        }
        // сама фигура
        private GraphicsPath path = new GraphicsPath();
        public GraphicsPath Path { get { return path; } }
        // матрица преобразований
        private Matrix transformationMatrix = new Matrix();

        //применяет транформации, указанные в transformationMatrix
        private void ApplyTransform()
        {
            transformationMatrix.TransformPoints(boundaryPoints);
            path.Transform(transformationMatrix);
        }

        /// <summary>
        /// Сдвигает фигуру на заданное количество пикселей по горизонтали и вертикали относительно текущего положения
        /// </summary>
        /// <param name="dx">Сдвиг по X</param>
        /// <param name="dy">Сдвиг по Y</param>
        public void Translate(float dx, float dy)
        {
            transformationMatrix.Reset();
            transformationMatrix.Translate(dx, dy);
            ApplyTransform();
        }

        /// <summary>
        /// Задает глобальное положение фигуры
        /// </summary>
        public PointF Location
        {
            get
            {
                return boundaryPoints[0];
            }
            set
            {
                //мы хотим задать положение глобально
                //однако с помощью матрицы преобразований мы можем сдвинуть фигуру относительно текущего положения 
                //поэтому высчитываем сдвиг
                Translate(value.X - boundaryPoints[0].X, value.Y - boundaryPoints[0].Y);

            }
        }

        /// <summary>
        /// Задает точку, относительно которой будет выполняться поворот
        /// </summary>
        public PointF pivot { get; set; }
        //текущий угол поворота
        private float rotationAngle = 0;

        /// <summary>
        /// Вращает фигуру вокруг точки Pivot на заданное количество градусов по часовой стрелки относительно текущего угла поворота.
        /// </summary>
        /// <param name="angle">Угол поворота</param>
        public void Rotate(float angle)
        {
            transformationMatrix.Reset();
            transformationMatrix.RotateAt(angle, pivot);
            ApplyTransform();
        }
        /// <summary>
        /// Задает глобальный угол поворота
        /// </summary>
        public float RotationAngle
        {
            get
            {
                return rotationAngle;
            }
            set
            {
                //TODO
                Rotate(value - rotationAngle);
                rotationAngle = value;
            }
        }

        
        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    boundaryPoints = null;
                }

                path.Dispose();
                transformationMatrix.Dispose();
                path = null;
                transformationMatrix = null;

               disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        ~Figure()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(false);
        }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
