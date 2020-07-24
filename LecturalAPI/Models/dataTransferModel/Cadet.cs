using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models
{
    public class Cadet
    {
        
        public Cadet()
        {
        }

        public Cadet(CadetDB cadetDB)
        {
            id = cadetDB.id;
            groupName = cadetDB.GroupDB.SpecializationDB.nameOfSpecialization;
            groupNumber = cadetDB.GroupDB.numberOfGroup;
            lastName = cadetDB.lastName;
            middleName = cadetDB.middleName;
            firstName = cadetDB.firstName;
            isMarried = cadetDB.isMarried;
            birthDay = cadetDB.birthDay;
            pathPhotoBig = cadetDB.pathPhotoBig;
            pathPhotoSmall = cadetDB.pathPhotoSmall;
            Position = cadetDB.Position;
            dateOfStartService = cadetDB.dateOfStartService;
            militaryRank = cadetDB.militaryRank;
            info = cadetDB.info;
        }

        public Guid id { get; set; }
        public string groupNumber { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string groupName { get; set; }
        public DateTime birthDay { get; set; }
        public string pathPhotoSmall { get; set; }
        public string pathPhotoBig { get; set; }
        public string Position { get; set; }
        public DateTime dateOfStartService { get; set; }
        public bool isMarried { get; set; }
        public string militaryRank { get; set; }
        public string info { get; set; }


        public void CadetFromCadetDB(CadetDB cadetDB)
        {
            this.id = cadetDB.id;
            this.groupName = cadetDB.GroupDB.SpecializationDB.nameOfSpecialization;
            this.groupNumber = cadetDB.GroupDB.numberOfGroup;
            this.lastName = cadetDB.lastName;
            this.middleName = cadetDB.middleName;
            this.firstName = cadetDB.firstName;
            this.isMarried = cadetDB.isMarried;
            this.birthDay = cadetDB.birthDay;
            this.pathPhotoBig = cadetDB.pathPhotoBig;
            this.pathPhotoSmall = cadetDB.pathPhotoSmall;
            this.Position = cadetDB.Position;
            this.dateOfStartService = cadetDB.dateOfStartService;
            this.militaryRank = cadetDB.militaryRank;
            this.info = cadetDB.info;
       }
    }

   
}
