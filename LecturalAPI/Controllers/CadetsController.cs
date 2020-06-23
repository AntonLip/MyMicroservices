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
    public class CadetsController : ControllerBase
    {
       // private readonly AppdbContext _context;
        private readonly CadetService _cadetServies;

        public CadetsController(AppdbContext context)
        {
            _cadetServies = new CadetService(context);
            //_context = context;
        }

        // GET: api/Cadets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadet>>> GetCadet()
        {
            return  await _cadetServies.GetAllCadetsAsync();            
        }

        // GET: api/Cadets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cadet>> GetCadetDB(Guid id)
        {
            var cadetDB = await _cadetServies.GetCadetByIdAsync(id);

            if (cadetDB == null)
            {
                return NotFound();
            }

            return cadetDB;
        }

        // PUT: api/Cadets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadetDB(Guid id, Cadet cadet)
        {
            if (id != cadet.id)
            {
                return BadRequest();
            }

            var cadetNew = await _cadetServies.UpdateCadetAsync(id, cadet);

            if (cadetNew != null)
            {
                return CreatedAtAction("GetCadetDB", new { id = cadetNew.id }, cadetNew);
            }

            return NoContent();
        }

        // POST: api/Cadets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cadet>> PostCadetDB(Cadet cadet)
        {
            var cadetNew = await _cadetServies.AddCadetAsync(cadet);
            return CreatedAtAction("GetCadetDB", new { id = cadetNew.id }, cadetNew);
        }

        // DELETE: api/Cadets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cadet>> DeleteCadetDB(Guid id)
        {
            var cadet = await _cadetServies.DeletecadetAsync(id);
            if(cadet == null)
            {
                return NotFound();
            }
            return cadet;
        }
        
         }
}
