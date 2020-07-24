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

        internal Task<ActionResult<IEnumerable<TTDTOOut>>> GetAllTimetableAsync()
        {
            throw new NotImplementedException();
        }

        internal Task<TTDTOOut> GetAllTimetableByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
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

        internal Task<TTDTOOut> GetTimetableOnDayAsync(string group, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        private bool TimetableDBExists(Guid id)
        {
            return _context.Timetable.Any(e => e.id == id);
        }
    }
}
