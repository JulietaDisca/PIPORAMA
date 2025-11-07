using Microsoft.AspNetCore.Mvc;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;

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
                if (!IsValidForCreate(clientdto, out var error))
                {
                    throw new ArgumentException(error);
                }
                await _service.AddClientAsync(clientdto);
                return Ok(clientdto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("/editar/{id}")]
        public async Task<IActionResult> PutClient([FromBody] ClientDTO clientDTO)
        {
            try
            {
                if (!IsValidForUpdate(clientDTO, out var error))
                {
                    throw new ArgumentException(error);
                }
                
                await _service.UpdateClientAsync(clientDTO);
                return Ok("Cliente actualizado exitosamente.");
                
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
                if (!IsValidForDelete(id, out var error))
                {
                    throw new ArgumentException(error);
                }
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

        [HttpPut("{id}")]
        public async Task<IActionResult> ReactivateClient(int id)
        {
            try
            {
                if (!IsValidForDelete(id, out var error))
                {
                    throw new ArgumentException(error);
                }
                var result = await _service.ActivateClientAsync(id);
                if (result)
                {
                    return Ok("Cliente dado de alta exitosamente.");
                }
                return BadRequest("No se pudo dar de alta al cliente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        private bool IsValidForCreate(ClientDTO clientdto, out string error)
        {
            if (clientdto == null)
            {
                error = "ClientDTO es nulo.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(clientdto.DniCliente))
            {
                error = "DNI del cliente es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(clientdto.Nombre))
            {
                error = "Nombre del cliente es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(clientdto.Apellido))
            {
                error = "Apellido del cliente es requerido.";
                return false;
            }
            if (clientdto.IdTipoCliente <= 0)
            {
                error = "IdTipoCliente inválido.";
                return false;
            }
            
            if (clientdto.IdBarrio <= 0)
            {
                error = "IdBarrio inválido.";
                return false;
            }
            
            
            
            error = string.Empty;
            return true;
        }

        private bool IsValidForUpdate(ClientDTO clientdto, out string error)
        {
            if (clientdto == null)
            {
                error = "ClientDTO es nulo.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(clientdto.DniCliente))
            {
                error = "DNI del cliente es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(clientdto.Nombre))
            {
                error = "Nombre del cliente es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(clientdto.Apellido))
            {
                error = "Apellido del cliente es requerido.";
                return false;
            }
            if (clientdto.IdTipoCliente <= 0)
            {
                error = "IdTipoCliente inválido.";
                return false;
            }
            
            
            error = string.Empty;
            return true;
        }

        private bool IsValidForDelete(int id, out string error)
        {
            if (id <= 0)
            {
                error = "Id inválido.";
                return false;
            }
            error = string.Empty;
            return true;
        }
    }
}