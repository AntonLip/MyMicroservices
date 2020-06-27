﻿using System;
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

namespace LecturalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LecturalsController : ControllerBase
    {
        private readonly AppdbContext _context;
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

        // GET: api/Lecturals/5
        [HttpGet("{id}")]
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
        public async Task<ActionResult<Lectural>> PostLectural(Lectural lectural)
        {
            _context.Lectural.Add(lectural);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLectural", new { id = lectural.id }, lectural);
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
