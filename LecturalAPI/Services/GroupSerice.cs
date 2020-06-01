using LecturalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Services
{
    public class GroupSerice
    {
        private readonly AppdbContext _context;
        public async Task<IEnumerable<GroupDB>> GetAllGroupsAsync()
        {
            return await _context.GroupDB.ToListAsync();
        }

    }
}
