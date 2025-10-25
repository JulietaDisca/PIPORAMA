using Microsoft.Identity.Client;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.DTOs;

namespace TP_ProgramaciónII_PIPORAMA.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Cliente>> GetAllClientsAsync();
        Task<Cliente?> GetClientByIdAsync(int id);
        Task<Cliente> AddClientAsync(Cliente client);
        Task <Cliente> UpdateClientAsync(Cliente client);
        Task<bool> DeleteClientAsync(int clientId);
    }
}
