using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;
using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetAllClientsAsync();
        Task<ClientDTO> GetClientByIdAsync(int clientId);
        Task AddClientAsync(ClientDTO client);
        Task<ClientDTO> UpdateClientAsync(Cliente client);
        Task<bool> DeleteClientAsync(int clientId);
    }
}
