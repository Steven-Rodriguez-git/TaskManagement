using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly TaskDbContext _context;

        public TareaRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task AgregarTareaAsync(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarTareaAsync(Tarea tarea)
        {
            _context.Tareas.Update(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CodigoExisteAsync(string codigo)
        {
            return await _context.Tareas.AnyAsync(t => t.Codigo == codigo);
        }

        public async Task EliminarTareaAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Tarea> ObtenerTareaAsync(int id)
        {
            return await _context.Tareas.FindAsync(id);
        }

        public async Task<IEnumerable<Tarea>> ObtenerTareasAsync()
        {
            return await _context.Tareas.ToListAsync();
        }
    }
}
