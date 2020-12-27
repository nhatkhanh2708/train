using Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class StaffDto
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        public bool Gender { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Required]
        public string Phone { get; set; }

        public string Street { get; set; }
        public string Ward { get; set; }        
        public string City { get; set; }

        [Required]
        public string Position { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Salary { get; set; }

        public byte[] Img { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
