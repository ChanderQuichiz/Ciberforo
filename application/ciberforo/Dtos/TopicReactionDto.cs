using System.ComponentModel.DataAnnotations;
using ciberforo.Entities;

namespace ciberforo.Dtos;

 public record class TopicReactionDto
(
      int Id ,
        
        [Required]
         enums.ReactionType ReactionType ,
        
        [Required]
         DateTime CreatedAt ,

        [Required]
         int UserId ,
         UserDto? Userdto ,
        
        [Required]
         int TopicId ,
         TopicDto? TopicDto
);
