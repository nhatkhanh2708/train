using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class PromotionDetailDto
    {
        public int Id { get; set; }

        [Required]
        public int PromotionId { get; set; }

        public string Content { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Discount { get; set; }
    }
}
