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

        [Route("GetFileteredTimetable")]
        public async Task<ActionResult<IEnumerable<TTDTOOut>>> GetTimetableFilteredData(string lectural, string discipline, string group, DateTime startDate, DateTime stopDate)
        {
            var timetableDB = await _timetableService.GetTimetableFilteredData(lectural, discipline, group, startDate, stopDate);

            if (timetableDB != null)
            {
                return timetableDB;
            }
            return NotFound();
        }
        #endregion

        #region POST

        // POST: api/TimetableDBs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TTDTOOut>> PostTimetableDB(TTDTOOut tTDTOOut)
        {

            var t = await _timetableService.AddTimetableAsync(tTDTOOut);
            if (t != null)
                return CreatedAtAction("GetTimetableDB", new { id = t.id }, t);
            else
                return NoContent();
        }

        // POST: api/TimetableDBs/changeLectural
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.


        #endregion

        #region PUT
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

        // PUT: api/TimetableDBs/?disciplines=NameOfdisciplines&lecturalOlD=nameOfLectural&lecturalNew=nameOflectural
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ActionResult<int>> PutChangeLecturalInTDiscipline(Guid idDisciplines, string lecturalNew, bool isFullDiscipline, DateTime start, DateTime dateTime)
        {
            if (ModelState.IsValid)
            {
                var result = await _timetableService.ChangeLecturalInTDiscipline(idDisciplines, lecturalNew, isFullDiscipline, start, dateTime);
                if (result == -1)
                {
                    return NotFound();
                }
                else if (result == -2)
                {
                    return Problem("Didn't all updates is ok");
                }
                else if (result == -10)
                {
                    return Problem("Exeption");
                }
                else
                {
                    return result;

                }
            }
            //Response
            return NotFound();
        }


        //PUT: api/TimetableDBs/LessonDate/?id=DA9C95EC-57BD-435C-75A3-08D8A8B7F40D&newDate=2020-09-03 00:00:00.0000000&newNumberOflesson=2
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("LessonDate")]
        [HttpPut]
        public async Task<ActionResult<int>> PutChangeDateOfLesson(Guid id, DateTime newDate,  int newNumberOflesson)
        {
            if (ModelState.IsValid)
            {
                var res = await _timetableService.ChangeDateOfLesson(id, newDate, newNumberOflesson);
                if (res != null)
                {
                    CreatedAtAction("GetTimetableDB", new { id = res.id }, res);
                }
                else 
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }
        //PUT: api/TimetableDBs/Comment/?id=DA9C95EC-57BD-435C-75A3-08D8A8B7F40D&newDate=2020-09-03 00:00:00.0000000&newNumberOflesson=2
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("Comment")]
        [HttpPut]
        public async Task<ActionResult<int>> PutChangeCommentOfLesson(Guid id, string forWho, string info)
        {
            if (ModelState.IsValid)
            {
                var res = await _timetableService.ChangeCommentOfLesson(id, forWho, info);
                if (res != null)
                {
                   return CreatedAtAction("GetTimetableDB", new { id = res.id }, res);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("SetAud")]
        [HttpPut]
        public async Task<ActionResult<TTDTOOut>> PutSetAuditoreInLesson(Guid id, string aud)
        {
            if (ModelState.IsValid)
            {
                var res = await _timetableService.SetAuditoreInLesson(id, aud);
                if (res != null)
                {
                    return CreatedAtAction("GetTimetableDB", new { id = res.id }, res);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion

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
