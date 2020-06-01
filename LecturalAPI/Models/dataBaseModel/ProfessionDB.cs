using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataBaseModel
{
    public class ProfessionDB
    {
        [Key]
        public Guid id { get; set; }
        public string proffesionCode{ get; set; }
        public string nameOfProffession { get; set; }
        public string info { get; set; }
    }
}
