using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientsAsync();
        Task<Cliente?> GetClientByDniAsync(string dni);
        Task<Cliente> AddClientAsync(Cliente client,Contacto contacto);
        Task<Cliente> UpdateClientAsync(Cliente client);
        Task<bool> DeleteClientAsync(int clientId);
    }
}
