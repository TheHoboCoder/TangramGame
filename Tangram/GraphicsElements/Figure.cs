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
            this.rotationAngle = 0;
            Init(path);
            this.Location = pos;
        }

        protected void Reset(PointF pos,PointF pivot,float angle)
        {
            Init(path);
            this.rotationAngle = 0;

            float deltaX = pivot.X - pos.X;
            float deltaY = pivot.Y - pos.Y;

            this.pivot = new PointF(pos.X+deltaX,pos.Y+deltaY);
            this.RotationAngle = angle;
            this.Location = pos;
        }

        protected  abstract void Init(GraphicsPath p);

        private bool flippedVertically = false;
        private bool flippedHorizontally = false;

        //TODO
        public void FlipVertically()
        {
            flippedVertically = !flippedVertically;
        }

        public void FlipHorizontally()
        {
            flippedHorizontally = !flippedHorizontally;
        }

        public Color FigureColor { get; set; }
        
        /// <summary>
        /// Возвращает координату центра фигуры
        /// </summary>
        public PointF BoundaryCenter
        {
            get
            {
                //вычисляем центр фигуры
                float x = (path.GetBounds().X+ path.GetBounds().Width) /2;
                float y = (path.GetBounds().Y + path.GetBounds().Height) / 2;
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
                return path.PathPoints[0];
            }
            set
            {
                //мы хотим задать положение глобально
                //однако с помощью матрицы преобразований мы можем сдвинуть фигуру относительно текущего положения 
                //поэтому высчитываем сдвиг
                Translate(value.X - path.PathPoints[0].X, value.Y - path.PathPoints[0].Y);

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
