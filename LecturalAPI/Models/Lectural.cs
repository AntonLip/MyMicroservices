using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models
{
    public class Lectural
    {
        public Guid id { get; set; }
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
        public string academicTitle { get; set; }
        public string academicDegree { get; set; }
        public int countOfChildren { get; set; }
        public string info { get; set; }
    }
}
