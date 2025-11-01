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

        public async Task<Combo> GetComboByName(string combo)
        {
            return await _context.Combos.FirstOrDefaultAsync(c => c.NomCombo == combo);
        }

        public async Task<Consumible> GetConsumableByName(string consumible)
        {
            return await _context.Consumibles.FirstOrDefaultAsync(c => c.NomConsumible == consumible);
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

        public async Task<Pelicula> GetMovieByTitle(string titulo)
        {
            return await _context.Peliculas.FirstOrDefaultAsync(p => p.NomPelicula == titulo);
        }

        public async Task<MediosPago> GetPaymentMethodByName(string metodo)
        {
            return await _context.MediosPagos.FirstOrDefaultAsync(m => m.MedioPago == metodo);
        }

        public async Task<Promocione> GetPromotionByName(string promocion)
        {
            return await _context.Promociones.FirstOrDefaultAsync(p => p.Descripcion == promocion);
        }

        public async Task<FormaCompra> GetPurchaseFormByName(string forma)
        {
            return await _context.FormaCompras.FirstOrDefaultAsync(f => f.FormaCompra1 == forma);
        }

        public async Task<EstadosCompra> GetPurchaseStatusByName(string estado)
        {
            return await _context.EstadosCompras.FirstOrDefaultAsync(e => e.Descripcion == estado);
        }

        public async Task<Sala> GetRoomByName(string sala)
        {
            return await _context.Salas.FirstOrDefaultAsync(s => s.NomSala == sala);
        }

        public async Task<Butaca> GetSeatByRowNumber(string row, int? number)
        {
            return await _context.Butacas.FirstOrDefaultAsync(b => b.FilaButaca == row && b.NumButaca == number);
        }
        public async Task<Funcione?> GetFunctionByMovieRoomDateAsync(int movieId, int roomId, DateTime? horario)
        {
            return await _context.Funciones
                .FirstOrDefaultAsync(f => f.IdPelicula == movieId && f.IdSala == roomId && f.Horario == horario);
        }
    }
}
