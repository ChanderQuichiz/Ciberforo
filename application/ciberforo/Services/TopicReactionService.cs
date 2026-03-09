using ciberforo.Dtos;
using ciberforo.Entities;
using Microsoft.EntityFrameworkCore;

namespace ciberforo.Services;

public class TopicReactionService : ITopicReactionService
{
    private readonly Data.CiberforoContext context;
    public TopicReactionService(Data.CiberforoContext context)
    {
        this.context = context;
    }
    public async Task<TopicReactionDto> Create(TopicReactionCreateDto reaction)
    {
        Entities.TopicReaction topicReaction = new ()
        {
            ReactionType = reaction.ReactionType,
            UserId = reaction.UserId,
            TopicId = reaction.TopicId,
            CreatedAt = DateTime.UtcNow
        };

        await context.TopicReactions.AddAsync(topicReaction);
        await context.SaveChangesAsync();

        return new TopicReactionDto(
            Id: topicReaction.Id,
            ReactionType: topicReaction.ReactionType,
            CreatedAt: topicReaction.CreatedAt,
            UserId: topicReaction.UserId,
            Userdto: null,
            TopicId: topicReaction.TopicId,
            TopicDto: null
        );
    }

    public async Task<bool> Delete(int id)
    {
        var topicReaction = await context.TopicReactions.FirstOrDefaultAsync(tr => tr.Id == id);
        if (topicReaction != null)
        {
            context.TopicReactions.Remove(topicReaction);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<TopicReactionDto?> FindById(int id)
    {
        var topicReaction = await context.TopicReactions.FirstOrDefaultAsync(tr => tr.Id == id);
        if (topicReaction != null)
        {
            return new TopicReactionDto(
                Id: topicReaction.Id,
                ReactionType: topicReaction.ReactionType,
                CreatedAt: topicReaction.CreatedAt,
                UserId: topicReaction.UserId,
                Userdto: null,
                TopicId: topicReaction.TopicId,
                TopicDto: null
            );
        }

        return null;
    }

    public async Task<string> toggleReaction(TopicReactionCreateDto dto)
    {
        
        var existReaction = await context.TopicReactions.FirstOrDefaultAsync(reaction=> reaction.UserId == dto.UserId && reaction.TopicId == dto.TopicId );
        
            if(existReaction != null )
            {
            await Delete(existReaction.Id);

            if (existReaction.ReactionType != dto.ReactionType)
            {
                await Create(dto);
                return "Reaccion actualizada";
            }
                return "Reaccion eliminada";
            }
           
        
        else
        {
          await Create(dto);
          return "Reaccion creada";
        }
    }
}
