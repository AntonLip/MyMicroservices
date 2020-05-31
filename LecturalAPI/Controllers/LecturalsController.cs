using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LecturalAPI.Models;

namespace LecturalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturalsController : ControllerBase
    {
        private readonly AppdbContext _context;

        public LecturalsController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/Lecturals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lectural>>> GetLectural(int Page = 0, int pageSizeCount = 5)
        {
            //return await _context.Lectural.ToListAsync();
            return await _context.Lectural.Skip(Page * pageSizeCount).Take(pageSizeCount).ToListAsync();
        }

        // GET: api/Lecturals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lectural>> GetLectural(Guid id)
        {
            var lectural = await _context.Lectural.FindAsync(id);

            if (lectural == null)
            {
                return NotFound();
            }

            return lectural;
        }

        // PUT: api/Lecturals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLectural(Guid id, Lectural lectural)
        {
            if (id != lectural.id)
            {
                return BadRequest();
            }

            _context.Entry(lectural).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturalExists(id))
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

        // POST: api/Lecturals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Lectural>> PostLectural(Lectural lectural)
        {
            _context.Lectural.Add(lectural);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLectural", new { id = lectural.id }, lectural);
        }

        // DELETE: api/Lecturals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lectural>> DeleteLectural(Guid id)
        {
            var lectural = await _context.Lectural.FindAsync(id);
            if (lectural == null)
            {
                return NotFound();
            }

            _context.Lectural.Remove(lectural);
            await _context.SaveChangesAsync();

            return lectural;
        }

        private bool LecturalExists(Guid id)
        {
            return _context.Lectural.Any(e => e.id == id);
        }
    }
}
