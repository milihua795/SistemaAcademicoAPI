using Microsoft.EntityFrameworkCore;
using SistemaAcademicoAPI.Models;

namespace SistemaAcademicoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
        public DbSet<Curso> Cursos => Set<Curso>();
        public DbSet<Docente> Docentes => Set<Docente>();
        public DbSet<Horario> Horarios => Set<Horario>();
        public DbSet<Matricula> Matriculas => Set<Matricula>();
    }
}