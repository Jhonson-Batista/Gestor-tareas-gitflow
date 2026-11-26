using GestorTareas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorTareas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>().HasData(
                new Tarea
                {
                    Id = 1,
                    Titulo = "Estudiar para el parcial",
                    Descripcion = "Repasar los temas de las unidades 1 a 3",
                    Materia = "Programación III",
                    FechaLimite = new DateTime(2026, 12, 10),
                    Prioridad = Prioridad.Alta,
                    Completada = false
                },
                new Tarea
                {
                    Id = 2,
                    Titulo = "Entregar informe de laboratorio",
                    Descripcion = "Subir el PDF a la plataforma",
                    Materia = "Fundamentos de Electrónica",
                    FechaLimite = new DateTime(2026, 12, 3),
                    Prioridad = Prioridad.Media,
                    Completada = false
                },
                new Tarea
                {
                    Id = 3,
                    Titulo = "Leer capítulo 4",
                    Descripcion = null,
                    Materia = "Inglés",
                    FechaLimite = new DateTime(2026, 12, 15),
                    Prioridad = Prioridad.Baja,
                    Completada = true
                }
            );
        }
    }
}