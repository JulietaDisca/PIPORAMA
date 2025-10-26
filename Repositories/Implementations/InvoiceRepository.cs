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
        public Task<bool> AddInvoice(Factura invoice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteInvoice(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Factura>> GetAllInvoices()
        {
            return await _context.Facturas
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdEmpleadoNavigation)
                .Include(f => f.IdMedioPagoNavigation)
                .Include(f => f.IdFormaCompraNavigation)
                .ToListAsync();
        }

        public async Task<Factura?> GetInvoiceById(int id)
        {
            return await _context.Facturas
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdEmpleadoNavigation)
                .Include(f => f.IdMedioPagoNavigation)
                .Include(f => f.IdFormaCompraNavigation)
                .FirstOrDefaultAsync(f => f.IdFactura == id);
        }
    }
}
