using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataBaseModel
{
    public class Units
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public int importance { get; set; }

        internal List<Lectural>lectural { get; set; }       
    }
}
