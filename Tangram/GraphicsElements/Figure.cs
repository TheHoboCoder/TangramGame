using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace Tangram.GraphicsElements
{
    [Serializable]
    abstract public class Figure:IDisposable
    {

        public Figure(Color c, PointF location)
        {
            path = new GraphicsPath();
            transformationMatrix = new Matrix();
            this.FigureColor = c;
            Reset(location);
        }

        public Figure(Color c, PointF location, float angle, PointF pivot)
        {
            path = new GraphicsPath();
            transformationMatrix = new Matrix();
            this.FigureColor = c;
            Reset(location, pivot, angle);
        }

        private PointF[] location = new PointF[] { new PointF(0, 0) };

        public void  Reset(PointF pos)
        {
            if (path == null) path = new GraphicsPath();
            if (transformationMatrix == null) transformationMatrix = new Matrix();
            this.rotationAngle = 0;
            Init(ref path);
            this.Location = pos;
        }

        public void Reset(PointF pos,PointF pivot,float angle)
        {
            Init(ref path);
            this.rotationAngle = 0;

            float deltaX = pivot.X - pos.X;
            float deltaY = pivot.Y - pos.Y;

            this.pivot = new PointF(pos.X+deltaX,pos.Y+deltaY);
            this.RotationAngle = angle;
            this.Location = pos;
        }

        public void Scale(int dx,int dy)
        {
            transformationMatrix.Reset();
            PointF currentLocation = Location;
            transformationMatrix.Scale(dx, dy);
            ApplyTransform();
            Location = currentLocation;
        }

        protected  abstract void Init(ref GraphicsPath p);

        public Bitmap GetImage(Color fillcolor)
        {
            RectangleF bounds = Path.GetBounds();
            Bitmap bitmap = new Bitmap((int)Math.Round(bounds.Width), (int)Math.Round(bounds.Height));
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.FillPath(new SolidBrush(fillcolor), Path);
            }
            return bitmap;
        }

        public abstract Figure Clone();

        [DataMember]
        public Color FigureColor { get; set; }
        
        /// <summary>
        /// Возвращает координату центра фигуры
        /// </summary>
        public virtual PointF BoundaryCenter
        {
            get
            {
                //вычисляем центр фигуры
                float x = (path.PathPoints[0].X + path.PathPoints[path.PathPoints.Count() - 2].X) / 2;
                float y = (path.PathPoints[0].Y + path.PathPoints[path.PathPoints.Count() - 2].Y) / 2;
                return new PointF(x, y);
            }
        }

        // сама фигура
        [IgnoreDataMember]
        [NonSerialized]
        private GraphicsPath path = new GraphicsPath();

        [IgnoreDataMember]
        public GraphicsPath Path { get { return path; } }
        // матрица преобразований
        [IgnoreDataMember]
        [NonSerialized]
        private Matrix transformationMatrix = new Matrix();

        //применяет транформации, указанные в transformationMatrix
        private void ApplyTransform()
        {
            if (path == null) path = new GraphicsPath();
            path.Transform(transformationMatrix);
            transformationMatrix.TransformPoints(location);
        }

        /// <summary>
        /// Сдвигает фигуру на заданное количество пикселей по горизонтали и вертикали относительно текущего положения
        /// </summary>
        /// <param name="dx">Сдвиг по X</param>
        /// <param name="dy">Сдвиг по Y</param>
        public void Translate(float dx, float dy)
        {
            if (transformationMatrix == null) transformationMatrix = new Matrix();
            transformationMatrix.Reset();
            transformationMatrix.Translate(dx, dy);
            PointF newPivot = new PointF(pivot.X + dx, pivot.Y + dy);
            pivot = newPivot;
            ApplyTransform();
        }

        /// <summary>
        /// Задает глобальное положение фигуры
        /// </summary>
        [DataMember]
        public PointF Location
        {
            get
            {
                //return path.PathPoints[0];
                //return path.GetBounds().Location;
                return location[0];
            }
            set
            {
                //мы хотим задать положение глобально
                //однако с помощью матрицы преобразований мы можем сдвинуть фигуру относительно текущего положения 
                //поэтому высчитываем сдвиг
                //Translate(value.X - path.PathPoints[0].X, value.Y - path.PathPoints[0].Y);
                Translate(value.X - location[0].X, value.Y - location[0].Y);

            }
        }

        /// <summary>
        /// Задает точку, относительно которой будет выполняться поворот
        /// </summary>
        [DataMember]
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
            rotationAngle = rotationAngle + angle;
            ApplyTransform();
        }
        /// <summary>
        /// Задает глобальный угол поворота
        /// </summary>
        [DataMember]
        public float RotationAngle
        {
            get
            {
                return rotationAngle;
            }
            set
            {
                if (transformationMatrix == null) transformationMatrix = new Matrix();
                //TODO
                Rotate(value - rotationAngle);
                rotationAngle = value;
            }
        }


        #region IDisposable Support
        [NonSerialized]
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
