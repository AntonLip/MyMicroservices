using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LecturalAPI.Models;
using LecturalAPI.Models.dataBaseModel;
using LecturalAPI.Models.dataTransferModel;

namespace LecturalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationDBsController : ControllerBase
    {
        private readonly AppdbContext _context;

        public SpecializationDBsController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/SpecializationDBs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecializationDTO>>> GetSpecialization()
        {
            var specializations =  await _context.Specialization.ToListAsync();

            var specializationsDTO = new List<SpecializationDTO>();
            foreach (var s in specializations)
            {
                specializationsDTO.Add(new SpecializationDTO(s));
            }
            return specializationsDTO;
        }

        // GET: api/SpecializationDBs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecializationDB>> GetSpecializationDB(Guid id)
        {
            var specializationDB = await _context.Specialization.FindAsync(id);

            if (specializationDB == null)
            {
                return NotFound();
            }

            return specializationDB;
        }

        // PUT: api/SpecializationDBs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecializationDB(Guid id, SpecializationDB specializationDB)
        {
            if (id != specializationDB.id)
            {
                return BadRequest();
            }

            _context.Entry(specializationDB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializationDBExists(id))
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

        // POST: api/SpecializationDBs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SpecializationDB>> PostSpecializationDB(SpecializationDB specializationDB)
        {
            _context.Specialization.Add(specializationDB);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecializationDB", new { id = specializationDB.id }, specializationDB);
        }

        // DELETE: api/SpecializationDBs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecializationDB>> DeleteSpecializationDB(Guid id)
        {
            var specializationDB = await _context.Specialization.FindAsync(id);
            if (specializationDB == null)
            {
                return NotFound();
            }

            _context.Specialization.Remove(specializationDB);
            await _context.SaveChangesAsync();

            return specializationDB;
        }

        private bool SpecializationDBExists(Guid id)
        {
            return _context.Specialization.Any(e => e.id == id);
        }
    }
}
