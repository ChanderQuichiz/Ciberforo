using System.ComponentModel.DataAnnotations;

namespace ciberforo.Dtos;

public record class UserUpdateDto(
    [Required]
    int Id,
    
    [Required]
    [StringLength(50)]
    string FirstName,
    
    [Required]
    [StringLength(50)]
    string LastName,
    
    [Required]
    [StringLength(255)]
    string Password
);
