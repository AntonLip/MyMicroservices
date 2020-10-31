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
        public DisciplineDB(DisciplineDTOTimetable discipline)
        {
           
            this.name = discipline.name;
            this.countHours = discipline.countHours;
            this.isExam = discipline.isExam;
            this.dateOfPlan = discipline.dateOfPlan;
            this.countNorm = discipline.countNorm;
            this.Semester = discipline.Semester;
            fullName = discipline.fullName;
        }

        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string fullName { get; set; }
        public int countHours { get; set; }
        public int countHoursGZ { get; set; }
        public int countHoursPZ { get; set; }
        public int countHoursLeck { get; set; }
        public int countHoursSEM { get; set; }
        public int countHoursLR { get; set; }
        public int countHoursMZ { get; set; }
        public int countHoursSWZ { get; set; }
        public bool isExam { get; set; }
        public DateTime dateOfPlan { get; set; }
        public int countNorm { get; set; }
        public int Semester { get; set; }
        public byte[] Plan { get; set; }
        public byte[] GPID { get; set; }

        public SpecializationDB SpecializationDB { get; set; }
        public List<LessonDB> lessonDBs { get; set; }
        public List<TimetableDB> TimetableDB { get; set; }

    }
}
