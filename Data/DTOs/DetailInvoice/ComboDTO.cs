namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice
{
    public class ComboDTO
    {
        public int IdCombo { get; set; }
        public string Name { get; set; }

        public List<ConsumableDTO>? Consumables { get; set; }
    }
}