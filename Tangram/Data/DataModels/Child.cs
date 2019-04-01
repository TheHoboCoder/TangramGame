using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.Data.DataModels
{
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Fam { get; set; }
        public int GroupId { get; set; }
        public bool gender { get; set; }
        public int SubGroup { get; set; }
        public string GenderName
        {
            get
            {
                if (gender)
                {
                    return "Мужской";
                }
                else
                {
                    return "Женский";
                }
            }
        }
    }
}
