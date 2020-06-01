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
    public class ProfessionDBsController : ControllerBase
    {
        private readonly AppdbContext _context;

        public ProfessionDBsController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/ProfessionDBs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessionDB>>> GetProfession()
        {
            return await _context.Profession.ToListAsync();
        }

        // GET: api/ProfessionDBs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessionDB>> GetProfessionDB(Guid id)
        {
            var professionDB = await _context.Profession.FindAsync(id);

            if (professionDB == null)
            {
                return NotFound();
            }

            return professionDB;
        }

        // PUT: api/ProfessionDBs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessionDB(Guid id, ProfessionDB professionDB)
        {
            if (id != professionDB.id)
            {
                return BadRequest();
            }

            _context.Entry(professionDB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessionDBExists(id))
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

        // POST: api/ProfessionDBs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProfessionDB>> PostProfessionDB(ProfessionDB professionDB)
        {
            _context.Profession.Add(professionDB);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfessionDB", new { id = professionDB.id }, professionDB);
        }

        // DELETE: api/ProfessionDBs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfessionDB>> DeleteProfessionDB(Guid id)
        {
            var professionDB = await _context.Profession.FindAsync(id);
            if (professionDB == null)
            {
                return NotFound();
            }

            _context.Profession.Remove(professionDB);
            await _context.SaveChangesAsync();

            return professionDB;
        }

        private bool ProfessionDBExists(Guid id)
        {
            return _context.Profession.Any(e => e.id == id);
        }
    }
}
