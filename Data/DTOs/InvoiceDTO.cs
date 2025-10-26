using TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;

namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public ClientInvoiceDTO Client { get; set; }
        public EmployeeInvoiceDTO Employee { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public PaymentMethodDTO PaymentMethod { get; set; }
        public PurchaseStatusDTO PurchaseStatus { get; set; }
        public PurchaseFormDTO PurchaseForm { get; set; }
        public required List<DetailInvoiceDTO>? DetailInvoices { get; set; }
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

    public class ClientInvoiceDTO
    {
        public string ClientDni { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string ClientSurname { get; set; } = string.Empty;
    }
    public class EmployeeInvoiceDTO
    {
        public string EmployeeDni { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeSurname { get; set; } = string.Empty;
    }
}
