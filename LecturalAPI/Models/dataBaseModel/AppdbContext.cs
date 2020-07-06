using LecturalAPI.Models.dataBaseModel;
using Microsoft.EntityFrameworkCore;
using LecturalAPI.Models.dataTransferModel;

namespace LecturalAPI.Models
{
    public class AppdbContext:DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options)
            : base(options)
        {

        }

        public DbSet<Lectural> Lectural { get; set; }
        internal DbSet<CadetDB> Cadet { get; set; }
        public DbSet<DisciplineDB> Discipline { get; set; }
        public DbSet<GroupDB> Group { get; set; }
        public DbSet<LessonDB> Lesson { get; set; }
        public DbSet<LessonTypeDB> LessonType { get; set; }
        public DbSet<ProfessionDB> Profession { get; set; }
        public DbSet<SpecializationDB> Specialization { get; set; }
        public DbSet<AcademicDegree> AcademicDegree { get; set; }
        public DbSet<AcademicTitle> AcademicTitle { get; set; }
        public DbSet<MilitaryRank> MilitaryRank { get; set; }
        public DbSet<Position> Position { get; set; }

    }
}
