using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.Data.DataModels
{
    public class Garden_groups
    {
        public int Id { get; set; }
        public int GroupTypeId { get; set; }
        public string Group_Name { get; set; }
        public int TeacherId { get; set; }
        public int childCount { get; set; }
    }
}
