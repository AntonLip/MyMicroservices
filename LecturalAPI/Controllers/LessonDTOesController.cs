using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LecturalAPI.Models;
using LecturalAPI.Models.dataTransferModel;
using LecturalAPI.Services;
using Microsoft.AspNetCore.Http;

namespace LecturalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonDTOesController : ControllerBase
    {
       // private readonly AppdbContext _context;
        private readonly LessonsService _lessonsService;

        public LessonDTOesController(AppdbContext context)
        {
            //_context = context;
            _lessonsService = new LessonsService(context);
        }
        #region GET
        // GET: api/DisciplineDBs
        [HttpGet]
        public async Task<IEnumerable<LessonDTO>> GetLessons()
        {
            var lessons = await _lessonsService.GetLessonsAsync();
            if(lessons != null)
                return (lessons);

            return null;
        }

        // GET: api/DisciplineDBs/5
        [HttpGet("{id}")]
        public async Task<LessonDTO> GetLessonById(Guid id)
        {
            var lessons = await _lessonsService.GetLessonByIdAsync(id);

            return lessons;
        }
        #endregion




        #region POST
        [HttpPost]
        public async Task<ActionResult<LessonDTO>> PostLesson(LessonDTO lesson)
        {
            var lessons = await _lessonsService.CreateLesson(lesson);
            if (lesson != null)
            {
                return CreatedAtAction("GetLessonById", new { id = lesson.id }, lesson);
            }
            return NoContent();
        }
        #endregion



        #region Upload
        [HttpPut]
        [Route("upload")]
        public async Task<IActionResult> AddMaterialsAsync(Guid id, [FromForm] IFormFile body, string path)
        {
            try
            {
                await _lessonsService.SaveDoc(id, body, path);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
    }
}
