using System.ComponentModel.DataAnnotations;

namespace ciberforo.Dtos;

public record class CommentUpdateDto
(
    int Id,
    [Required][StringLength(500)]
    string Content
);
