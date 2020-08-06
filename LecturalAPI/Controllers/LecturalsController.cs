using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LecturalAPI.Models;
using LecturalAPI.Services;
using LecturalAPI.Models.dataTransferModel;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace LecturalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LecturalsController : ControllerBase
    {
       
        //private readonly AppdbContext _context;
        private readonly LecturalService _lecturalService;
        public LecturalsController(AppdbContext context)
        {
            //_context = context;
            _lecturalService = new LecturalService(context);
        }

        // GET: api/Lecturals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LecturalDTO>>> GetLectural(int Page = 0, int pageSizeCount = 5)
        {
            //return await _context.Lectural.ToListAsync();
            //return await _context.Lectural.Skip(Page * pageSizeCount).Take(pageSizeCount).ToListAsync();
            return await _lecturalService.GetAllLecturalAsync(Page, pageSizeCount);
        }

        // GET: api/Lecturals
       [Route("Min")]
       
        public async Task<ActionResult<IEnumerable<LecturalMininfo>>> GetLecturalMinInfo(int Page = 0, int pageSizeCount = 5)
        {
            var nameIdentifier = User.Claims
             .Where(x => x.Type == "scope").FirstOrDefault(c => c.Value == "api1");
            HttpContext.
            return await _lecturalService.GetAllLecturalMinInfoAsync(Page, pageSizeCount);

           

            //return await _context.Lectural.ToListAsync();
            //return await _context.Lectural.Skip(Page * pageSizeCount).Take(pageSizeCount).ToListAsync();
        }
        // GET: api/Lecturals/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LecturalDTO>> GetLectural(Guid id)
        {
            var lectural = await _lecturalService.GetLecturalByIdAsync(id);

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
        public async Task<IActionResult> PutLectural(Guid id, LecturalDTO lecturalDTO)
        {
            if (id != lecturalDTO.id)
            {
                return BadRequest();
            }

            LecturalDTO lectural = await _lecturalService.UpdateLecturalAsync(id, lecturalDTO);
            if (lectural != null)
            {
                return CreatedAtAction("GetLectural", new { id = lectural.id }, lectural);
            }

            return NotFound();
        }

        // POST: api/Lecturals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LecturalDTO>> PostLectural(LecturalDTO lectural)
        {
            var lec =  await _lecturalService.AddLecturalAsync(lectural);
         
            return CreatedAtAction("GetLectural", new { id = lec.id }, lec);
        }

        // DELETE: api/Lecturals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LecturalDTO>> DeleteLectural(Guid id)
        {
            var lectural = await _lecturalService.DeleteLectureAsync(id);
            if (lectural == null)
            {
                return NotFound();
            }
            return lectural;
        }

       
    }
}
