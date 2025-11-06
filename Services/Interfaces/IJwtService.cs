using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;

namespace TP_ProgramaciónII_PIPORAMA.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string username);
        bool ValidateLogin(UserEmployeeDTO user);
    }
}
