using System.ComponentModel.DataAnnotations;

namespace ciberforo.Dtos;

public record class TopicDto(
    int Id,
    
    [Required]
    [StringLength(200)]
    string Title,
    
    [Required]
    string Content,
    
    bool IsDeleted,
    
    DateTime CreatedAt,
    
    DateTime UpdatedAt,
    
    int UserId,
    UserDto? Userdto
);
