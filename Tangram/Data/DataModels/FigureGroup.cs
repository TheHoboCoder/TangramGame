using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangram.GraphicsElements;

namespace Tangram.Data.DataModels
{
    public class FigureGroup:BaseEntity
    {
        public string Name { get; set; }
        public string Comment { get; set; }

        //public List<TangramElement> tangramElements = new List<TangramElement>();

    }
}
