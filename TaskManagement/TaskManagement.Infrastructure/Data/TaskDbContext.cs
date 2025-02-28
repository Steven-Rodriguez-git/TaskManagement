using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la clave única para el campo Codigo
            modelBuilder.Entity<Tarea>()
                .HasIndex(t => t.Codigo)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
