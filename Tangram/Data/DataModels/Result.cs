using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.Data.DataModels
{
    public class Result:BaseEntity
    {
        public int ClassId { get; set; }
        public int ChildId { get; set; }
        public int Score { get; set; }
        public int FigureId { get; set; }
        public int GroupId { get; set; }

        public enum DifficultyTypes
        {
            CONTOUR,
            NO_CONTOUR
        }

        public DifficultyTypes DifficultyType { get; set; }

    }
}
