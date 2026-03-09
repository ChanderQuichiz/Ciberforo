using System.ComponentModel.DataAnnotations;
using ciberforo.enums;

namespace ciberforo.Dtos;

 public record class TopicReactionCreateDto
(
  int Id ,
        
        [Required]
         ReactionType ReactionType ,
        
        [Required]
         int UserId ,
        
        [Required]
         int TopicId 
);