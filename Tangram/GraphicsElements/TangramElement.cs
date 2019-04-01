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



        private Bitmap image;
        public Bitmap figureImage {
            get
            {
                return image;
            }
        }


        public TangramElement(List<TangramFigure> figures,Size size)
        {
            this.Figures = figures;
            FigureSize = size;
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
