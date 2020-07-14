using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataBaseModel
{
    public class TimetableDB
    {
        public Guid id { get; set; }
        public int numberOfWeek { get; set; }
        public int numberOfLesson { get; set; }
        public DateTime dateOfLesson { get; set; }

        public Guid LessonDBid { get; set; }
        public LessonDB LessonDB { get; set; }

        public Guid GroupDBid { get; set; }
        public GroupDB GroupDB { get; set; }
        public Guid DisciplineDBid { get; set; }
        public DisciplineDB DisciplineDB { get; set; }

        public int numberOfAud { get; set; }
        public Lectural firstLectural { get; set; }
        public Lectural secondLectural { get; set; }
    }
}
