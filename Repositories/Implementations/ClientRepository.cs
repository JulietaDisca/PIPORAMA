﻿using Microsoft.EntityFrameworkCore;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly PIPORAMAContext _context;
        public ClientRepository(PIPORAMAContext context)
        {
            _context = context;
        }
        public async Task<Cliente> AddClientAsync(Cliente client, string barrio, Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();
            client.IdContacto = contacto.IdContacto;

            var barrio1 = await _context.Barrios.FirstOrDefaultAsync(b => b.Descripcion == barrio);
            client.IdBarrio = barrio1.IdBarrio;

            _context.Clientes.Add(client);
            await _context.SaveChangesAsync();
            return client;

        }
        public async Task<bool> DeleteClientAsync(int clientId)
        {
            var client = _context.Clientes.Find(clientId);
            if (client != null)
            {
               client.Activo = false;
               _context.Clientes.Update(client);
                return await _context.SaveChangesAsync() > 0;

            }
            return false;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientsAsync()
        {
            var lst = await _context.Clientes
                .Include(b => b.IdBarrioNavigation)
                .Include(tp => tp.IdTipoClienteNavigation)
                .Include(ct => ct.IdContactoNavigation)
                .ToListAsync();
            if (lst != null && lst.Count > 0)
            {
                return lst;
            }
            return null;
        }

        public async Task<Cliente?> GetClientByDniAsync(string dni)
        {
            var client = await _context.Clientes.Include(c => c.IdBarrioNavigation).Include(c => c.IdTipoClienteNavigation)
                .Include(c => c.IdContactoNavigation).FirstOrDefaultAsync(c => c.DniCliente == dni);
            if (client != null)
            {
                return client;
            }
            return null;

        }

        public async Task<Cliente> UpdateClientAsync(Cliente client)
        {
            var clientToUpdate = _context.Clientes.Find(client.IdCliente);
            if (clientToUpdate == null) return null;
            clientToUpdate.DniCliente = client.DniCliente;
            clientToUpdate.NomCliente = client.NomCliente;
            clientToUpdate.ApeCliente = client.ApeCliente;
            clientToUpdate.IdBarrio = client.IdBarrio;
            clientToUpdate.IdContacto = client.IdContacto;
            clientToUpdate.Activo = client.Activo;
            clientToUpdate.IdTipoCliente = client.IdTipoCliente;
            await _context.SaveChangesAsync();
            return clientToUpdate;

        }
    }
}
