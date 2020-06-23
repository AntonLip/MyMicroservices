using AutoMapper;
using LecturalAPI.Models;
using LecturalAPI.Models.dataBaseModel;
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
        private readonly IConfigurationProvider configuration;

        public GroupSerice(AppdbContext context)
        {
            _context = context;
            configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GroupDB, GroupDTO>();
            }
            );

        }

        public async Task<List<GroupDTO>> GetAllGroupsAsync()
        {

            var grups = await _context.Group.Include(c => c.ProfessionDB).Include(c => c.SpecializationDB).ToListAsync();


            List<GroupDTO> groupsDTO = new List<GroupDTO>();
            foreach (var g in grups)
            {
                GroupDTO groupDTO = new GroupDTO();
                groupDTO.GroupDBtoGroupDTO(g);
                groupsDTO.Add(groupDTO);
            }
            return groupsDTO;
        }


        public async Task<GroupDTO> GetGroupByIdAsync(Guid id)
        {
            var grups = await _context.Group.Where(c => c.id == id).Include(c => c.ProfessionDB).Include(c => c.SpecializationDB).FirstOrDefaultAsync();
            GroupDTO groupsDTO = new GroupDTO();
            groupsDTO.GroupDBtoGroupDTO(grups);
            return groupsDTO;
        }


        public async Task<GroupDTO> UpdateGroupAsync(Guid id, GroupDTO groupDTO)
        {
            var grups = await _context.Group.Where(c => c.id == id)
                                            .Include(c => c.ProfessionDB)
                                            .Include(c => c.SpecializationDB)
                                            .FirstOrDefaultAsync();

            if (grups == null || grups.id != id)
            {
                return null;
            }

            grups.id = grups.id;
            grups.numberOfGroup = groupDTO.numberOfGroup;
            grups.info = groupDTO.info;
            grups.CountCadets = groupDTO.CountCadets;

            if (groupDTO.nameOfSpecialization != grups.SpecializationDB.SpecializationCode)
            {
                SpecializationDB spec = _context.Specialization.Where(c => c.nameOfSpecialization == groupDTO.nameOfSpecialization).FirstOrDefault();
                grups.SpecializationDB = spec;
                grups.ProfessionDBid = spec.id;
            }
            if (groupDTO.ProfessionLastName != grups.ProfessionDB.nameOfProffession)
            {
                ProfessionDB prof = _context.Profession.Where(c => c.nameOfProffession == groupDTO.ProfessionLastName).FirstOrDefault();
                grups.ProfessionDB = prof;
                grups.ProfessionDBid = prof.id;
            }

            _context.Entry(grups).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return groupDTO;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupDBExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<GroupDTO> AddGroupAsync(GroupDTO groupDTO)
        {
            SpecializationDB spec = _context.Specialization.Where(c => c.nameOfSpecialization == groupDTO.nameOfSpecialization)
                                                           .FirstOrDefault();
            ProfessionDB prof = _context.Profession.Where(c => c.nameOfProffession == groupDTO.ProfessionLastName)
                                                   .FirstOrDefault();

            if (spec == null || prof == null)
            {
                return null;
            }


            GroupDB group = new GroupDB
            {
                id = groupDTO.id,
                info = groupDTO.info,
                SpecializationDB = spec,
                ProfessionDB = prof,
                CountCadets = groupDTO.CountCadets,
                numberOfGroup = groupDTO.numberOfGroup,
                ProfessionDBid = prof.id,
                SpecializationDBid = spec.id
            };
            try
            {
                _context.Group.Add(group);
                await _context.SaveChangesAsync();
                return groupDTO;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupDBExists(group.id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<GroupDTO> DeleteGroupAsync(Guid id)
        {

            var g = await _context.Group.Where(c => c.id == id).Include(c => c.ProfessionDB).Include(c => c.SpecializationDB).FirstOrDefaultAsync();
            if (g == null || g.id != id)
            {
                return null;
            }

            GroupDTO groupDTO = new GroupDTO
            {
                id = g.id,
                nameOfSpecialization = g.SpecializationDB.SpecializationCode,
                ProfessionLastName = g.ProfessionDB.nameOfProffession,
                CountCadets = g.CountCadets,
                numberOfGroup = g.numberOfGroup,
                info = g.info
            };
            _context.Group.Remove(g);
            await _context.SaveChangesAsync();
            return groupDTO;
        }

        private bool GroupDBExists(Guid id)
        {
            return _context.Group.Any(e => e.id == id);
        }

    }
}
