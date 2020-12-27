using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class DrinkCategoryDto
    {
        public int Id { get; set; }

        [StringLength(5, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
    }
}
