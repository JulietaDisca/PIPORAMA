using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly PIPORAMAContext _context;
        public ClientRepository(PIPORAMAContext context)
        {
            _context = context;
        }
        public async Task<bool> AddClientAsync(Cliente client)
        {
            if(client != null)
            {
                _context.Clientes.Add(client);
                return  await _context.SaveChangesAsync()>0;

            }
            return false;
        }

        public async Task<bool> DeleteClientAsync(int clientId)
        {
            var client = _context.Clientes.Find(clientId);
            if (client != null)
            {
                _context.Clientes.Remove(client);
                return await _context.SaveChangesAsync()>0;
            }
            return false;
        }

        public async Task<List<Cliente>> GetAllClientsAsync()
        {
            var lst = await _context.Clientes.ToListAsync();
            if(lst != null && lst.Count > 0)
            {
                return lst;
            }
            return null;
            
        }

        public async Task<bool> UpdateClientAsync(Cliente client)
        {
            var clientToUpdate = _context.Clientes.Find(client.IdCliente);
            if (clientToUpdate != null)
            {
                clientToUpdate.NomCliente = client.NomCliente;
                clientToUpdate.ApeCliente = client.ApeCliente;
                clientToUpdate.IdTipoCliente = client.IdTipoCliente;
                clientToUpdate.IdBarrio = client.IdBarrio;
                clientToUpdate.IdContacto = client.IdContacto;
                _context.Clientes.Update(clientToUpdate);
                return await _context.SaveChangesAsync()>0;
            }
            return false;
        }
    }
}
