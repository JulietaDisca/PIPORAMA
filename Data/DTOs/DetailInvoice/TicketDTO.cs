namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice
{
    public class TicketDTO
    {
        public int TicketID { get; set; } 
        public FunctionDTO? Function { get; set; }
        public SeatDTO? Seat { get; set; }
    }
}