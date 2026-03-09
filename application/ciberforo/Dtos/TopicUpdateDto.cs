using System.ComponentModel.DataAnnotations;

namespace ciberforo.Dtos;

public record class TopicUpdateDto(
    [Required]
    int Id,
    
    [Required]
    [StringLength(200)]
    string Title,
    
    [Required]
    string Content
);
