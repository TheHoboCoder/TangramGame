﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.Data.DataModels
{
    class ClassInfo:BaseEntity
    {
        public int TeacherId { get; set; }
        public DateTime classDate { get; set; }
    }
}
