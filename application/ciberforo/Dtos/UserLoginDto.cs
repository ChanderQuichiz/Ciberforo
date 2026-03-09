using System.ComponentModel.DataAnnotations;

namespace ciberforo.Dtos;

public record class UserLoginDto
(
    [Required] [StringLength(100)] [EmailAddress] string Email ,
    [Required] [StringLength(255)] string Password
);
