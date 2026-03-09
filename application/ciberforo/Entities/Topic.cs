using System.ComponentModel.DataAnnotations;

namespace ciberforo.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        public DateTime UpdatedAt { get; set; }

        // Foreign key
        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }

        // Navigation properties (composición)
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
