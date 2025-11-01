using TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;

namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public string DniClient { get; set; }
        public string DniEmployee { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PurchaseStatus { get; set; }
        public string PurchaseForm { get; set; }
        public required List<DetailInvoiceDTO>? DetailInvoices { get; set; }
        public bool IsActive { get; set; }
    }

    public class DetailInvoiceDTO
    {
        public double? Price { get; set; }
        public string? Consumable { get; set; }
        public string? Combo { get; set; }
        public TicketDTO? Ticket { get; set; }
        public PromotionDTO? Promotion { get; set; }
    }

}
