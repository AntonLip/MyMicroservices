using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LecturalAPI.Models;
using LecturalAPI.Services;
using LecturalAPI.Models.dataBaseModel;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Microsoft.Web.Helpers;
using System.IO;
using LecturalAPI.Models.dataTransferModel;

namespace LecturalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineDBsController : ControllerBase
    {
        private readonly AppdbContext _context;
        private readonly DisciplinesService _disciplineService;
        IWebHostEnvironment _webHost;
        public DisciplineDBsController(AppdbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
            _disciplineService = new DisciplinesService(context,webHost);
        }

        #region GET
        // GET: api/DisciplineDBs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplineDTOTimetable>>> GetDiscipline()
        {
            var disc = await _context.Discipline.ToListAsync();
            if (disc != null) 
            {
                List<DisciplineDTOTimetable> disciplineDTOTimetable = new List<DisciplineDTOTimetable>();

                foreach (var d in disc)
                {
                    disciplineDTOTimetable.Add(new DisciplineDTOTimetable(d));
                }

                return disciplineDTOTimetable;
            }
            return NoContent();
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

        // GET: api/DisciplineDBs/Names
        [Route("Names")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplinesName>>> GetDisciplineDBNames()
        {
            var disciplines = await _disciplineService.GetDisciplineNames();
            
            if (disciplines != null)
            {
                
                return disciplines;
            }

            return NotFound();
        }

        #endregion

        #region Post
        [HttpPost]
        public async Task<ActionResult<DisciplineDTOTimetable>> PostDisciplineDB(DisciplineDTOTimetable discipline, [FromForm] IFormFile body)
        {
           
            var d = await _disciplineService.AddDisciplineAsync(discipline);
            if (d != null)
            {
                await _disciplineService.AddPlan(d.id, body);
            }
            /* _context.Discipline.Add(disciplineDB);
             await _context.SaveChangesAsync();*/

            return CreatedAtAction("GetDisciplineDB", new { id = d.id }, d);
        }

        [HttpPost]
        [Route("uploadfile")]
        public async Task<ActionResult> PostUploadFilesAsync(Guid id, [FromForm] IFormFile body)
        {
          
            await _disciplineService.AddPlan(id, body);

            return Ok();
        }



        #endregion

        #region PUT
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

        #endregion

        #region DELETE
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

        #endregion
        
        private bool DisciplineDBExists(Guid id)
        {
            return _context.Discipline.Any(e => e.id == id);
        }
    
    }
}
