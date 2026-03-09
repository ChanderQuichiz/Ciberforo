using System.ComponentModel.DataAnnotations;

namespace ciberforo.Dtos;

public record class UserCreateDto(
    [Required]
    [StringLength(50)]
    string Username,
    
    [Required]
    [StringLength(100)]
    [EmailAddress]
    string Email,
    
    [Required]
    [StringLength(255)]
    string Password
);
