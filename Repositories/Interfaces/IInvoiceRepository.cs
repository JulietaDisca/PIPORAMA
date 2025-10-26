using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Factura>> GetAllInvoices();
        Task<Factura?> GetInvoiceById(int id);
        Task<bool> AddInvoice(Factura invoice);
        Task<bool> DeleteInvoice(int id); // borrado lógico
        //no se incluye update porque las facturas no se modifican una vez creadas
    }
}
