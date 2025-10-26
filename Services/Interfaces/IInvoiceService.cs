using TP_ProgramaciónII_PIPORAMA.Data.DTOs;

namespace TP_ProgramaciónII_PIPORAMA.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDTO>> GetAllInvoices();
        Task<InvoiceDTO?> GetInvoiceById(int id);
        Task<bool> AddInvoice(InvoiceDTO invoice);
        Task<bool> DeleteInvoice(int id); // borrado lógico
    }
}
