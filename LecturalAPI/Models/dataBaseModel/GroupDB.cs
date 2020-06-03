using LecturalAPI.Models.dataBaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models
{
    public class GroupDB
    {
        [Key]
        public Guid id { get; set; }
       
        public ProfessionDB ProfessionDB { get; set; }
       
        public SpecializationDB SpecializationDB { get; set; }

        public Guid ProfessionDBid { get; set; }
        public Guid SpecializationDBid { get; set; }
        public int numberOfGroup { get; set; }
        public int CountCadets { get; set; }
        public string info { get; set; }

    }
}
