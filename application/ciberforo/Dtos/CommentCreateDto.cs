using System.ComponentModel.DataAnnotations;

namespace ciberforo.Dtos;

public record class CommentCreateDto(
    [Required]
    int TopicId,
    
    [Required]
    int UserId,
    
    [Required]
    string Content
);
