using LecturalAPI.Models.dataTransferModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataBaseModel
{
    public class LessonDB
    {
        public LessonDB()
        {
        }

        public LessonDB(Lectural lecturalDB, DisciplineDB discipline, LessonTypeDB lessonType, LessonDTO lessonDTO) 
        {
            this.id = lessonDTO.id;
            this.name = lessonDTO.name;
            this.sectionName = lessonDTO.sectionName;
            this.themeName = lessonDTO.themeName;
            this.infoForCadets = lessonDTO.infoForCadets;
            this.infoForEngeneer = lessonDTO.infoForEngeneer;
            this.InfoForLectural = lessonDTO.InfoForLectural;
            this.auditoreNumber = lessonDTO.auditoreNumber;
            this.countHours = lessonDTO.countHours;

            this.Lectural = lecturalDB;
            this.LessonTypeDB = lessonType;
            this.Discipline = discipline;
            this.currentNumberOflessonsType = lessonDTO.currentNumberOflessonsType;

        }

        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string sectionName { get; set; }
        public string themeName { get; set; }
        public int countHours { get; set; }
        public int currentNumberOflessonsType { get; set; }
        public string InfoForLectural { get; set; }
        public string infoForCadets { get; set; }
        public int auditoreNumber { get; set; }
        public string infoForEngeneer { get; set; }
      

        public LessonTypeDB LessonTypeDB { get; set; }
        public Lectural Lectural { get; set; }
        public DisciplineDB Discipline { get; set; }
        public List<TimetableDB> TimetableDB { get; set; }

    }
}
