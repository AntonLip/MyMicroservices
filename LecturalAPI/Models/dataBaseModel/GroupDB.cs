using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models
{
    public class GroupDB
    {
        [Key]
        public Guid id { get; set; }
        public Guid idProfession { get; set; }
        public Guid idSpecialization { get; set; }
        public int numberOfGroup { get; set; }
        public int CountCadets { get; set; }
        public string info { get; set; }

    }
}
