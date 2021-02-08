using LecturalAPI.Models.dataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataTransferModel
{
    public class LessonDTO
    {
       

        public LessonDTO()
        {

        }

        public LessonDTO( LessonDB lesson)
        {
            this.id = lesson.id;

            this.lessonType = lesson.LessonTypeDB.name;
            this.sectionName = lesson.sectionName;
            this.themeName = lesson.themeName;
            this.name = lesson.name;
            this.currentNumberOflessonsType = lesson.currentNumberOflessonsType;
            this.DisciplineId = lesson.Discipline.id;

        }
        public Guid id { get; set; }
        public string name { get; set; }
        public string sectionName { get; set; }
        public string themeName { get; set; }
        public int countHours { get; set; }
        public int currentNumberOflessonsType { get; set; }
        //Link to videos
        //Link to literature
        public string lessonType { get; set; }
        public Guid DisciplineId { get; set; }
    }
}
