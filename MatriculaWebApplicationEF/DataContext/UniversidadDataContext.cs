using MatriculaWebApplicationEF.Models;
using Microsoft.EntityFrameworkCore;

namespace MatriculaWebApplicationEF.DataContext
{
    public class UniversidadDataContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<PaisHacer> PaisHacer { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<MateriasCubrir> MateriasCubrir { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=DESKTOP-3NRVDJ5;DataBase=UniversidadDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstudianteMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
