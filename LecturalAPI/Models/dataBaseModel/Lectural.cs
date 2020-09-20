using LecturalAPI.Models.dataBaseModel;
using LecturalAPI.Models.dataTransferModel;
using System;
using System.Collections.Generic;

namespace LecturalAPI.Models
{
    internal class Lectural
    {
        public Lectural(LecturalDTO lecturalDTO, MilitaryRank militaryRank, Position position, AcademicDegree academicDegree, AcademicTitle academicTitle)
        {
            id = lecturalDTO.id;
            lastName = lecturalDTO.lastName;
            firstName = lecturalDTO.firstName;
            middleName = lecturalDTO.middleName;
            birthDay = lecturalDTO.birthDay;
            pathPhotoSmall = lecturalDTO.pathPhotoSmall;
            pathPhotoBig = lecturalDTO.pathPhotoBig;
            serialAndNumderMilitaryDocs = lecturalDTO.serialAndNumderMilitaryDocs;
            serialAndNumderCivilyDocs = lecturalDTO.serialAndNumderCivilyDocs;
            dateOfStartService = lecturalDTO.dateOfStartService;
            isMarried = lecturalDTO.isMarried;
            countOfChildren = lecturalDTO.countOfChildren;
            info = lecturalDTO.info;
            MilitaryRank = militaryRank;
            Position = position;
            AcademicTitle = academicTitle;
            AcademicDegree = academicDegree;
            whoGetPassport = lecturalDTO.whoGetPassport;
            nameOFVoinkom = lecturalDTO.nameOFVoinkom;
            FormSec = lecturalDTO.FormSec;
            DateFormSec = lecturalDTO.DateFormSec;
            dateOfExpiry = lecturalDTO.dateOfExpiry;
            dateOfIssue = lecturalDTO.dateOfIssue;
        }

        public Guid id { get; set; }

        public Lectural()
        {

        }
        #region adoutHim
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public DateTime birthDay { get; set; }
        public string pathPhotoSmall { get; set; }
        public string pathPhotoBig { get; set; }
        public bool isMarried { get; set; }
        public List<wifes> wife { get; set; }
        public List<children> childrens { get; set; }
        public DateTime dateOfStartService { get; set; }
        public int countOfChildren { get; set; }
        #endregion

        #region CivilDocs
        public string serialAndNumderCivilyDocs { get; set; }
        public DateTime dateOfIssue { get; set; }
        public DateTime dateOfExpiry { get; set; }
        public string whoGetPassport { get; set; }
        #endregion

        #region MilitaryDocs
        public string nameOFVoinkom { get; set; }
        public string serialAndNumderMilitaryDocs { get; set; }
        public int FormSec { get; set; }
        public DateTime DateFormSec { get; set; }
        #endregion

        public string info { get; set; }

        public List<LessonDB> LessonDBs { get; set; }
        public List<DisciplineDB> DisciplineDB { get; set; }
        public MilitaryRank MilitaryRank { get; set; }
        public Position Position { get; set; }
        public AcademicTitle AcademicTitle { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
        public List<TimetableDB> TimetableDB { get; set; }


    }
}
