using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangram.GraphicsElements;

namespace Tangram.Data.DataModels
{
    class FigureGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }

       private List<TangramElement> tangramElements = new List<TangramElement>();

       public void AddElement(TangramElement el)
        {
            el.Group_id = Id;
            tangramElements.Add(el);
        }


    }
}
