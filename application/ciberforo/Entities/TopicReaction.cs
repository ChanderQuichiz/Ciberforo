using System.ComponentModel.DataAnnotations;

namespace ciberforo.Entities
{
    public class TopicReaction
    {
        public int Id { get; set; }
        
        [Required]
        public enums.ReactionType ReactionType { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }

        // Foreign keys
        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }
        
        [Required]
        public int TopicId { get; set; }
        public Topic? Topic { get; set; }
    }
}
