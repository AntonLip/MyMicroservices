using LecturalAPI.Models.dataBaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models
{
    internal abstract class Man
    {
        [Key]
        public Guid id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public DateTime birthDay { get; set; }
        public string pathPhotoSmall { get; set; }
        public string pathPhotoBig { get; set; }
        public bool isMarried { get; set; }
        public string info { get; set; }
        public string serialAndNumderCivilyDocs { get; set; }
    }

    interface iMilitary
    {
        public Position Position { get; set; }
        public DateTime dateOfStartService { get; set; }
        public MilitaryRank _militaryRank { get; set; }
        public string serialAndNumderMilitaryDocs { get; set; }

    }

    interface iScientist
    {
        public AcademicTitle AcademicTitle { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
    }
}
