namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public ClientDTO Client { get; set; }
        public EmployeeDTO Employee { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string PaymentMethod { get; set; }
        public string InvoiceOrigin { get; set; } 
    }

}
