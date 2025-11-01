using Microsoft.AspNetCore.Mvc;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP_ProgramaciónII_PIPORAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;
        public ClientsController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientsAsync()
        {
            try
            {
                var lst = await _service.GetAllClientsAsync();
                if (lst.Count() > 0)
                {
                    return Ok(lst);
                }
                return NotFound("No se encontraron clientes.");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

        [HttpGet("{dni}")]
        public async Task<IActionResult> GetClientByDniAsync(string dni)
        {
            try
            {
                var client = await _service.GetClientByDniAsync(dni);
                if (client != null)
                {
                    return Ok(client);
                }
                return NotFound("Cliente no encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] ClientDTO clientdto)
        {
            try
            {
                await _service.AddClientAsync(clientdto);
                return Ok("Cliente creado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }


        [HttpPut]
        public async Task<IActionResult> PutClient([FromBody] ClientDTO clientDTO)
        {
            try
            {
                var client = new Cliente
                {
                    IdCliente = clientDTO.Codigo,
                    DniCliente = clientDTO.DniCliente,
                    NomCliente = clientDTO.Nombre,
                    ApeCliente = clientDTO.Apellido,
                    IdBarrio = clientDTO.IdBarrio,
                    IdContacto = clientDTO.IdContacto,
                    Activo = clientDTO.Activo,
                    IdTipoCliente = clientDTO.IdTipoCliente
                };
                var result = await _service.UpdateClientAsync(client);
                if (result != null)
                {
                    return Ok("Cliente actualizado exitosamente.");
                }
                return BadRequest("No se pudo actualizar el cliente.");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                var result = await _service.DeleteClientAsync(id);
                if (result)
                {
                    return Ok("Cliente eliminado exitosamente.");
                }
                return BadRequest("No se pudo eliminar el cliente.");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}