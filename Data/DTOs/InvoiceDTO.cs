using TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;

namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public ClientDTO Client { get; set; }
        public EmployeeDTO Employee { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public PaymentMethodDTO PaymentMethod { get; set; }
        public PurchaseStatusDTO PurchaseStatus { get; set; }
        public PurchaseFormDTO PurchaseForm { get; set; }
        public List<DetailInvoiceDTO>? DetailInvoices { get; set; }
        public bool IsActive { get; set; }
    }

    public class DetailInvoiceDTO
    {
        public int DetailInvoiceId { get; set; }
        public double? Price { get; set; }
        public ConsumableDTO? Consumable { get; set; }
        public ComboDTO? Combo { get; set; }
        public TicketDTO? Ticket { get; set; }
        public PromotionDTO? Promotion { get; set; }
    }

    }
