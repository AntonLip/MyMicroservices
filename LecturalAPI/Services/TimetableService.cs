using LecturalAPI.Models;
using LecturalAPI.Models.dataBaseModel;
using LecturalAPI.Models.dataTransferModel.TimeTableDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Services
{
    public class TimetableService
    {
        private readonly AppdbContext _context;
        public TimetableService(AppdbContext context)
        {
            _context = context;
        }


        #region  GET
        internal Task<ActionResult<IEnumerable<TTDTOOut>>> GetAllTimetableAsync()
        {
            throw new NotImplementedException();
        }

        internal async Task<TTDTOOut> GetAllTimetableByIdAsync(Guid id)
        {
            var timetable = await _context.Timetable.FindAsync(id);


            if (timetable != null)
            {
                TTDTOOut timetableOUT = new TTDTOOut(timetable);

                return timetableOUT;
            }

            return null;

        }

        internal async Task<ActionResult<IEnumerable<TTDTOOut>>> GetAllTimetableByDayAsync(DateTime currentDate)
        {
            var timetable = await _context.Timetable.Where(c => c.date == currentDate).ToListAsync();

            List<TTDTOOut> timetableOUT = new List<TTDTOOut>();

            if (timetable != null)
            {
                foreach (var t in timetable)
                {
                    timetableOUT.Add(new TTDTOOut(t));
                }
                return timetableOUT;
            }
            return null;
        }
        
        internal async Task<ActionResult<IEnumerable<TTDTOOut>>> GetTimetableOnDayForGroupAsync(string group, DateTime dateTime)
        {
            var timetable = await _context.Timetable.Where(c => c.date == dateTime && c.numberOfGroup == group).ToListAsync();

            List<TTDTOOut> timetableOUT = new List<TTDTOOut>();

            if (timetable != null)
            {
                foreach (var t in timetable)
                {
                    timetableOUT.Add(new TTDTOOut(t));
                }
                return timetableOUT;
            }
            return null;
        }

        internal async Task<ActionResult<IEnumerable<TTDTOOut>>> GetTimetableOnDayForLecturalAsync(string lectural, DateTime dateTime)
        {
            var timetable = await _context.Timetable.Where(c => c.date == dateTime && c.Lectural == lectural).ToListAsync();

            List<TTDTOOut> timetableOUT = new List<TTDTOOut>();

            if (timetable != null)
            {
                foreach (var t in timetable)
                {
                    timetableOUT.Add(new TTDTOOut(t));
                }
                return timetableOUT;
            }
            return null;
        }
        #endregion




        internal async Task<TTDTOOut> UpdateTimeTibleAsync(Guid id, TTDTOOut tTDTOOut)
        {
            var timetableDB = await _context.Timetable.Where(c => c.id == id)
                                                     .Include(c => c.refLectural)
                                                     .Include(C => C.LessonDB)
                                                     .Include(c => c.GroupDB)
                                                     .Include(c => c.DisciplineDB)
                                                     .FirstOrDefaultAsync();

            _context.Entry(timetableDB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return tTDTOOut;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimetableDBExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        

        internal async Task<TTDTOOut> AddTimetableAsync(TTDTOOut tTDTOOut)
        {
            TimetableDB timetableDB = new TimetableDB(tTDTOOut);
            timetableDB.GroupDB = await _context.Group.Where(c => c.numberOfGroup == tTDTOOut.numberOfGroup).FirstOrDefaultAsync();
            timetableDB.LessonDB = await _context.Lesson.Where(c => c.id == tTDTOOut.lessonId).FirstOrDefaultAsync();
            timetableDB.DisciplineDB = await _context.Discipline.Where(c => c.name == tTDTOOut.nameOfDiscipline).FirstOrDefaultAsync();
            timetableDB.refLectural = await _context.Lectural.Where(c => c.lastName == tTDTOOut.Lectural).FirstOrDefaultAsync();

            timetableDB.auditore = tTDTOOut.auditore;
            timetableDB.date = tTDTOOut.date;
            timetableDB.dayOfWeek = tTDTOOut.dayOfWeek;
            timetableDB.Lectural = tTDTOOut.Lectural;
            timetableDB.nameOfDiscipline = tTDTOOut.nameOfDiscipline;
            timetableDB.numberOfGroup = tTDTOOut.numberOfGroup;

            timetableDB.numberOfLesson = tTDTOOut.numberOfLesson;
            timetableDB.typeOfLesson = tTDTOOut.typeOfLesson;


            try
            {
                _context.Timetable.Add(timetableDB);

                await _context.SaveChangesAsync();
                return tTDTOOut;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimetableDBExists(tTDTOOut.id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        internal async Task<int> ChangeLecturalInTimetable(string lecturalOlD, string lecturalNew)
        {
            var Timetables = await _context.Timetable.Where(c => c.Lectural == lecturalOlD).ToListAsync();

            int coutnerForChanges = 0;
            if (Timetables != null)
            {
                foreach (var t in Timetables)
                {
                    coutnerForChanges++;
                    t.Lectural = lecturalNew;
                    var lectural = await _context.Lectural.Where(c=>c.lastName == lecturalNew).FirstOrDefaultAsync();
                    if (lectural != null)
                    {
                        t.refLectural = lectural;
                    }
                    _context.Entry(t).State = EntityState.Modified;
                }
            }
           
            try
            {
                await _context.SaveChangesAsync();
                return coutnerForChanges;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Timetables != null)
                {
                    return -1;
                }
                else
                {
                    throw;
                }
            }
        }
      

        internal async Task<TTDTOOut> DeleteTimetableAsync(Guid id)
        {
            var timetableDB = await _context.Timetable.FindAsync(id);
            if (timetableDB != null)
            {
                _context.Timetable.Remove(timetableDB);
                await _context.SaveChangesAsync();
                TTDTOOut tTDTOOut = new TTDTOOut(timetableDB);
                return tTDTOOut;
            }

            return null;

        }
       
        
        private bool TimetableDBExists(Guid id)
        {
            return _context.Timetable.Any(e => e.id == id);
        }
    }
}
