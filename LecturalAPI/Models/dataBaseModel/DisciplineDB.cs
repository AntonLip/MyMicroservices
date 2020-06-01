using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models
{
    public class DisciplineDB
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public int countHours { get; set; }
        public Guid idLectural { get; set; }
        public int countLectureHours { get; set; }
        public int countLecturalThreads { get; set; }
        public int countPracticalThreads { get; set; }

        public int countPracticalHours { get; set; }
        public int countMetodicalHours { get; set; }

        public int countSeminarsHours { get; set; }
        public int countGroupsHours { get; set; }

        public int countTacticalHours { get; set; }
        public int countCourseWorkours { get; set; }
        public int countCourseWorksHours { get; set; }
        public int countSelfWorkHours { get; set; }
        public int countTestHours { get; set; }
        public int countTestWithScoreHours { get; set; }
        public bool isExam { get; set; }
        public Guid idProfession { get; set; }
        public Guid idSpecialization { get; set; }
        public DateTime dateOfPlan { get; set; }
        public int countNorm { get; set; }
        public int Semester { get; set; }
    }
}
