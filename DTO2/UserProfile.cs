using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DTO
{
    public class UserProfile
    {
        [Key]
        public int UserProfileId { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(11)]
        public string PersonalNumber { get; set; } = null!;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
