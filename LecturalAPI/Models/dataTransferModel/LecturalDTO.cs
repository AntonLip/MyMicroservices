using LecturalAPI.Models.dataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataTransferModel
{
    public class LecturalDTO
    {
        public LecturalDTO()
        {
        }

        internal LecturalDTO(Lectural lecturalDB)
        {
            id = lecturalDB.id;
            firstName = lecturalDB.firstName;
            middleName = lecturalDB.middleName;
            lastName = lecturalDB.lastName;
            birthDay = lecturalDB.birthDay;
            pathPhotoSmall = lecturalDB.pathPhotoSmall;
            pathPhotoBig = lecturalDB.pathPhotoBig;
            serialAndNumderMilitaryDocs = lecturalDB.serialAndNumderMilitaryDocs;
            serialAndNumderCivilyDocs = lecturalDB.serialAndNumderCivilyDocs;
            dateOfStartService = lecturalDB.dateOfStartService;
            isMarried = lecturalDB.isMarried;
            info = lecturalDB.info;
            dateOfIssue = lecturalDB.dateOfIssue;
            dateOfExpiry = lecturalDB.dateOfExpiry;
            whoGetPassport = lecturalDB.whoGetPassport;
            nameOFVoinkom = lecturalDB.nameOFVoinkom;
            FormSec = lecturalDB.FormSec;
            DateFormSec = lecturalDB.DateFormSec;
            Unit = lecturalDB.Units.name;
            telephoneNumber = lecturalDB.telephoneNumber;
            if (lecturalDB.MilitaryRank == null)
            {
                MilitaryRank = "none";
            }
            else
            {
                MilitaryRank = lecturalDB.MilitaryRank.name;
            }
            if (lecturalDB.Position == null)
            {
                Position = "none";
            }
            else
            {
                Position = lecturalDB.Position.name;
            }
            if (lecturalDB.AcademicTitle == null)
            {
                AcademicTitle = "none";
            }
            else
            {
                AcademicTitle = lecturalDB.AcademicTitle.name;
            }
            if (lecturalDB.AcademicDegree == null)
            {
                AcademicDegree = "none";
            }
            else
            {
                AcademicDegree = lecturalDB.AcademicDegree.name;
            }
            
           
        }



        public Guid id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public DateTime birthDay { get; set; }
        public string pathPhotoSmall { get; set; }
        public string pathPhotoBig { get; set; }
        public DateTime dateOfStartService { get; set; }

        public string MilitaryRank { get; set; }
        public string Position { get; set; }
        public string AcademicTitle { get; set; }
        public string AcademicDegree { get; set; }

        public int countOfChildren { get; set; }
        public string info { get; set; }

        public bool isMarried { get; set; }


        
        public string serialAndNumderCivilyDocs { get; set; }
        public DateTime dateOfIssue { get; set; }
        public DateTime dateOfExpiry { get; set; }
        public string whoGetPassport { get; set; }
       
        public string nameOFVoinkom { get; set; }
        public string serialAndNumderMilitaryDocs { get; set; }
        public int FormSec { get; set; }
        public DateTime DateFormSec { get; set; }
        public string telephoneNumber { get; set; }
        public string Unit { get;  set; }
    }

    public class LecturalMininfo 
    {
        public LecturalMininfo()
        {
                
        }
        internal LecturalMininfo(Lectural lecturalDB)
        {
            id = lecturalDB.id;
            firstName = lecturalDB.firstName;
            middleName = lecturalDB.middleName;
            lastName = lecturalDB.lastName;
            pathPhotoSmall = lecturalDB.pathPhotoSmall;
            pathPhotoBig = lecturalDB.pathPhotoBig;
            telephoneNumber = lecturalDB.telephoneNumber;
            if (lecturalDB.MilitaryRank == null)
            {
                MilitaryRank = "none";
            }
            else
            {
                MilitaryRank = lecturalDB.MilitaryRank.name;
            }
            if (lecturalDB.Position == null)
            {
                Position = "none";
            }
            else
            {
                Position = lecturalDB.Position.name;
            }
            if (lecturalDB.Units == null)
            {
                unit = "undefined";
            }
            else
            {
                unit = lecturalDB.Units.name;
            }
        }

        public Guid id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string pathPhotoSmall { get; set; }
        public string pathPhotoBig { get; set; }
        public string MilitaryRank { get; set; }
        public string Position { get; set; }
        public string unit { get; set; }
        public string telephoneNumber { get; set; }
    }
}


    
