using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class BillDetailDto
    {
        public int Id { get; set; }

        [Required]
        public int BillId { get; set; }

        [Required]
        public int DrinkId { get; set; }

        [Required]
        public int Quantity { get; set; }
        
    }
}
