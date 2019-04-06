using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangram.GraphicsElements;

namespace Tangram.Data.DataModels
{
    class Figure:BaseEntity
    {
        public string FigureName { get; set; }
        public int User_id { get; set; }
        public int Group_id { get; set; }

        public TangramElement TangramElement {get; set;}
    }
}
