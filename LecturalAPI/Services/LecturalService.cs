using LecturalAPI.Models;
using LecturalAPI.Models.dataBaseModel;
using LecturalAPI.Models.dataTransferModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Services
{
    public class LecturalService
    {
        private readonly AppdbContext _context;

        public LecturalService(AppdbContext context)
        {
            _context = context;
        }
        public async Task<List<LecturalDTO>> GetAllLecturalAsync(int Page = 0, int pageSizeCount = 5)
        {
            int cnt = _context.Lectural.Local.Count();
            var lectural = await _context.Lectural.Include(c => c.Position)
                                                  .Include(c => c.MilitaryRank)
                                                  .Include(c => c.AcademicTitle)
                                                  .Include(c => c.AcademicDegree)
                                                  .Skip(Page * pageSizeCount).Take(pageSizeCount)
                                                  .ToListAsync();


            List<LecturalDTO> lecturalDTO = new List<LecturalDTO>();
            foreach (var g in lectural)
            {

                lecturalDTO.Add(new LecturalDTO(g));
            }
            return lecturalDTO;
        }
        public async Task<List<LecturalMininfo>> GetAllLecturalMinInfoAsync(int Page = 0, int pageSizeCount = 5)
        {

            var lectural = await _context.Lectural.Include(c => c.Position)
                                                  .Include(c => c.MilitaryRank)
                                                  .Skip(Page * pageSizeCount).Take(pageSizeCount)
                                                  .ToListAsync();


            List<LecturalMininfo> lecturalDTO = new List<LecturalMininfo>();
            foreach (var g in lectural)
            {

                lecturalDTO.Add(new LecturalMininfo(g));
            }
            return lecturalDTO;
        }

        public async Task<LecturalDTO> GetLecturalByIdAsync(Guid id)
        {
            var lecturalDB = await _context.Lectural.Where(c => c.id == id)
                                                    .Include(c => c.Position)
                                                    .Include(c => c.MilitaryRank)
                                                    .Include(c => c.AcademicTitle)
                                                    .Include(c => c.AcademicDegree)
                                                    .FirstOrDefaultAsync();
            if (lecturalDB != null)
            {
                LecturalDTO lecturalDTO = new LecturalDTO(lecturalDB);
                return lecturalDTO;
            }

            return null;
        }

        internal async Task<ActionResult<IEnumerable<LecturalMininfo>>> GetAllLecturalFilterdAsync(string firstName, string middleName, string lastName,
                                                                                                   string militaryRank, string position, string academicTitle,
                                                                                                   string academicDegree, string formSec)
        {
            List<string> lists = new List<string>();
            lists.Add(firstName);
            lists.Add(middleName);
            lists.Add(lastName);
            lists.Add(militaryRank);
            lists.Add(position);
            lists.Add(academicTitle);
            lists.Add(academicDegree);
            lists.Add(formSec);
            List<Lectural> lecturals = new List<Lectural>();
            int cnt = 0;
            foreach (var p in lists)
            {
                if (p != "undefined")
                {
                    switch (cnt)
                    {
                        case 0:
                            if (lecturals.Count != 0)
                            {
                                lecturals = lecturals.Where(c => c.firstName == p).ToList();
                                break;
                            }
                            else
                            {
                                lecturals = await _context.Lectural.Where(c => c.firstName == p).ToListAsync();
                                break;
                            }
                        case 1:
                            if (lecturals.Count != 0)
                            {
                                lecturals = lecturals.Where(c => c.middleName == p).ToList(); break;
                            }

                            lecturals = await _context.Lectural.Where(c => c.middleName == p).ToListAsync(); break;
                        case 2:
                            if (lecturals.Count != 0)
                            {
                                lecturals = lecturals.Where(c => c.lastName == p).ToList(); break;
                            }
                            lecturals = await _context.Lectural.Where(c => c.lastName == p).ToListAsync(); break;

                        case 3:
                            if (lecturals.Count != 0)
                            {
                                lecturals = lecturals.Where(c => c.MilitaryRank.name == p).ToList(); break;
                            }
                            lecturals = await _context.Lectural.Where(c => c.MilitaryRank.name == p).ToListAsync(); break;

                        case 4:
                            if (lecturals.Count != 0)
                            {
                                lecturals = lecturals.Where(c => c.Position.name == p).ToList(); break;
                            }
                            lecturals = await _context.Lectural.Where(c => c.Position.name == p).ToListAsync(); break;

                        case 5:
                            if (lecturals.Count != 0)
                            {
                                lecturals = lecturals.Where(c => c.AcademicTitle.name == p).ToList(); break;
                            }
                            lecturals = await _context.Lectural.Where(c => c.AcademicTitle.name == p).ToListAsync(); break;

                        case 6:
                            if (lecturals.Count != 0)
                            {
                                lecturals = lecturals.Where(c => c.AcademicDegree.name == p).ToList(); break;
                            }
                            lecturals = await _context.Lectural.Where(c => c.AcademicDegree.name == p).ToListAsync(); break;

                        case 7:
                            if (lecturals.Count != 0)
                            {
                                lecturals = lecturals.Where(c => c.FormSec == Int32.Parse(p)).ToList(); break;
                            }
                            lecturals = await _context.Lectural.Where(c => c.FormSec == Int32.Parse(p)).ToListAsync(); break;

                        default: break;

                    }

                }
                cnt++;
            }
            if (lecturals == null)
                return null;
            var lecturalDTO = new List<LecturalMininfo>();
            foreach (var l in lecturals)
            {
                lecturalDTO.Add(new LecturalMininfo(l));
            }

            return lecturalDTO;
        }

        public async Task<LecturalDTO> UpdateLecturalAsync(Guid id, LecturalDTO lecturalDTO)
        {
            var lectural = await _context.Lectural.Where(c => c.id == id)
                                            .Include(c => c.Position)
                                            .Include(c => c.MilitaryRank)
                                            .Include(c => c.AcademicTitle)
                                            .Include(c => c.AcademicDegree)
                                            .FirstOrDefaultAsync();

            if (lectural == null || lectural.id != id)
            {
                return null;
            }

            lectural.id = lecturalDTO.id;
            lectural.firstName = lecturalDTO.firstName;
            lectural.lastName = lecturalDTO.lastName;
            lectural.middleName = lecturalDTO.middleName;

            lectural.birthDay = lecturalDTO.birthDay;
            lectural.pathPhotoSmall = lecturalDTO.pathPhotoSmall;
            lectural.pathPhotoBig = lecturalDTO.pathPhotoBig;
            lectural.serialAndNumderMilitaryDocs = lecturalDTO.serialAndNumderMilitaryDocs;
            lectural.serialAndNumderCivilyDocs = lecturalDTO.serialAndNumderCivilyDocs;
            lectural.dateOfStartService = lecturalDTO.dateOfStartService;
            lectural.isMarried = lecturalDTO.isMarried;
            lectural.countOfChildren = lecturalDTO.countOfChildren;
            lectural.info = lecturalDTO.info;

            if (lectural.AcademicDegree != null)
            {
                if (lectural.AcademicDegree.name != lecturalDTO.AcademicDegree)
                {
                    AcademicDegree academicDegree = _context.AcademicDegree.Where(c => c.name == lecturalDTO.AcademicDegree).FirstOrDefault();
                    lectural.AcademicDegree = academicDegree;
                }
            }
            else
            {
                AcademicDegree academicDegree = _context.AcademicDegree.Where(c => c.name == lecturalDTO.AcademicDegree).FirstOrDefault();
                lectural.AcademicDegree = academicDegree;
            }
            if (lectural.AcademicTitle != null)
            {
                if (lectural.AcademicTitle.name != lecturalDTO.AcademicTitle)
                {
                    AcademicTitle academicTitle = _context.AcademicTitle.Where(c => c.name == lecturalDTO.AcademicTitle).FirstOrDefault();
                    lectural.AcademicTitle = academicTitle;
                }
            }
            else
            {
                AcademicTitle academicTitle = _context.AcademicTitle.Where(c => c.name == lecturalDTO.AcademicTitle).FirstOrDefault();
                lectural.AcademicTitle = academicTitle;
            }

            if (lectural.Position != null)
            {
                if (lectural.Position.name != lecturalDTO.Position)
                {
                    Position position = _context.Position.Where(c => c.name == lecturalDTO.Position).FirstOrDefault();
                    lectural.Position = position;
                }
            }
            else
            {
                Position position = _context.Position.Where(c => c.name == lecturalDTO.Position).FirstOrDefault();
                lectural.Position = position;
            }
            if (lectural.MilitaryRank != null)
            {
                if (lectural.MilitaryRank.name != lecturalDTO.MilitaryRank)
                {
                    MilitaryRank militaryRank = _context.MilitaryRank.Where(c => c.name == lecturalDTO.MilitaryRank).FirstOrDefault();
                    lectural.MilitaryRank = militaryRank;
                }
            }
            else
            {
                MilitaryRank militaryRank = _context.MilitaryRank.Where(c => c.name == lecturalDTO.MilitaryRank).FirstOrDefault();
                lectural.MilitaryRank = militaryRank;
            }


            _context.Entry(lectural).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return lecturalDTO;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturalExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool LecturalExists(Guid id)
        {
            return _context.Lectural.Any(e => e.id == id);
        }

        public async Task<LecturalDTO> DeleteLectureAsync(Guid id)
        {

            var lecture = await _context.Lectural.Where(c => c.id == id)
                                           .Include(c => c.MilitaryRank)
                                           .Include(c => c.Position)
                                           .Include(c => c.AcademicDegree)
                                           .Include(c => c.AcademicTitle)
                                           .FirstOrDefaultAsync();
            if (lecture == null || lecture.id != id)
            {
                return null;
            }

            LecturalDTO DTO = new LecturalDTO(lecture);
            _context.Lectural.Remove(lecture);
            try
            {
                await _context.SaveChangesAsync();
                return DTO;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturalExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

        }


        public async Task<LecturalDTO> AddLecturalAsync(LecturalDTO lecturalDTO)
        {
            MilitaryRank militaryRank = await _context.MilitaryRank.Where(c => c.name == lecturalDTO.MilitaryRank).FirstOrDefaultAsync();
            Position position = await _context.Position.Where(c => c.name == lecturalDTO.Position).FirstOrDefaultAsync();
            AcademicDegree academicDegree = await _context.AcademicDegree.Where(c => c.name == lecturalDTO.AcademicDegree).FirstOrDefaultAsync();
            AcademicTitle academicTitle = await _context.AcademicTitle.Where(c => c.name == lecturalDTO.AcademicTitle).FirstOrDefaultAsync();


            Lectural newLecture = new Lectural(lecturalDTO, militaryRank, position, academicDegree, academicTitle);

            try
            {
                _context.Lectural.Add(newLecture);

                await _context.SaveChangesAsync();
                return lecturalDTO;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturalExists(lecturalDTO.id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }


    }
}
