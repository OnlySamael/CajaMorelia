using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClienteDTO>> GetById(Guid id)
        {
            var cliente = await _service.GetByIdAsync(id);
            if (cliente is null) return NotFound();
            return Ok(cliente);
        }

        public record CreateClienteRequest(string Nombre, string CorreoElectronico, string Telefono);
        public record UpdateClienteRequest(string Nombre, string CorreoElectronico, string Telefono);


        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Create([FromBody]CreateClienteRequest request)
        {
            try
            {
                var dto = await _service.CreateAsync(new ClienteDTO
                {
                    Nombre = request.Nombre,
                    CorreoElectronico = request.CorreoElectronico,
                    Telefono = request.Telefono
                });
                return Ok(dto);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<ClienteDTO>> Update([FromBody] UpdateClienteRequest request)
        {
            try
            {
                await _service.UpdateAsync(new ClienteDTO
                {
                    Nombre = request.Nombre,
                    CorreoElectronico = request.CorreoElectronico,
                    Telefono = request.Telefono
                });
                return Ok(request);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
