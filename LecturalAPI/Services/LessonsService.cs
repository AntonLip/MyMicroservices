using LecturalAPI.Models;
using LecturalAPI.Models.dataBaseModel;
using LecturalAPI.Models.dataTransferModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Services
{
    public class LessonsService
    {
        private readonly AppdbContext _context;
        public LessonsService(AppdbContext context)
        {
            _context = context;
        }
        internal async Task<List<LessonDTO>> GetAllLessonsAsync()
        {
            var lessonsDB = await _context.Lesson.Include(c => c.Lectural)
                                               .Include(s => s.LessonTypeDB)
                                               .Include(s => s.Discipline)
                                               .ToListAsync();
            List<LessonDTO> lessons = new List<LessonDTO>();
            foreach (var lessonDB in lessonsDB)
            {
                lessons.Add(new LessonDTO(lessonDB));
            }
            return lessons;
        }
        internal async Task<LessonDTO> GetLessonByIdAsync(Guid id)
        {
            var lessonsDB = await _context.Lesson.Include(c => c.Lectural)
                                              .Include(s => s.LessonTypeDB)
                                              .Include(s => s.Discipline)
                                              .FirstOrDefaultAsync();
            LessonDTO lessonDTO = new LessonDTO(lessonsDB);

            return lessonDTO;
        }



        internal async Task<LessonDTO> AddlessonAsync(LessonDTO lessonDTO)
        {
            var lectural = await _context.Lectural.Where(c => c.id == lessonDTO.lecturalId).FirstOrDefaultAsync();
            var gr = await _context.Discipline.Where(c => c.id == lessonDTO.disciplineId).FirstOrDefaultAsync();
            var lessonType = await _context.LessonType.Where(c => c.nameOfType == lessonDTO.lessonType).FirstOrDefaultAsync();
            if (gr == null || lectural == null || lessonType == null)
            {
                return null;
            }
            LessonDB lessonDB = new LessonDB(lectural, gr, lessonType, lessonDTO);
            try
            {
                _context.Lesson.Add(lessonDB);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonDTOExists(lessonDB.id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return lessonDTO;
        }
        internal async Task<LessonDTO> UpdateLessonAsync(Guid id, LessonDTO lessonDTO)
        {
            var lessonsDB = await _context.Lesson.Include(c => c.Lectural)
                                               .Include(s => s.LessonTypeDB)
                                               .Include(s => s.Discipline)
                                               .FirstOrDefaultAsync();

            if (lessonsDB == null || lessonDTO.id != id || lessonDTO.lecturalId == null || lessonDTO.disciplineId == null)
            {
                return null;
            }

            lessonsDB = await ModifyLesson(lessonsDB, lessonDTO);

            _context.Entry(lessonsDB).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return lessonDTO;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonDTOExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        internal async Task<LessonDTO> DeleteLessonAsync(Guid id)
        {
            var lessonDb = await _context.Lesson.FindAsync(id);
            if (lessonDb == null)
            {
                return null;
            }
            _context.Lesson.Remove(lessonDb);
            await _context.SaveChangesAsync();

            LessonDTO lesson = new LessonDTO(lessonDb);

            return lesson;
        }

        private async Task<LessonDB> ModifyLesson(LessonDB lessonDB, LessonDTO lessonDTO)
        {
            lessonDB.id = lessonDTO.id;
            lessonDB.auditoreNumber = lessonDTO.auditoreNumber;
            lessonDB.countHours = lessonDTO.countHours;
            lessonDB.infoForCadets = lessonDTO.infoForCadets;
            lessonDB.infoForEngeneer = lessonDTO.InfoForLectural;
            lessonDB.name = lessonDTO.name;
            lessonDB.sectionName = lessonDTO.sectionName;
            lessonDB.themeName = lessonDTO.themeName;


            if (lessonDB.Discipline != null)
            {
                if (lessonDB.Discipline.id != lessonDTO.disciplineId)
                {
                    DisciplineDB disciplineDB = await _context.Discipline.Where(c => c.id == lessonDTO.disciplineId).FirstOrDefaultAsync();
                    lessonDB.Discipline = disciplineDB;
                }
            }
            else
            {
                DisciplineDB disciplineDB = await _context.Discipline.Where(c => c.id == lessonDTO.disciplineId).FirstOrDefaultAsync();
                lessonDB.Discipline = disciplineDB;
            }
            if (lessonDB.Lectural != null)
            {
                if (lessonDB.Lectural.id != lessonDTO.lecturalId)
                {
                    Lectural lectural = await _context.Lectural.Where(c => c.id == lessonDTO.lecturalId).FirstOrDefaultAsync();
                    lessonDB.Lectural = lectural;
                }
            }
            else
            {
                Lectural lectural = await _context.Lectural.Where(c => c.id == lessonDTO.lecturalId).FirstOrDefaultAsync();
                lessonDB.Lectural = lectural;
            }

            if (lessonDB.LessonTypeDB != null)
            {
                if (lessonDB.LessonTypeDB.nameOfType != lessonDTO.lessonType)
                {
                    LessonTypeDB type = _context.LessonType.Where(c => c.nameOfType == lessonDTO.lessonType).FirstOrDefault();
                    lessonDB.LessonTypeDB = type;
                }
            }
            else
            {
                LessonTypeDB type = _context.LessonType.Where(c => c.nameOfType == lessonDTO.lessonType).FirstOrDefault();
                lessonDB.LessonTypeDB = type;
            }
            return lessonDB;
        }
        private bool LessonDTOExists(Guid id)
        {
            return _context.Lesson.Any(e => e.id == id);
        }
    }
}
