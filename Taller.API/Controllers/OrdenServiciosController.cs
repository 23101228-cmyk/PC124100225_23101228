using Microsoft.AspNetCore.Mvc;
using Taller.CORE.Core.Entities;
using Taller.CORE.Core.Interfaces;

namespace Taller.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenServiciosController : ControllerBase
    {
        private readonly IOrdenServicioService _service;

        public OrdenServiciosController(IOrdenServicioService service)
        {
            _service = service;
        }

        // GET: api/OrdenServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenServicio>>> GetOrdenServicios()
        {
            var ordenes = await _service.GetAllAsync();
            return Ok(ordenes);
        }

        // GET: api/OrdenServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenServicio>> GetOrdenServicio(int id)
        {
            var ordenServicio = await _service.GetByIdAsync(id);

            if (ordenServicio == null)
            {
                return NotFound();
            }

            return Ok(ordenServicio);
        }

        // POST: api/OrdenServicios
        [HttpPost]
        public async Task<ActionResult<OrdenServicio>> PostOrdenServicio(OrdenServicio ordenServicio)
        {
            var nuevaOrden = await _service.AddAsync(ordenServicio);

            return CreatedAtAction(nameof(GetOrdenServicio), new { id = nuevaOrden.Id }, nuevaOrden);
        }

        // PUT: api/OrdenServicios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenServicio(int id, OrdenServicio ordenServicio)
        {
            var actualizado = await _service.UpdateAsync(id, ordenServicio);

            if (!actualizado)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE: api/OrdenServicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenServicio(int id)
        {
            var eliminado = await _service.DeleteAsync(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}