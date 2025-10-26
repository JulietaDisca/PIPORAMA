namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice
{
    public class TicketDTO
    {
        public int TicketID { get; set; } 
        public int FunctionID { get; set; }
        public int SeatID { get; set; }
        public FunctionDTO Function { get; set; }
        public SeatDTO Seat { get; set; }
    }
}