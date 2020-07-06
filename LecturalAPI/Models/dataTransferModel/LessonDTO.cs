﻿using LecturalAPI.Models.dataBaseModel;
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

            this.infoForCadets = lesson.infoForCadets;
            this.infoForEngeneer = lesson.infoForEngeneer;
            this.InfoForLectural = lesson.InfoForLectural;

            this.auditoreNumber = lesson.auditoreNumber;

            this.dateofLesson = lesson.dateofLesson;
            this.lessonType = lesson.LessonTypeDB.nameOfType;

            this.lecturalName = lesson.Lectural.lastName;
            this.lecturalId = lesson.Lectural.id;

            this.sectionName = lesson.sectionName;
            this.themeName = lesson.themeName;
            this.name = lesson.name;

            this.disciplineName = lesson.Discipline.name;
            this.disciplineId = lesson.Discipline.id;

        }
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
        public Guid lecturalId { get; set; }


        public string lessonType { get; set; }
        public string lecturalName { get; set; }
        public string disciplineName { get; set; }
        public Guid disciplineId { get; set; }
    }
}
