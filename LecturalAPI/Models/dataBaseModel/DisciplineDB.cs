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
        public DisciplineDB(DisciplineDTOTimetable discipline, SpecializationDB specializationDB)
        {
           
            name = discipline.name;
            fullName = discipline.fullName;
            countHours = discipline.countHours;
           
            fullName = discipline.fullName;
            countHours = discipline.countHours;
            countHoursGZ = discipline.countHoursGZ;
            countHoursPZ = discipline.countHoursPZ;
            countHoursLeck = discipline.countHoursLeck;
            countHoursSEM = discipline.countHoursSEM;
            countHoursLR = discipline.countHoursLR;
            countHoursMZ = discipline.countHoursMZ;
            countHoursTest = discipline.countHoursTest;
            countHoursСontrolWork = discipline.countHoursСontrolWork;
            countHoursSWZ = discipline.countHoursSWZ;
            SpecializationDB = specializationDB;
            isExam = discipline.isExam;
            dateOfPlan = discipline.dateOfPlan;
            countNorm = discipline.countNorm;
            Semester = discipline.Semester;
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
        public int countHoursTest { get; set; }
        public int countHoursСontrolWork { get; set; }
        public int countHoursSWZ { get; set; }

        public bool isExam { get; set; }
        public DateTime dateOfPlan { get; set; }
        public int countNorm { get; set; }
        public int Semester { get; set; }
        
        public SpecializationDB SpecializationDB { get; set; }
        public byte[]? Plan { get; set; }
        public byte[]? GPID { get; set; }
        public List<LessonDB>? lessonDBs { get; set; }
        public List<TimetableDB>? TimetableDB { get; set; }

    }
}
