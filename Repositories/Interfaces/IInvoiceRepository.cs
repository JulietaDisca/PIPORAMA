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
        Task<MediosPago> GetPaymentMethodByName(string metodo);
        Task<FormaCompra> GetPurchaseFormByName(string forma);
        Task<EstadosCompra> GetPurchaseStatusByName(string estado);
        Task<Combo> GetComboByName(string combo);
        Task<Consumible> GetConsumableByName(string consumible);
        Task<Promocione> GetPromotionByName(string promocion);
        Task<Pelicula> GetMovieByTitle(string titulo);
        Task<Sala> GetRoomByName(string sala);
        Task<Butaca> GetSeatByRowNumber(string row, int? number);
        Task<Funcione?> GetFunctionByMovieRoomDateAsync(int movieId, int roomId, DateTime? horario);
    }
}
