using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Interfaces;
namespace TP_ProgramaciónII_PIPORAMA.Services
    
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repo;
        public ClientService(IClientRepository repo)
        {
            _repo=repo;
        }
        public async Task<bool> AddClientAsync(Cliente client)
        {
            return await _repo.AddClientAsync(client);
        }

        public async Task<bool> DeleteClientAsync(int clientId)
        {
            return await _repo.DeleteClientAsync(clientId);
        }

        public async Task<List<Cliente>> GetAllClientsAsync()
        {
            return await _repo.GetAllClientsAsync();
        }

        public async Task<bool> UpdateClientAsync(Cliente client)
        {
            return await _repo.UpdateClientAsync(client);
        }
    }
}
