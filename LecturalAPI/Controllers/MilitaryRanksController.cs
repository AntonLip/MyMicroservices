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
    public class MilitaryRanksController : ControllerBase
    {
        private readonly AppdbContext _context;

        public MilitaryRanksController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/MilitaryRanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MilitaryRank>>> GetMilitaryRank()
        {
            return await _context.MilitaryRank.ToListAsync();
        }

        // GET: api/MilitaryRanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MilitaryRank>> GetMilitaryRank(Guid id)
        {
            var militaryRank = await _context.MilitaryRank.FindAsync(id);

            if (militaryRank == null)
            {
                return NotFound();
            }

            return militaryRank;
        }

        // PUT: api/MilitaryRanks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMilitaryRank(Guid id, MilitaryRank militaryRank)
        {
            if (id != militaryRank.id)
            {
                return BadRequest();
            }

            _context.Entry(militaryRank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MilitaryRankExists(id))
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

        // POST: api/MilitaryRanks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MilitaryRank>> PostMilitaryRank(MilitaryRank militaryRank)
        {
            _context.MilitaryRank.Add(militaryRank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMilitaryRank", new { id = militaryRank.id }, militaryRank);
        }

        // DELETE: api/MilitaryRanks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MilitaryRank>> DeleteMilitaryRank(Guid id)
        {
            var militaryRank = await _context.MilitaryRank.FindAsync(id);
            if (militaryRank == null)
            {
                return NotFound();
            }

            _context.MilitaryRank.Remove(militaryRank);
            await _context.SaveChangesAsync();

            return militaryRank;
        }

        private bool MilitaryRankExists(Guid id)
        {
            return _context.MilitaryRank.Any(e => e.id == id);
        }
    }
}
