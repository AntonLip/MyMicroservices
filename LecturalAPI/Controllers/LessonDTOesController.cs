using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LecturalAPI.Models;
using LecturalAPI.Models.dataTransferModel;
using LecturalAPI.Services;

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

        // GET: api/LessonDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetLessonDTO()
        {
            return await _lessonsService.GetAllLessonsAsync();
        }

        // GET: api/LessonDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonDTO>> GetLessonDTO(Guid id)
        {
            var lessonDTO = await _lessonsService.GetLessonByIdAsync(id);

            if (lessonDTO == null)
            {
                return NotFound();
            }

            return lessonDTO;
        }

        // PUT: api/LessonDTOes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLessonDTO(Guid id, LessonDTO lessonDTO)
        {
            if (id != lessonDTO.id)
            {
                return BadRequest();
            }

            var les = await _lessonsService.UpdateLessonAsync(id, lessonDTO);

            if(les == null)
            { 
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/LessonDTOes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LessonDTO>> PostLessonDTO(LessonDTO lessonDTO)
        {
            var newLesson = await _lessonsService.AddlessonAsync(lessonDTO);

            return CreatedAtAction("GetLessonDTO", new { id = newLesson.id }, newLesson);
        }

        // DELETE: api/LessonDTOes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LessonDTO>> DeleteLessonDTO(Guid id)
        {
            var lessonDTO = await _lessonsService.DeleteLessonAsync(id);
            if (lessonDTO == null)
            {
                return NotFound();
            }

            return lessonDTO;
        }


    }
}
