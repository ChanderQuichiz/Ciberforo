using System.ComponentModel.DataAnnotations;
using ciberforo.enums;

namespace ciberforo.Entities
{
    public class Report
    {
        public int Id { get; set; }
        
        [Required]
        public ReportType ReportType { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Reason { get; set; }
        
        [Required]
        public ReportStatus Status { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }

        // Foreign keys
        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }
        [Required]

        public int TopicId { get; set; }
        public Topic? Topic { get; set; }
        [Required]

        public int CommentId { get; set; }
        public Comment? Comment { get; set; }
    }
}
