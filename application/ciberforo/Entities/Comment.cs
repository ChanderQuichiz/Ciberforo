using System.ComponentModel.DataAnnotations;

namespace ciberforo.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; } 
        
        [Required]
        public bool IsDeleted { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        public DateTime UpdatedAt { get; set; }

        // Foreign keys
        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }
        [Required]

        public int TopicId { get; set; }
        public Topic? Topic { get; set; }
    }
}
