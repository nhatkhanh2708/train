using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class AccountDto
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Username { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public int StaffId { get; set; }
    }
}
