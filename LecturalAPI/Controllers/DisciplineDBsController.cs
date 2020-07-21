using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LecturalAPI.Models;
using LecturalAPI.Services;

namespace LecturalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineDBsController : ControllerBase
    {
        private readonly AppdbContext _context;
        private readonly DisciplinesService _disciplineService;
        public DisciplineDBsController(AppdbContext context)
        {
            _context = context;
            _disciplineService = new DisciplinesService(context);
        }

        // GET: api/DisciplineDBs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplineDB>>> GetDiscipline()
        {
            return await _context.Discipline.ToListAsync();
        }

        // GET: api/DisciplineDBs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplineDTOTimetable>> GetDisciplineDB(Guid id)
        {
            var d = await _disciplineService.GetDisciplineById(id);
            if (d == null)
            {
                return NotFound();
            }

            return d;
        }

        // PUT: api/DisciplineDBs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisciplineDB(Guid id, DisciplineDB disciplineDB)
        {
            if (id != disciplineDB.id)
            {
                return BadRequest();
            }

            _context.Entry(disciplineDB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineDBExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DisciplineDBs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DisciplineDTOTimetable>> PostDisciplineDB(DisciplineDTOTimetable disciplineDB)
        {
            var d = await _disciplineService.AddDisciplineAsync(disciplineDB);
           /* _context.Discipline.Add(disciplineDB);
            await _context.SaveChangesAsync();*/

            return CreatedAtAction("GetDisciplineDB", new { id = disciplineDB.id }, disciplineDB);
        }

        // DELETE: api/DisciplineDBs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DisciplineDB>> DeleteDisciplineDB(Guid id)
        {
            var disciplineDB = await _context.Discipline.Where(c => c.id == id).FirstOrDefaultAsync();
            if (disciplineDB == null)
            {
                return NotFound();
            }

            _context.Discipline.Remove(disciplineDB);
            await _context.SaveChangesAsync();

            return disciplineDB;
        }

        private bool DisciplineDBExists(Guid id)
        {
            return _context.Discipline.Any(e => e.id == id);
        }
    }
}
