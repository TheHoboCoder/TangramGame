using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.Data.DataModels
{
    public class History_group:BaseEntity
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int Year { get; set; }
    }
}
