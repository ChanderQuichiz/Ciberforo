using System.ComponentModel.DataAnnotations;

namespace ciberforo.Dtos;

public record class UserDto(
    int Id,
    
    [Required]
    [StringLength(50)]
    string Username,
    
    [Required]
    [StringLength(100)]
    string Email
);
