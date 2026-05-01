using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HerederosDelReyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajaController : ControllerBase
    {
        private readonly ICajaService _service;
        public CajaController(ICajaService service )
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _service.GetByIdAsync(id);

            if (categoria == null)
                return NotFound(new { mensaje = "caja no encontrada" });

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CajaCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto.FechaApertura = DateTime.Now;
            var creado = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CajaUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ok = await _service.UpdateAsync(id, dto);

            if (!ok)
                return NotFound(new { mensaje = "caja no encontrada" });

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);

            if (!ok)
                return NotFound(new { mensaje = "caja no encontrada" });

            return NoContent();
        }

        [HttpGet("Paginacion")]
        public async Task<IActionResult> GetAllPag([FromQuery] PostQueryFilter filter)
        {
            var response = await _service.GetAllAsync(filter);
            return Ok(response);
        }


        [HttpPut("Cerrar/{id}")]
        public async Task<IActionResult> CerrarCaja(int id)
        {
            var response = await _service.CerrarCajaAsync(id);
            return Ok(response);
        }


    }
}
