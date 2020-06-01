using LecturalAPI.Models.dataBaseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturalAPI.Models
{
    public class AppdbContext:DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options)
            : base(options)
        {

        }

        public DbSet<Lectural> Lectural { get; set; }
        public DbSet<CadetDB> Cadet { get; set; }
        public DbSet<DisciplineDB> Discipline { get; set; }
        public DbSet<GroupDB> GroupDB { get; set; }
        public DbSet<LessonDB> Lesson { get; set; }
        public DbSet<LessonTypeDB> LessonType { get; set; }
        public DbSet<ProfessionDB> Profession { get; set; }
        public DbSet<SpecializationDB> Specialization { get; set; }

    }
}
