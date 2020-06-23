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
    public class AcademicTitlesController : ControllerBase
    {
        private readonly AppdbContext _context;

        public AcademicTitlesController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/AcademicTitles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicTitle>>> GetAcademicTitle()
        {
            return await _context.AcademicTitle.ToListAsync();
        }

        // GET: api/AcademicTitles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicTitle>> GetAcademicTitle(Guid id)
        {
            var academicTitle = await _context.AcademicTitle.FindAsync(id);

            if (academicTitle == null)
            {
                return NotFound();
            }

            return academicTitle;
        }

        // PUT: api/AcademicTitles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicTitle(Guid id, AcademicTitle academicTitle)
        {
            if (id != academicTitle.id)
            {
                return BadRequest();
            }

            _context.Entry(academicTitle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicTitleExists(id))
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

        // POST: api/AcademicTitles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AcademicTitle>> PostAcademicTitle(AcademicTitle academicTitle)
        {
            _context.AcademicTitle.Add(academicTitle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcademicTitle", new { id = academicTitle.id }, academicTitle);
        }

        // DELETE: api/AcademicTitles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AcademicTitle>> DeleteAcademicTitle(Guid id)
        {
            var academicTitle = await _context.AcademicTitle.FindAsync(id);
            if (academicTitle == null)
            {
                return NotFound();
            }

            _context.AcademicTitle.Remove(academicTitle);
            await _context.SaveChangesAsync();

            return academicTitle;
        }

        private bool AcademicTitleExists(Guid id)
        {
            return _context.AcademicTitle.Any(e => e.id == id);
        }
    }
}
