using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.Data.DataModels
{
    public class Child_Journal:BaseEntity
    {
        public int ChildId { get; set; }
        public int GroupHistoryId { get; set; }
        public int SubGroup { get; set; }
    }
}
