using LecturalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Services
{
    public class DisciplinesService
    {
        private readonly AppdbContext _context;
        public DisciplinesService(AppdbContext context)
        {
            _context = context;
        }
        internal async Task<DisciplineDTOTimetable> GetDisciplineById(Guid id)
        {
            var dDB =  await _context.Discipline.Where(c => c.id == id).FirstOrDefaultAsync();
            DisciplineDTOTimetable disciplineDTO = new DisciplineDTOTimetable(dDB);
            return disciplineDTO;
        }
        internal async Task<DisciplineDTOTimetable> AddDisciplineAsync(DisciplineDTOTimetable discipline)
        {
            var gr = await _context.Group.Where(c => c.numberOfGroup == discipline.groupNumber).FirstOrDefaultAsync();
            if (gr == null )
            {
                return null;
            }
            DisciplineDB disciplineDBDB = new DisciplineDB(discipline);
            try
            {
                _context.Discipline.Add(disciplineDBDB);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineDBExists(discipline.id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return discipline;
        }
        private bool DisciplineDBExists(Guid id)
        {
            return _context.Discipline.Any(e => e.id == id);
        }
    }
}
