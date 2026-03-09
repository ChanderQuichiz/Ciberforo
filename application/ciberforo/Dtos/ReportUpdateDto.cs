using System.ComponentModel.DataAnnotations;
using ciberforo.enums;

namespace ciberforo.Dtos;

public record class ReportUpdateDto
(
        int Id,
        [Required]
         ReportType ReportType ,
        
        [Required]
        [StringLength(100)]
         string Reason ,

        // Foreign keys
         int UserId ,


         int TopicId ,

         int CommentId 
         );
