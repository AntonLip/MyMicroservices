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
        public string numberOfGroup { get; set; }
        public string info { get; set; }

        public void GroupDBtoGroupDTO(GroupDB groupDB) 
        {
            this.id = groupDB.id;
            this.nameOfSpecialization = groupDB.SpecializationDB.SpecializationCode;
            this.ProfessionLastName = groupDB.ProfessionDB.nameOfProffession;
            this.numberOfGroup = groupDB.numberOfGroup;
            this.info = groupDB.info;
        }
    }
}
