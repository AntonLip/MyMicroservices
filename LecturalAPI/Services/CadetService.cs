using AutoMapper;
using LecturalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Services
{
    public class CadetService
    {
        private readonly AppdbContext _context;
        //private readonly IConfigurationProvider _configuration;


        public CadetService(AppdbContext context)
        {
            _context = context;          

        }

        internal async Task<List<Cadet>> GetAllCadetsAsync()
        {
            var cadetsDB = await _context.Cadet.Include(c => c.GroupDB)
                                               .Include(s => s.GroupDB.ProfessionDB)
                                               .Include(s => s.GroupDB.SpecializationDB)
                                               .ToListAsync();
            List<Cadet> cadetsDTO = new List<Cadet>();
            foreach (var cadetDB in cadetsDB)
            {
                cadetsDTO.Add(new Cadet(cadetDB));
            }
            return cadetsDTO;
        }
        internal async Task<Cadet> GetCadetByIdAsync(Guid id)
        {
            var grups = await _context.Cadet.Where(c => c.id == id).Include(c => c.GroupDB)
                                                                   .Include(s =>s.GroupDB.ProfessionDB)
                                                                   .Include(s => s.GroupDB.SpecializationDB)
                                                                   .FirstOrDefaultAsync();
            Cadet cadetDTO = new Cadet(grups);

            return cadetDTO;
        }

        internal async Task<Cadet> UpdateCadetAsync(Guid id, Cadet cadetDTO)
        {
            var cadets = await _context.Cadet.Where(c => c.id == id)
                                            .Include(c => c.GroupDB)
                                            .Include(c => c.GroupDB.ProfessionDB)
                                            .Include(c => c.GroupDB.SpecializationDB)
                                            .FirstOrDefaultAsync();

            if (cadets == null || cadets.id != id)
            {
                return null;
            }
            cadets = UpdateCadetInDB(cadetDTO, cadets);



            _context.Entry(cadets).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return cadetDTO;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadetDBExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        internal async Task<Cadet> AddCadetAsync(Cadet cadet)
        {
            var gr = await  _context.Group.Where(c => c.numberOfGroup == cadet.groupNumber).FirstOrDefaultAsync();
            var militeryRank = await _context.MilitaryRank.Where(c => c.name == cadet.militaryRank).FirstOrDefaultAsync();
            var position = await _context.Position.Where(c => c.name == cadet.Position).FirstOrDefaultAsync();
            if (gr == null || militeryRank == null || position == null)
            {
                return null;
            }
            CadetDB cadetDB = new CadetDB(gr, cadet);
            try 
            {
                _context.Cadet.Add(cadetDB);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadetDBExists(cadet.id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
           
            return cadet;
        }

        internal async Task<Cadet> DeletecadetAsync(Guid id)
        {
            var cadetDB = await _context.Cadet.FindAsync(id);
            if (cadetDB == null)
            {
                return null;
            }
            _context.Cadet.Remove(cadetDB);
            await _context.SaveChangesAsync();
            
            Cadet cadet = new Cadet(cadetDB);

            return cadet;
        }

        private CadetDB UpdateCadetInDB(Cadet cadet, CadetDB cadetDB)
        {
            /*
            cadetDB.id = cadet.id;
            cadetDB.info = cadet.info;
            cadetDB.isMarried = cadet.isMarried;
            cadetDB.lastName = cadet.lastName;
            cadetDB.middleName = cadet.middleName;
            cadetDB.firstName = cadet.firstName;
            cadetDB.militaryRank = cadet.militaryRank;
            cadetDB.Position = cadet.Position.;
            cadetDB.pathPhotoBig = cadet.pathPhotoBig;
            cadetDB.pathPhotoSmall = cadet.pathPhotoSmall;
            cadetDB.birthDay = cadet.birthDay;
            cadetDB.dateOfStartService = cadet.dateOfStartService;
            

            if (cadetDB.GroupDB.numberOfGroup != cadet.groupNumber)
            {
                GroupDB groupDB = _context.Group.Where(c => c.numberOfGroup == cadet.groupNumber).FirstOrDefault();
                cadetDB.GroupDB = groupDB;
                cadetDB.GroupDBid = groupDB.id;
            }
 */
            return cadetDB;
           
        }
        private bool CadetDBExists(Guid id)
        {
            return _context.Cadet.Any(e => e.id == id);
        }
    }
}
