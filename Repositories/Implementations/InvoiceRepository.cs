using Microsoft.EntityFrameworkCore;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Implementations
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly PIPORAMAContext _context;
        public InvoiceRepository(PIPORAMAContext context)
        {
            _context = context;
        }
        public async Task<bool> AddInvoice(Factura invoice)
        {
            // Add a new client
            var existingClient = await _context.Clientes
                .FirstOrDefaultAsync(c => c.DniCliente == invoice.IdClienteNavigation.DniCliente);
            if (existingClient is null)
            {
                await _context.Clientes.AddAsync(invoice.IdClienteNavigation);
                await _context.SaveChangesAsync();
                // Recover the new client ID
                invoice.IdCliente = invoice.IdClienteNavigation.IdCliente;
            }
            else
            {
                invoice.IdCliente = existingClient.IdCliente;
            }
            await _context.Facturas.AddAsync(invoice);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteInvoice(int id)
        {
            var invoice = await GetInvoiceById(id);
            if (invoice != null)
            {
                invoice.Activo = false;
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Factura>> GetAllInvoices()
        {
            return await _context.Facturas
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdEmpleadoNavigation)
                .Include(f => f.IdMedioPagoNavigation)
                .Include(f => f.IdFormaCompraNavigation)
                .Include(f => f.IdEstadoCompraNavigation)
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdConsumibleNavigation)
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdComboNavigation)
                .ThenInclude(c => c.DetallesCombos)
                .ThenInclude(dc => dc.IdConsumibleNavigation)
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdEntradaNavigation)
                .ThenInclude(e => e.IdFuncionNavigation)
                .ThenInclude(fn => fn.IdPeliculaNavigation)
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdEntradaNavigation)
                .ThenInclude(e => e.IdFuncionNavigation)
                .ThenInclude(fn => fn.IdSalaNavigation)
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdEntradaNavigation)
                .ThenInclude(e => e.IdButacaNavigation)
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdPromocionNavigation)
                .Where(f => f.Activo)
                .ToListAsync();
        }

        public async Task<Factura?> GetInvoiceById(int id)
        {
            return await _context.Facturas
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdEmpleadoNavigation)
                .Include(f => f.IdMedioPagoNavigation)
                .Include(f => f.IdFormaCompraNavigation)
                .Include(f => f.IdEstadoCompraNavigation)
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdConsumibleNavigation)
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdComboNavigation)
                .ThenInclude(c => c.DetallesCombos)
                .ThenInclude(dc => dc.IdConsumibleNavigation)
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdEntradaNavigation)
                .ThenInclude(e => e.IdFuncionNavigation)
                .ThenInclude(fn => fn.IdPeliculaNavigation)
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdEntradaNavigation)
                .ThenInclude(e => e.IdFuncionNavigation)
                .ThenInclude(fn => fn.IdSalaNavigation)
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdEntradaNavigation)
                .ThenInclude(e => e.IdButacaNavigation)
                .Include(f => f.DetallesFacturas)
                .ThenInclude(df => df.IdPromocionNavigation)
                .Where(f => f.Activo)
                .FirstOrDefaultAsync(f => f.IdFactura == id);
        }
    }
}
