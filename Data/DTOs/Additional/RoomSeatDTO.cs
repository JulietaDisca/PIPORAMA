using TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice;

namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs.Additional
{
    public class RoomSeatDTO
    {
        public RoomDTO Room { get; set; }
        public List<SeatDTO> Seats { get; set; }
    }
}
