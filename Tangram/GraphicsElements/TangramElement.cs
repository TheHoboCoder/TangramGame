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

        [DataMember]
        public List<TangramFigure> Figures { get; set; }

        [IgnoreDataMember]
        public int Id { get; set; }
        [IgnoreDataMember]
        public int Group_id { get; set; }
        [IgnoreDataMember]
        public int User_id { get; set; }

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

        public Bitmap ToBitmap()
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
