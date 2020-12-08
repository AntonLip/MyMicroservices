using LecturalAPI.Models;
using LecturalAPI.Models.dataTransferModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LecturalAPI.Services
{
    public class DisciplinesService
    {
        private readonly AppdbContext _context;
        IWebHostEnvironment _webHost;
        public DisciplinesService(AppdbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }


        #region GET
        internal async Task<DisciplineDTOTimetable> GetDisciplineById(Guid id)
        {
            var dDB = await _context.Discipline.Where(c => c.id == id).FirstOrDefaultAsync();
            DisciplineDTOTimetable disciplineDTO = new DisciplineDTOTimetable(dDB);
            return disciplineDTO;
        }

        internal async Task<List<DisciplinesName>> GetDisciplineNames()
        {
            var disciplines = await _context.Discipline.ToListAsync();

            if (disciplines != null)
            {
                List<DisciplinesName> disciplinesNames = new List<DisciplinesName>();
                foreach (var d in disciplines)
                {
                    disciplinesNames.Add(new DisciplinesName(d));
                }
                return disciplinesNames;
            }
            return null;
        }
        #endregion

        internal async Task<DisciplineDTOTimetable> AddDisciplineAsync(DisciplineDTOTimetable discipline)
        {
            var specializationDB = _context.Specialization.Where(c => c.nameOfSpecialization == discipline.SpecializationDB).FirstOrDefault();
            if (specializationDB == null)
                return null;
            DisciplineDB disciplineDBDB = new DisciplineDB(discipline, specializationDB);
            try
            {
                _context.Discipline.Add(disciplineDBDB);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
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

        internal async Task AddPlan(Guid id, IFormFile body)
        {
            var Disc =  _context.Discipline.Where(c => c.id == id).FirstOrDefault();
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await body.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            if (Disc != null)
            {
                Disc.Plan = fileBytes;
               
            }
        }

        
    }
}
