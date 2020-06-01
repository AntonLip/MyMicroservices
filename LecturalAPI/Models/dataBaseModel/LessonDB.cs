using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataBaseModel
{
    public class LessonDB
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string sectionName { get; set; }
        public string themeName { get; set; }
        public Guid idLectural { get; set; }
        public Guid idDiciplines { get; set; }
        public Guid idLessonType { get; set; }
        public int numberOfDiciplines { get; set; }
        public int countHours { get; set; }

        public string Info { get; set; }
    }
}
