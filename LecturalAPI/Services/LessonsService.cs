using LecturalAPI.Models;
using LecturalAPI.Models.dataBaseModel;
using LecturalAPI.Models.dataTransferModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LecturalAPI.Services
{
    public class LessonsService
    {
        private readonly AppdbContext _context;
        public LessonsService(AppdbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LessonDTO>> GetLessonsAsync()
        {
            var lesson = await _context.Lesson.Include(c => c.LessonTypeDB).Include(c => c.Discipline).ToListAsync();
            List<LessonDTO> lessons = new List<LessonDTO>();
            foreach (var l in lesson)
            {
                lessons.Add(new LessonDTO(l));
            }
            return lessons;
        }




        private bool LessonDTOExists(Guid id)
        {
            return _context.Lesson.Any(e => e.id == id);
        }

        internal async Task<LessonDTO> GetLessonByIdAsync(Guid id)
        {
            var lesson = await _context.Lesson.Include(c => c.LessonTypeDB).Include(c => c.Discipline).FirstAsync(c => c.id == id);

            return new LessonDTO(lesson);
        }

        internal async Task<LessonDTO> CreateLesson(LessonDTO lesson)
        {
            var disciplineDB = await _context.Discipline.Where(c => c.id == lesson.DisciplineId).FirstOrDefaultAsync();
            var lessonType = await _context.LessonType.Where(c => c.name == lesson.lessonType).FirstOrDefaultAsync();
            if(disciplineDB != null && lessonType != null)
            {
                LessonDB lessonDB = new LessonDB(disciplineDB, lessonType, lesson);
                try
                {
                    _context.Lesson.Add(lessonDB);
                    await _context.SaveChangesAsync();
                    return lesson;
                }
                catch (DbUpdateConcurrencyException ex)
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
            }
            return null;
        }


        internal async Task SaveDoc(Guid id, IFormFile body, string path)
        {
            
            try
            {
                var lesson = await _context.Lesson.Where(c => c.id == id).FirstOrDefaultAsync();
                byte[] fileBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await body.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }
                if (lesson != null)
                {
                    switch (path)
                    {
                        case "Methodic": lesson.MethodicMaterials = fileBytes;break;
                        case "Additional": lesson.AdditionalMaterial = fileBytes; break;
                        case "Presentation": lesson.Presentation = fileBytes; break;
                        default:break;
                    }
                   

                }
                _context.Entry(lesson).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }
        }


    }
}
