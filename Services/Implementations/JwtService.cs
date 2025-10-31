using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly IJwtRepository _repository;
        public JwtService(IJwtRepository repository)
        {
            _repository = repository;
        }
        public string GenerateToken(string username)
        {
            return _repository.GenerateToken(username);
        }

        public bool ValidateLogin(UserEmployeeDTO user)
        {
            return _repository.ValidateLogin(user);
        }
    }
}
