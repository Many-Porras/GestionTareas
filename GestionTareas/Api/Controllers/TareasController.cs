using GestionTareas.Application.Dtos;
using GestionTareas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.Api.Controllers
{
    [ApiController]
    [Route("api/v1/tareas")]
    public class TareasController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareasController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? categoriaId)
        {
            var result = await _tareaService.ListarTareasAsync(categoriaId);
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTareaRequest request)
        {
            var result = await _tareaService.CrearTareaAsync(request);

            if (!result.IsSuccess)
            {
                return BadRequest(new { mensaje = result.ErrorMessage });
            }

            return StatusCode(201, new { id = result.Value, mensaje = "Tarea creada con éxito." });
        }
    }
}
