using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models
{
    public class DisciplineDTOTimetable
    {

        public DisciplineDTOTimetable()
        {

        }

        public DisciplineDTOTimetable(DisciplineDB dDB)
        {
            this.id = dDB.id;
            this.name = dDB.name;
            this.countHours = dDB.countHours;
            this.isExam = dDB.isExam;
            this.dateOfPlan = dDB.dateOfPlan;
            this.countNorm = dDB.countNorm;
            this.Semester = dDB.Semester;
        }

        public Guid id { get; set; }
        public string name { get; set; }
        public int countHours { get; set; }
        public bool isExam { get; set; }
        public DateTime dateOfPlan { get; set; }
        public string fullName { get; set; }

        public int countNorm { get; set; }
        public int Semester { get; set; }
        public int groupNumber { get; set; }
    }
}
