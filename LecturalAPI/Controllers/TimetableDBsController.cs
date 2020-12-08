using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LecturalAPI.Models;
using LecturalAPI.Models.dataBaseModel;
using LecturalAPI.Models.dataTransferModel.TimeTableDTO;
using LecturalAPI.Services;

namespace LecturalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableDBsController : ControllerBase
    {
        
        private readonly TimetableService _timetableService;
        public TimetableDBsController(AppdbContext context)
        {
            _timetableService = new TimetableService(context);
        }


        #region GET
        // GET: api/TimetableDBs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TTDTOOut>>> GetTimetable()
        {
            return await _timetableService.GetAllTimetableAsync();
        }

        // GET: api/TimetableDBs/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TTDTOOut>> GetTimetableDB(Guid id)
        {
            var timetableDB = await _timetableService.GetAllTimetableByIdAsync(id);

            if (timetableDB == null)
            {
                return NotFound();
            }

            return timetableDB;
        }
        //[Route("TimetableDay")]
        [HttpGet("{dateTime:DateTime}")]
        public async Task<ActionResult<IEnumerable<TTDTOOut>>> GetTimetableOnDay(DateTime dateTime)
        {
            var timetableDB = await _timetableService.GetAllTimetableByDayAsync(dateTime);

            if (timetableDB == null)
            {
                return NotFound();
            }

            return timetableDB;
        }
        [Route("forGroup")]
        public async Task<ActionResult<IEnumerable<TTDTOOut>>> GetTimetableOnDayByGroupAsync(DateTime dateTime, string groupDTO)
        {
            var timetableDB = await _timetableService.GetTimetableOnDayForGroupAsync(groupDTO, dateTime);

            if (timetableDB == null)
            {
                return NotFound();
            }

            return timetableDB;
        }
        [Route("forLectural")]
        public async Task<ActionResult<IEnumerable<TTDTOOut>>> GetTimetableOnDayByLecturalAsync(DateTime dateTime, string lectural)
        {
            var timetableDB = await _timetableService.GetTimetableOnDayForLecturalAsync(lectural, dateTime);

            if (timetableDB == null)
            {
                return NotFound();
            }

            return timetableDB;
        }
        #endregion


        // PUT: api/TimetableDBs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimetableDB(Guid id, TTDTOOut tTDTOOut)
        {
            if (id != tTDTOOut.id)
            {
                return BadRequest();
            }

            var t = await _timetableService.UpdateTimeTibleAsync(id, tTDTOOut);
            if (t != null)
            {
                return CreatedAtAction("GetTimetableDB", new { id = t.id }, t);
            }

            return NoContent();
        }

        // POST: api/TimetableDBs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TTDTOOut>> PostTimetableDB(TTDTOOut tTDTOOut)
        {
            
           var t = await _timetableService.AddTimetableAsync(tTDTOOut);
            if(t != null)
                return CreatedAtAction("GetTimetableDB", new { id = t.id }, t);
            else
                return NoContent();
        }
        // POST: api/TimetableDBs/changeLectural
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("changeLectural")]
        public async Task<ActionResult<int>> PostLecturalInTimetable(string lecturalOlD, string lecturalNew)
        {
            //Response
            var result = await _timetableService.ChangeLecturalInTimetable(lecturalOlD , lecturalNew );
            if (result == -1) 
            {
                return NotFound();
            }
            return result;
        }

        // DELETE: api/TimetableDBs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TTDTOOut>> DeleteTimetableDB(Guid id)
        {
            var t = await _timetableService.DeleteTimetableAsync(id);
           
            if (t == null)
            {
                return NotFound();
            }           

            return t;
        }

       
    }
}
