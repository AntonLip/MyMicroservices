using LecturalAPI.Models.dataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models.dataTransferModel.TimeTableDTO
{
    public class TTDTOOut
    {
        public TTDTOOut()
        {

        }

        public TTDTOOut( TimetableDB timetableDB)
        {
            id = timetableDB.id;
            numberOfWeek = timetableDB.numberOfWeek;
            dayOfWeek = timetableDB.dayOfWeek;
            numbewrOfDayInWeek = timetableDB.numbewrOfDayInWeek;
            numberOfLesson = timetableDB.numberOfLesson;
            numberOfGroup = timetableDB.numberOfGroup;
            nameOfDiscipline = timetableDB.nameOfDiscipline;
            typeOfLesson = timetableDB.typeOfLesson;
            Lectural = timetableDB.Lectural;
            date = timetableDB.date;
            auditore = timetableDB.auditore;
        }
        public Guid id { get; set; }
        public int numberOfWeek { get; set; }
        public string dayOfWeek { get; set; }
        public int numbewrOfDayInWeek { get; set; }
        public int numberOfLesson { get; set; }
        public string numberOfGroup { get; set; }

        public string nameOfDiscipline { get; set; }
        public string typeOfLesson { get; set; }
        public string Lectural { get; set; }
        public DateTime date { get; set; }

        public string auditore { get; set; }
        public Guid lessonId { get; set; }

    }
}
