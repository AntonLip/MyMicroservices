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
        public int countHours { get; set; }
        public string InfoForLectural { get; set; }
        public string infoForCadets { get; set; }
        public int auditoreNumber { get; set; }
        public string infoForEngeneer { get; set; }
        public DateTime dateofLesson { get; set; }


        public LessonTypeDB LessonTypeDB { get; set; }
        public Lectural Lectural { get; set; }
        public DisciplineDB Discipline { get; set; }
    }
}
