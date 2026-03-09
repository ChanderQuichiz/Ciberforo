using System.ComponentModel.DataAnnotations;
using ciberforo.enums;

namespace ciberforo.Dtos;

public record class ReportCreateDto
(

        [Required]
         ReportType ReportType ,
        
        [Required]
        [StringLength(100)]
         string Reason ,

        [Required]
         int UserId ,

        [Required]
         int TopicId ,
        [Required]
         int CommentId 
         );
