namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice
{
    public class FunctionDTO
    {
        public int FunctionId { get; set; }
        public DateTime? FunctionDate { get; set; }
        public int FilmId { get; set; }
        public int RoomId { get; set; }
        public FilmDTO Film { get; set; }
        public RoomDTO Room { get; set; }
    }
}