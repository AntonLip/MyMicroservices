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
    public class LessonTypeController : ControllerBase
    {
        private readonly AppdbContext _context;

        public LessonTypeController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/LessonType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonTypeDB>>> GetLessonType()
        {
            return await _context.LessonType.ToListAsync();
        }

        // GET: api/LessonType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonTypeDB>> GetLessonTypeDB(Guid id)
        {
            var lessonTypeDB = await _context.LessonType.FindAsync(id);

            if (lessonTypeDB == null)
            {
                return NotFound();
            }

            return lessonTypeDB;
        }

        // PUT: api/LessonType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLessonTypeDB(Guid id, LessonTypeDB lessonTypeDB)
        {
            if (id != lessonTypeDB.id)
            {
                return BadRequest();
            }

            _context.Entry(lessonTypeDB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonTypeDBExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/LessonType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LessonTypeDB>> PostLessonTypeDB(LessonTypeDB lessonTypeDB)
        {
            _context.LessonType.Add(lessonTypeDB);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLessonTypeDB", new { id = lessonTypeDB.id }, lessonTypeDB);
        }

        // DELETE: api/LessonType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LessonTypeDB>> DeleteLessonTypeDB(Guid id)
        {
            var lessonTypeDB = await _context.LessonType.FindAsync(id);
            if (lessonTypeDB == null)
            {
                return NotFound();
            }

            _context.LessonType.Remove(lessonTypeDB);
            await _context.SaveChangesAsync();

            return lessonTypeDB;
        }

        private bool LessonTypeDBExists(Guid id)
        {
            return _context.LessonType.Any(e => e.id == id);
        }
    }
}
