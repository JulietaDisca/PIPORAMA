using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces
{
    public interface IJwtRepository
    {
        string GenerateToken(string username);
        bool ValidateLogin(UserEmployeeDTO user);
    }
}
