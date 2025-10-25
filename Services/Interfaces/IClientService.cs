using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.DTOs;

namespace TP_ProgramaciónII_PIPORAMA.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDTO>> GetAllClientsAsync();
        Task<ClientDTO> GetClientByIdAsync(int clientId);
        Task<ClientDTO> AddClientAsync(Cliente client);
        Task<ClientDTO> UpdateClientAsync(Cliente client);
        Task<bool> DeleteClientAsync(int clientId);
    }
}
