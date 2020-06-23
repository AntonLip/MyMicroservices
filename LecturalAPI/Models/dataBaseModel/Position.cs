using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataBaseModel
{
    public class Position
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public float koeff { get; set; }
    }

}
