using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LecturalAPI.Models;
using LecturalAPI.Models.dataBaseModel;

namespace LecturalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicDegreesController : ControllerBase
    {
        private readonly AppdbContext _context;

        public AcademicDegreesController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/AcademicDegrees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicDegree>>> GetAcademicDegree()
        {
            return await _context.AcademicDegree.ToListAsync();
        }

        // GET: api/AcademicDegrees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicDegree>> GetAcademicDegree(Guid id)
        {
            var academicDegree = await _context.AcademicDegree.FindAsync(id);

            if (academicDegree == null)
            {
                return NotFound();
            }

            return academicDegree;
        }

        // PUT: api/AcademicDegrees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicDegree(Guid id, AcademicDegree academicDegree)
        {
            if (id != academicDegree.id)
            {
                return BadRequest();
            }

            _context.Entry(academicDegree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicDegreeExists(id))
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

        // POST: api/AcademicDegrees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AcademicDegree>> PostAcademicDegree(AcademicDegree academicDegree)
        {
            _context.AcademicDegree.Add(academicDegree);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcademicDegree", new { id = academicDegree.id }, academicDegree);
        }

        // DELETE: api/AcademicDegrees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AcademicDegree>> DeleteAcademicDegree(Guid id)
        {
            var academicDegree = await _context.AcademicDegree.FindAsync(id);
            if (academicDegree == null)
            {
                return NotFound();
            }

            _context.AcademicDegree.Remove(academicDegree);
            await _context.SaveChangesAsync();

            return academicDegree;
        }

        private bool AcademicDegreeExists(Guid id)
        {
            return _context.AcademicDegree.Any(e => e.id == id);
        }
    }
}
