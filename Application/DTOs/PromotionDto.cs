using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class PromotionDto
    {
        public int Id { get; set; }

        [StringLength(500, MinimumLength = 3)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime FinishDate { get; set; }

        [Required]
        public sbyte Status { get; set; }
    }
}
