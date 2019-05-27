using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.GraphicsElements
{
    [DataContract]
    public class TangramElement
    {
        [DataMember]
        public Size FigureSize { get; set;}

        private List<TangramFigure> figures;
        [DataMember]
        public List<TangramFigure> Figures
        {
            get
            {
                return figures;
            }
            set
            {
                figures = value;
                //foreach (Figure fig in figures)
                //{
                //    fig.Reset(fig.Location, fig.pivot, fig.RotationAngle);
                //}
            }
        }

       //создает иконку данной фигуры
        public Bitmap getIcon(int size,Color background)
        {
            Bitmap image = GetImage();

            if (image.Width > image.Height)
            {
               
                double scaleFactor = (double)size / image.Width;
                double side = image.Height * scaleFactor;
                double pos = size / 2 - side / 2;
                RectangleF rectangle = new RectangleF(0, (float)pos, size, (float)side);
                Bitmap bitmap = new Bitmap(size, size);

                using (Graphics gr = Graphics.FromImage(bitmap))
                {

                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    gr.Clear(background);
                    //gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    gr.DrawImage(image, rectangle);
                    //gr.DrawImage(image, new PointF(0, (float)pos));
                }
                image.Dispose();
                return bitmap;
            }
            else
            {
                if(image.Width < image.Height)
                {
                    Bitmap bitmap = new Bitmap(size, size);

                   
                    double scaleFactor = (double)size / image.Height;

                    double side = image.Width * scaleFactor;
                    double pos = size / 2 - side / 2;
                    RectangleF rectangle = new RectangleF((float)pos, 0 , (float)side, size);

                    using (Graphics gr = Graphics.FromImage(bitmap))
                    {
                     
                        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        gr.Clear(background);
                        //gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        gr.DrawImage(image, rectangle);
                    }
                    image.Dispose();
                    return bitmap;
                }
                else
                {
                    return image;
                }
            }
        }


        //private Bitmap image;
        //public Bitmap figureImage {
        //    get
        //    {
        //        if (image == null) image = ToBitmap();
        //        return image;
        //    }
        //}


        public TangramElement(List<TangramFigure> figures,Size size)
        {
            FigureSize = size;
            this.Figures = figures;
        }

        public TangramElement() { }

        //сериализация в Json
        public static byte[] Serialize(TangramElement el)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TangramElement));
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, el);
                return stream.ToArray();
            }
        }

        //десериализация из Json
        public static TangramElement Deserialize(byte[] data)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TangramElement));
            using (MemoryStream stream = new MemoryStream(data))
            {
                TangramElement serialized = (TangramElement)serializer.ReadObject(stream);
                //foreach (Figure fig in serialized.figures)
                //{
                //    fig.Reset(fig.Location, fig.pivot, fig.RotationAngle);
                //}
                return (TangramElement)serialized;
            }
        }

        //Возвращает изображение текущей фигуры
        public Bitmap GetImage()
        {
            Bitmap bitmap = new Bitmap(FigureSize.Width, FigureSize.Height);
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (SolidBrush brush =  new SolidBrush(Color.AliceBlue))
                {
                    foreach (TangramFigure fig in Figures)
                    {
                        brush.Color = fig.FigureColor;
                        gr.FillPath(brush, fig.Path);

                    }
                }
                    
            }
            return bitmap;
        }


    }
}
