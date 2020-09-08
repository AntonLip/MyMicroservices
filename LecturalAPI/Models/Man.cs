using LecturalAPI.Models.dataBaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models
{
    interface iMan
    {
        [Key]
        public Guid id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public DateTime birthDay { get; set; }
        public string pathPhotoSmall { get; set; }
        public string pathPhotoBig { get; set; }
       
        public string info { get; set; }
       
    }

    interface iMilitary
    {
        public Position Position { get; set; }
        public DateTime dateOfStartService { get; set; }
        public MilitaryRank _militaryRank { get; set; }      

    }

    interface iScientist
    {
        public AcademicTitle AcademicTitle { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
    }

    interface iCivilDocs
    {
        public string serialAndNumderCivilyDocs { get; set; }
        public DateTime dateOfIssue { get; set; }
        public DateTime dateOfExpiry { get; set; }
        public string whoGetPassport { get; set; }
        public string identityNumber { get; set; }
    }
    interface iMilitaryDocs
    {
        public string nameOFVoinkom { get; set; }
        public string serialAndNumderMilitaryDocs { get; set; }
        public int FormSec { get; set; }
        public DateTime DateFormSec { get; set; }
    }
}
