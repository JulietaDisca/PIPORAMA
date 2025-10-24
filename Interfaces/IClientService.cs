using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Interfaces
{
    public interface IClientService
    {
        Task<List<Cliente>> GetAllClientsAsync();
        Task<bool> AddClientAsync(Cliente client);
        Task<bool> UpdateClientAsync(Cliente client);
        Task<bool> DeleteClientAsync(int clientId);
    }
}
