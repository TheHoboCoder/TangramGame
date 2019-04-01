using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.Data.DataModels
{
    class Result
    {

        public int Id { get; set; }
        public int ClassId { get; set; }
        public int ChildId { get; set; }
        public int Score { get; set; }
        public int FigureId { get; set; }

        public enum DifficultyTypes
        {
            CONTOUR,
            NO_CONTOUR
        }

        public DifficultyTypes DifficultyType { get; set; }

    }
}
