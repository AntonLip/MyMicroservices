using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataTransferModel
{
    public class LecturalName
    {
        public LecturalName()
        {
        }
        internal LecturalName(Lectural g)
        {
            id = g.id;
            name = g.lastName;

        }        

        public Guid id { get; set; }
        public string name { get; set; }
        public bool isLect { get; set; }
    }
}
