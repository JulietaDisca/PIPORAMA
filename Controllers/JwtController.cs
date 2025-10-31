using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IJwtService _service;

        public JwtController(IJwtService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserEmployeeDTO user)
        {
            if (_service.ValidateLogin(user))
            {
                var newToken = _service.GenerateToken(user.Usuario);

                return Ok(new { Token = newToken });
            }

            return Unauthorized();
        }
    }
}
