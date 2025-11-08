namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice
{
    public class TicketDTO
    {
        public FunctionDTO Function { get; set; }
        public SeatDTO Seat { get; set; }
    }
    public class FunctionDTO
    {
        public int IdFuncion { get; set; }
        public DateTime? FunctionDate { get; set; }
        public string Film { get; set; }
        public string Room { get; set; }
        public int Precio { get; set; }
    }
    public class SeatDTO
    {
        public string SeatRow { get; set; }
        public int? SeatNumber { get; set; }
    }
}