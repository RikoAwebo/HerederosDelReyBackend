using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HerederosDelReyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _service;
        public CompraController(ICompraService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var compra = await _service.GetByIdAsync(id);

            if (compra == null)
                return NotFound(new { mensaje = "compra no encontrada" });

            return Ok(compra);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompraCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CompraUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ok = await _service.UpdateAsync(id, dto);

            if (!ok)
                return NotFound(new { mensaje = "compra no encontrada" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);

            if (!ok)
                return NotFound(new { mensaje = "compra no encontrada" });

            return NoContent();
        }
        [HttpGet("Paginacion")]
        public async Task<IActionResult> GetAllPag([FromQuery] PostQueryFilter filter)
        {
            var response = await _service.GetAllAsync(filter);
            return Ok(response);
        }

        [HttpPost]
        [Route("compra-detalle")]
        public async Task<IActionResult> CompraDetalle([FromBody] CompraDetalleDto dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");

            try
            {
                var result = await _service.CompraDetalle(dto);

                if (result)
                    return Ok(new { message = "Compra registrada correctamente" });

                return StatusCode(500, "No se pudo registrar la compra");
            }
            catch (Exception ex)
            {
                // En producción deberías loguear esto
                return StatusCode(500, new
                {
                    message = "Error interno",
                    error = ex.Message
                });
            }
        }
    }
}
