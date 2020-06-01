using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataBaseModel
{
    public class SpecializationDB
    {
        [Key]
        public Guid id { get; set; }
        public string SpecializationCode { get; set; }
        public string nameOfSpecialization { get; set; }
        public string info { get; set; }
    }
}
