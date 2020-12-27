using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class BillDto
    {
        public int Id { get; set; }

        [Required]
        public int StaffId { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DayOfSale { get; set; }

        public int? PromotionDetailId { get; set; }
    }
}
