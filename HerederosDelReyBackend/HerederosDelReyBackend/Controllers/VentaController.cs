using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using HerederosDelReyBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HerederosDelReyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _service;

        public VentaController(IVentaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var venta = await _service.GetByIdAsync(id);

            if (venta == null)
                return NotFound(new { mensaje = "venta no encontrada" });

            return Ok(venta);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VentaCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, VentaUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ok = await _service.UpdateAsync(id, dto);

            if (!ok)
                return NotFound(new { mensaje = "venta no encontrada" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);

            if (!ok)
                return NotFound(new { mensaje = "venta no encontrada" });

            return NoContent();
        }

        [HttpGet("Paginacion")]
        public async Task<IActionResult> GetAllPag([FromQuery] PostQueryFilter filter)
        {
            var response = await _service.GetAllAsync(filter);
            return Ok(response);
        }


        [HttpPost]
        [Route("venta-detalle")]
        public async Task<IActionResult> VentaDetalle([FromBody] VentaDetalleDto dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");

            try
            {
                var result = await _service.VentaDetalle(dto);

                if (result)
                    return Ok(new { message = "Venta registrada correctamente" });

                return StatusCode(500, "No se pudo registrar la venta");
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
