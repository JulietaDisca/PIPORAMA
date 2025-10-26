namespace TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice
{
    public class PromotionDTO
    {
        public int IdPromotion { get; set; }
        public string? Description { get; set; } = string.Empty;
        public decimal? DiscountPercentage { get; set; }
    }
}