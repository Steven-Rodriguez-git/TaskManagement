using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services
{
    public class TareaService : ITareaService
    {
        private readonly ITareaRepository _tareaRepository;

        public TareaService(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        public async Task CrearTareaAsync(Tarea tarea)
        {
      
            if (string.IsNullOrWhiteSpace(tarea.Titulo))
                throw new Exception("El título es obligatorio.");
            if (tarea.FechaVencimiento < DateTime.Now)
                throw new Exception("La fecha de vencimiento debe ser mayor o igual a la fecha actual.");
            if (await _tareaRepository.CodigoExisteAsync(tarea.Codigo))
                throw new Exception("El código ya existe.");

            tarea.FechaCreacion = DateTime.Now;
            await _tareaRepository.AgregarTareaAsync(tarea);
        }

        public async Task<IEnumerable<Tarea>> ObtenerTareasAsync(string estado = null)
        {
            var tareas = await _tareaRepository.ObtenerTareasAsync();

            if (!string.IsNullOrWhiteSpace(estado) && Enum.TryParse<Estado>(estado, true, out var estadoFiltro))
            {
                tareas = System.Linq.Enumerable.Where(tareas, t => t.Estado == estadoFiltro);
            }

            return tareas;
        }

        public async Task<Tarea> ObtenerTareaAsync(int id)
        {
            return await _tareaRepository.ObtenerTareaAsync(id);
        }

        public async Task ActualizarTareaAsync(Tarea tarea)
        {
            if (string.IsNullOrWhiteSpace(tarea.Titulo))
                throw new Exception("El título es obligatorio.");
            if (tarea.FechaVencimiento < DateTime.Now)
                throw new Exception("La fecha de vencimiento debe ser mayor o igual a la fecha actual.");

            await _tareaRepository.ActualizarTareaAsync(tarea);
        }

        public async Task EliminarTareaAsync(int id)
        {
            await _tareaRepository.EliminarTareaAsync(id);
        }
    }
}
