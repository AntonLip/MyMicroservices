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
            countOfChildren = lecturalDB.countOfChildren;
            info = lecturalDB.info;
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
        public string serialAndNumderMilitaryDocs { get; set; }
        public string serialAndNumderCivilyDocs { get; set; }
        public DateTime dateOfStartService { get; set; }
        public bool isMarried { get; set; }

        public int countOfChildren { get; set; }
        public string info { get; set; }

        public string MilitaryRank { get; set; }
        public string Position { get; set; }
        public string AcademicTitle { get; set; }
        public string AcademicDegree { get; set; }






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
        }

        public Guid id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string pathPhotoSmall { get; set; }
        public string pathPhotoBig { get; set; }
        public string MilitaryRank { get; set; }
        public string Position { get; set; }
    }
}


    
