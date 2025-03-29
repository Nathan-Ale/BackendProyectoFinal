using Microsoft.AspNetCore.Mvc;
using RemindMe.Models;
using RemindMe.Services;

namespace RemindMe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordatoriosController : ControllerBase
    {
        private readonly RecordatorioService _service;

        public RecordatoriosController(RecordatorioService service)
        {
            _service = service;
        }

        // GET: api/recordatorios
        [HttpGet]
        public async Task<ActionResult<List<Recordatorio>>> GetAll()
        {
            return Ok(await _service.ObtenerTodos());
        }

        // GET: api/recordatorios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Recordatorio>> GetById(Guid id)
        {
            var recordatorio = await _service.ObtenerPorId(id);
            if (recordatorio == null) return NotFound("Recordatorio no encontrado");
            return Ok(recordatorio);
        }

        // POST: api/recordatorios
        [HttpPost]
        public async Task<ActionResult<Recordatorio>> Create([FromBody] Recordatorio recordatorio)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var nuevoRecordatorio = await _service.Crear(recordatorio);
            return CreatedAtAction(nameof(GetById), new { id = nuevoRecordatorio.Id }, nuevoRecordatorio);
        }

        // PUT: api/recordatorios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Recordatorio recordatorio)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var resultado = await _service.Actualizar(id, recordatorio);
            if (!resultado) return NotFound("Recordatorio no encontrado");
            return NoContent();
        }

        // DELETE: api/recordatorios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var resultado = await _service.Eliminar(id);
            if (!resultado) return NotFound("Recordatorio no encontrado");
            return NoContent();
        }
    }
}
