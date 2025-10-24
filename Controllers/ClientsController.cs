using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Services;
using TP_ProgramaciónII_PIPORAMA.DTOs;



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
                if (lst.Count > 0)
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

        
        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] Cliente  client)
        {
            try
            {
                var result = await _service.AddClientAsync(client);
                if (result)
                {
                    return Ok("Cliente agregado exitosamente.");
                }
                return BadRequest("No se pudo agregar el cliente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

        
        [HttpPut]
        public async Task<IActionResult> PutClient([FromBody] Cliente client)
        {
            try
            {
                var result = await _service.UpdateClientAsync(client);
                if(result)
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
