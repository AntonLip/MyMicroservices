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
using LecturalAPI.Models.dataTransferModel;

namespace LecturalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupDBsController : ControllerBase
    {
        //private readonly AppdbContext _context;
        private readonly GroupSerice _groupSerice;

        public GroupDBsController(AppdbContext context)
        {
            //_context = context;
            _groupSerice = new GroupSerice(context);
        }

        // GET: api/GroupDBs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroupDB()
        {
            return await _groupSerice.GetAllGroupsAsync();           
        }

        // GET: api/GroupDBs/Numbers
        [Route("Numbers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupsName>>> GetGroupDBName()
        {
            var grName = await _groupSerice.GetAllGroupsNumbersAsync();
            if (grName != null)
            {
                return grName;
            }
            return null;
        }

        //// GET: api/GroupDBs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDTO>> GetGroupDB(Guid id)
        {

            var group = await _groupSerice.GetGroupByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return group;
        }

        // PUT: api/GroupDBs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<GroupDTO>> PutGroupDB(Guid id, GroupDTO groupDTO)
        {
            if (id != groupDTO.id)
            {
                return BadRequest();
            }
            var group = await _groupSerice.UpdateGroupAsync(id, groupDTO);
            if (group != null)
            {
                return CreatedAtAction("GetGroupDB", new { id = group.id }, group);
            }

            return NoContent();
        }

        // POST: api/GroupDBs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroupDTO>> PostGroupDB(GroupDTO groupDTO)
        {
            var group = await _groupSerice.AddGroupAsync(groupDTO);
            if (group == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetGroupDB", new { id = group.id }, group);
        }

        // DELETE: api/GroupDBs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupDTO>> DeleteGroupDB(Guid id)
        {
            GroupDTO groupDTO = await _groupSerice.DeleteGroupAsync(id);
            if (groupDTO == null)
            {
                return NotFound();
            }

            return groupDTO;
        }
 
    }
}