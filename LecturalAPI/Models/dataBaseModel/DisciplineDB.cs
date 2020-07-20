using LecturalAPI.Models.dataBaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LecturalAPI.Models
{
    public class DisciplineDB
    {
        public DisciplineDB()
        {

        }
        public DisciplineDB(GroupDB gr, DisciplineDTOTimetable discipline)
        {
            this.GroupDB = gr;
            this.name = discipline.name;
            this.countHours = discipline.countHours;
            this.isExam = discipline.isExam;
            this.dateOfPlan = discipline.dateOfPlan;
            this.countNorm = discipline.countNorm;
            this.Semester = discipline.Semester;
        }

        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public int countHours { get; set; }
        public bool isExam { get; set; }
        public DateTime dateOfPlan { get; set; }
        public int countNorm { get; set; }
        public int Semester { get; set; }
        public GroupDB GroupDB { get; set; }
        public List<LessonDB> lessonDBs { get; set; }
      //  public List<TimetableDB> TimetableDB { get; set; }

    }
}
