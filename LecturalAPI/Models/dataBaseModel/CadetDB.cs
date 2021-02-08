using LecturalAPI.Models.dataBaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models
{
    internal class CadetDB
    {
        public CadetDB(GroupDB gr, Cadet cadet)
        {
            id = cadet.id;
            GroupDBid = gr.id;
            GroupDB = gr;
            lastName = cadet.lastName;
            middleName = cadet.middleName;
            firstName = cadet.firstName;
            birthDay = cadet.birthDay;
            pathPhotoBig = cadet.pathPhotoBig;
            pathPhotoSmall = cadet.pathPhotoSmall;
            Position = cadet.Position;
            dateOfStartService = cadet.dateOfStartService;
            isMarried = cadet.isMarried;
            militaryRank = cadet.militaryRank;
            info = cadet.info;
        }
        public CadetDB()
        { }
        [Key]
        public Guid id { get; set; }
        public Guid GroupDBid { get; set; }
        public GroupDB GroupDB { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public DateTime birthDay { get; set; }
        public string pathPhotoSmall { get; set; }
        public string pathPhotoBig { get; set; }
        public string Position { get; set; }
        public DateTime dateOfStartService { get; set; }
        public bool isMarried { get; set; }
        public string militaryRank { get; set; }
        public string info { get; set; }

    }
}
