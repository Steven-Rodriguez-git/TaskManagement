using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> ObtenerTareasAsync();
        Task<Tarea> ObtenerTareaAsync(int id);
        Task AgregarTareaAsync(Tarea tarea);
        Task ActualizarTareaAsync(Tarea tarea);
        Task EliminarTareaAsync(int id);
        Task<bool> CodigoExisteAsync(string codigo);
    }
}
