using System.ComponentModel.DataAnnotations;

namespace ciberforo.Dtos;

public record class TopicCreateDto(
    [Required]
    [StringLength(200)]
    string Title,
    
    [Required]
    string Content,
    
    [Required]
    int UserId
);
