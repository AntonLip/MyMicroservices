using LecturalAPI.Models.dataTransferModel.TimeTableDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataBaseModel
{
    public class TimetableDB
    {
        public TimetableDB()
        {

        }

        public TimetableDB(TTDTOOut tTDTOOut)
        {
            this.numberOfWeek = tTDTOOut.numberOfWeek;
            this.dayOfWeek = tTDTOOut.dayOfWeek;
            this.numbewrOfDayInWeek = tTDTOOut.numbewrOfDayInWeek;
            this.nameOfDiscipline = tTDTOOut.nameOfDiscipline;
            this.Lectural = tTDTOOut.Lectural;
            this.date = tTDTOOut.date;
            this.auditore = tTDTOOut.auditore;
        }

        [Key]
        public Guid id { get; set; }
        public int numberOfWeek { get; set; }
        public string dayOfWeek { get; set; }
        public int numbewrOfDayInWeek { get; set; }
        public int numberOfLesson { get; set; }
        public int numberOfGroup { get; set; }

        public string nameOfDiscipline { get; set; }
        public string typeOfLesson { get; set; }
        public string Lectural { get; set; }
        public DateTime date { get; set; }

        public string auditore { get; set; }


        public string infoForLectural { get; set; }
        public string infoForEngeneers { get; set; }
        public string infoForcadets { get; set; }



        public Lectural refLectural { get; set; }
        public Guid LessonDBid { get; set; }
        public LessonDB LessonDB { get; set; }

        public Guid GroupDBid { get; set; }
        public GroupDB GroupDB { get; set; }
        public Guid DisciplineDBid { get; set; }
        public DisciplineDB DisciplineDB { get; set; }
    }
}
