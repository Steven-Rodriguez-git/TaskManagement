using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareasController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTarea([FromBody] Tarea tarea)
        {
            await _tareaService.CrearTareaAsync(tarea);
            return CreatedAtAction(nameof(ObtenerTarea), new { id = tarea.Id }, tarea);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTareas([FromQuery] string estado)
        {
            var tareas = await _tareaService.ObtenerTareasAsync(estado);
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTarea(int id)
        {
            var tarea = await _tareaService.ObtenerTareaAsync(id);
            if (tarea == null)
                return NotFound();
            return Ok(tarea);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTarea(int id, [FromBody] Tarea tarea)
        {
            if (id != tarea.Id)
                return BadRequest("El ID de la tarea no coincide.");

            await _tareaService.ActualizarTareaAsync(tarea);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTarea(int id)
        {
            await _tareaService.EliminarTareaAsync(id);
            return NoContent();
        }
    }
}
