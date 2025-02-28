using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface ITareaService
    {
        Task<IEnumerable<Tarea>> ObtenerTareasAsync(string estado = null);
        Task<Tarea> ObtenerTareaAsync(int id);
        Task CrearTareaAsync(Tarea tarea);
        Task ActualizarTareaAsync(Tarea tarea);
        Task EliminarTareaAsync(int id);
    }
}
