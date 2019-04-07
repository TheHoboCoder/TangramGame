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
    class TangramElement
    {
        [DataMember]
        public Size FigureSize { get; set; }

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
                image = ToBitmap();

            }
        }


        public Bitmap getIcon(Color background)
        {
            if (image == null) image = ToBitmap();

            if (image.Width > image.Height)
            {
                double pos = image.Width / 2 + image.Height / 2;

                Bitmap bitmap = new Bitmap(image.Width, image.Width);

                using (Graphics gr = Graphics.FromImage(bitmap))
                {
                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    //gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    gr.DrawImage(image, new PointF(0, (float)pos));
                }
                return bitmap;
            }
            else
            {
                if(image.Width < image.Height)
                {
                    Bitmap bitmap = new Bitmap(image.Height, image.Height);
                    double pos = image.Height/ 2 + image.Width / 2;
                    using (Graphics gr = Graphics.FromImage(bitmap))
                    {
                        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        //gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        gr.DrawImage(image, new PointF((float)pos, 0));
                    }
                    return bitmap;
                }
                else
                {
                    return image;
                }
            }
        }


        private Bitmap image;
        public Bitmap figureImage {
            get
            {
                return image;
            }
        }


        public TangramElement(List<TangramFigure> figures,Size size)
        {
            FigureSize = size;
            this.Figures = figures;
        }

        public TangramElement() { }

        public static byte[] Serialize(TangramElement el)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TangramElement));
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, el);
                return stream.ToArray();
            }
        }

        public static TangramElement Deserialize(byte[] data)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TangramElement));
            using (MemoryStream stream = new MemoryStream(data))
            {
                return (TangramElement)serializer.ReadObject(stream);
            }
        }

        private Bitmap ToBitmap()
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
