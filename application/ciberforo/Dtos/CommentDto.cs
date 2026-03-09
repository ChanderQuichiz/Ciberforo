using System.ComponentModel.DataAnnotations;
using ciberforo.Entities;

namespace ciberforo.Dtos;

public record class CommentDto(
    int Id,
    
    [Required]
    string Content,
    
    bool IsDeleted,
    
    DateTime CreatedAt,
    
    DateTime UpdatedAt,
    
    int UserId,
    UserDto? Userdto,
    
    int TopicId,
    TopicDto? TopicDto
);
