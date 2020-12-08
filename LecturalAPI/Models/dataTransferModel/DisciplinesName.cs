using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataTransferModel
{
    public class DisciplinesName
    {
        public DisciplinesName()
        {

        }
        public DisciplinesName(DisciplineDB discipline)
        {
            id = discipline.id;
            name = discipline.name;
        }
        public Guid id { get; set; }
        public string name { get; set; }
    }
}
