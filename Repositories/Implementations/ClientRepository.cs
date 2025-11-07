using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> ActivateClientAsync(int clientId)
        {
            var client = await _context.Clientes.FindAsync(clientId);
            if (client == null) 
            {
                return false;
            }
            client.Activo = true;
            _context.Clientes.Update(client);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Cliente> AddClientAsync(Cliente client,Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();
            client.IdContacto = contacto.IdContacto;

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
            var client = await _context.Clientes.Include(c=>c.IdContactoNavigation).FirstOrDefaultAsync(c=>c.DniCliente==dni);
            if (client != null)
            {
                return client;
            }
            return null;

        }

        public async Task UpdateClientAsync(Cliente client)
        {
            _context.Clientes.Update(client);
            await _context.SaveChangesAsync();

        }
    }
}
