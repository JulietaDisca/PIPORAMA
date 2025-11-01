using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Implementations
{
    public class JwtRepository : IJwtRepository
    {
        private readonly PIPORAMAContext _context;
        public JwtRepository(PIPORAMAContext context)
        {
            _context = context;
        }

        /// Genera un token JWT para el nombre de usuario especificado.
        /// El token incluye un identificador único (JTI) y el nombre de usuario como claims.
        /// Está firmado usando HMAC SHA256 y expira en 30 minutos.

        public string GenerateToken(string username)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyForJwtEmployees!!!!!!"));

            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var IdentificadorUnico = Guid.NewGuid().ToString();

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, IdentificadorUnico),
                new Claim(JwtRegisteredClaimNames.Sub, username)
            };

            var Token = new JwtSecurityToken(
                issuer: "JwtEmployees",
                audience: "JwtEmployees",
                claims: Claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: Credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

        /// Valida las credenciales de inicio de sesión de un empleado.
        /// Busca en la base de datos un empleado activo cuyo usuario y contraseña coincidan con los proporcionados.
        /// Retorna true si se encuentra una coincidencia, de lo contrario retorna false.
        public bool ValidateLogin(UserEmployeeDTO user)
        {
            var employee = _context.Empleados
                .FirstOrDefault(e => e.Usuario == user.Usuario && e.Contrasenia == user.Contrasenia && e.Activo);
            if (employee != null)
            {
                if (user.Usuario == employee.Usuario && user.Contrasenia == employee.Contrasenia)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
