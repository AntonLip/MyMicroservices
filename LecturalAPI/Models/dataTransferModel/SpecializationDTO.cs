using LecturalAPI.Models.dataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataTransferModel
{
    public class SpecializationDTO
    {
        public SpecializationDTO()
        {

        }
        public SpecializationDTO(SpecializationDB specializationDB)
        {
            id = specializationDB.id;
            SpecializationCode = specializationDB.SpecializationCode;
            name = specializationDB.nameOfSpecialization;
            info = specializationDB.info;
        }

        public Guid id { get; set; }
        public string SpecializationCode { get; set; }
        public string name { get; set; }
        public string info { get; set; }


    }
}
