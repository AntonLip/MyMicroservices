using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models
{
    public class GroupDTO
    {
        public Guid id { get; set; }
        public string ProfessionLastName { get; set; }
        public string nameOfSpecialization { get; set; }
        public int numberOfGroup { get; set; }
        public int CountCadets { get; set; }
        public string info { get; set; }
    }
}
