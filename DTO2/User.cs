using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(64)]
        public string Password { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
