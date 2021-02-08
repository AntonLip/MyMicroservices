using Microsoft.AspNetCore.Http;
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
            id = dDB.id;
            name = dDB.name;
            fullName = dDB.fullName;
            countHours = dDB.countHours;

            fullName = dDB.fullName;
            countHours = dDB.countHours;
            countHoursGZ = dDB.countHoursGZ;
            countHoursPZ = dDB.countHoursPZ;
            countHoursLeck = dDB.countHoursLeck;
            countHoursSEM = dDB.countHoursSEM;
            countHoursLR = dDB.countHoursLR;
            countHoursMZ = dDB.countHoursMZ;
            countHoursTest = dDB.countHoursTest;
            countHoursСontrolWork = dDB.countHoursСontrolWork;
            countHoursSWZ = dDB.countHoursSWZ;

            isExam = dDB.isExam;
            dateOfPlan = dDB.dateOfPlan;
            countNorm = dDB.countNorm;
            Semester = dDB.Semester;
        }

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
        public string SpecializationDB { get; set; }
    }

   }
