using System.ComponentModel.DataAnnotations;

namespace ciberforo.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Email { get; set; } 
        
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        
        [Required]
        public UserRole Role { get; set; }
        
        [Required]
        public bool IsBanned { get; set; }
        
        [Required]
        public bool IsDeleted { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
