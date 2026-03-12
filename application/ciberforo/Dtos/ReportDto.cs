using System.ComponentModel.DataAnnotations;
using ciberforo.Entities;
using ciberforo.enums;

namespace ciberforo.Dtos;

public record class ReportDto(
	int Id,

	[Required]
	ReportType ReportType,

	[Required]
	[StringLength(100)]
	string Reason,

	[Required]
	ReportStatus Status,

	DateTime CreatedAt,

	int UserId,
	UserDto? User,

	int TopicId,
	TopicDto? Topic,

	int CommentId,
	CommentDto? Comment
);
