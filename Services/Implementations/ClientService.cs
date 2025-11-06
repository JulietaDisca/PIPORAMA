using TP_ProgramaciónII_PIPORAMA.Data.DTOs;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repo;
        public ClientService(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ActivateClientAsync(int clientId)
        {
            return await _repo.ActivateClientAsync(clientId);
        }

        public async Task AddClientAsync(ClientDTO client)
        {
            var newClient = new Cliente
            {
                IdCliente = client.Codigo,
                DniCliente = client.DniCliente,
                NomCliente = client.Nombre,
                ApeCliente = client.Apellido,
                IdBarrio = client.IdBarrio,
                Activo = client.Activo,
                IdTipoCliente = client.IdTipoCliente,
                IdContactoNavigation = new Contacto
                {
                    IdContacto = client.Contacto.IdContacto,
                    Descripcion = client.Contacto.Descripcion,
                    IdTipoContacto = client.Contacto.IdTipoContacto
                }


            };
            await _repo.AddClientAsync(newClient,newClient.IdContactoNavigation);


        }

        public async Task<bool> DeleteClientAsync(int clientId)
        {
            return await _repo.DeleteClientAsync(clientId);
        }

        public async Task<IEnumerable<ClientDTO>> GetAllClientsAsync()
        {
            var clients = await _repo.GetAllClientsAsync();
            var clientDTOs = clients.Select(c => new ClientDTO
            {
                Codigo = c.IdCliente,
                DniCliente = c.DniCliente,
                Nombre = c.NomCliente,
                Apellido = c.ApeCliente,
                IdTipoCliente = c.IdTipoCliente,
                IdBarrio = c.IdBarrio,
                Activo = c.Activo,
                


            }).ToList();
            return clientDTOs;

        }

        public async Task<ClientDTO> GetClientByDniAsync(string clientDni)
        {
            var client = await _repo.GetClientByDniAsync(clientDni);
            if (client == null) return null;
            return new ClientDTO
            {
                Codigo = client.IdCliente,
                DniCliente = client.DniCliente,
                Nombre = client.NomCliente,
                Apellido = client.ApeCliente,
                IdTipoCliente = client.IdTipoCliente,
                IdBarrio = client.IdBarrio,
                Activo = client.Activo,
                
            };
        }

        public async Task<ClientDTO> UpdateClientAsync(Cliente client)
        {
            var updatedClient = await _repo.UpdateClientAsync(client);
            if (updatedClient != null)
            {
                return new ClientDTO
                {
                    Codigo = updatedClient.IdCliente,
                    DniCliente = updatedClient.DniCliente,
                    Nombre = updatedClient.NomCliente,
                    Apellido = updatedClient.ApeCliente,
                    IdTipoCliente = updatedClient.IdTipoCliente,
                    IdBarrio = updatedClient.IdBarrio,
                    Activo = updatedClient.Activo,
                    
                };
            }
            return null;
        }
    }
}
