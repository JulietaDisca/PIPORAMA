using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;


namespace TP_ProgramaciónII_PIPORAMA.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetAllClientsAsync();
        Task<ClientDTO> GetClientByDniAsync(string clientDni);
        Task AddClientAsync(ClientDTO client);
        Task UpdateClientAsync(ClientDTO client);
        Task<bool> DeleteClientAsync(int clientId);

        Task<bool> ActivateClientAsync(int clientId);
    }
}
