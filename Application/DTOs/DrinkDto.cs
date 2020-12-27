using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class DrinkDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DrinkCategoryId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Descript { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }
        
        public byte[] Img { get; set; }
        public bool Status { get; set; }
    }
}
