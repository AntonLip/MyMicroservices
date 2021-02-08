using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LecturalAPI.Models;
using LecturalAPI.Services;
using Microsoft.AspNetCore.Hosting;
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
            try
            {
                 var disc = await _context.Discipline.ToListAsync();
                 List<DisciplineDTOTimetable> disciplineDTOTimetable = new List<DisciplineDTOTimetable>();

                 foreach (var d in disc)
                 {
                     disciplineDTOTimetable.Add(new DisciplineDTOTimetable(d));
                 }

                 return disciplineDTOTimetable;

            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        // GET: api/DisciplineDBs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplineDTOTimetable>> GetDisciplineDB(Guid id)
        {
            try
            {
                return await _disciplineService.GetDisciplineById(id);

            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("{id:Guid}/lessons")]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetLessonInDisciplineDB(Guid id)
        {
            try
            {
                return await _disciplineService.GetLessonInDisciplineDB(id);

            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

           
        }

        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetFilteredDisciplineDB(string specName, int year)
        {
            try
            {
                var d = await _disciplineService.GetFilteredDicsiplines(specName, year);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            return NotFound();
        }
        

        // GET: api/DisciplineDBs/Names
        [Route("Names")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplinesName>>> GetDisciplineDBNames()
        {
            try
            {
                var disciplines = await _disciplineService.GetDisciplineNames();
                return disciplines;
            }
            catch (ArgumentNullException ex)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        #endregion

        #region Post
        [HttpPost]
        public async Task<ActionResult<DisciplineDTOTimetable>> PostDisciplineDB(DisciplineDTOTimetable discipline)
        {
           
            var d = await _disciplineService.AddDisciplineAsync(discipline);
            if (d != null)
            {
            }
            

            return Ok(d);
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
