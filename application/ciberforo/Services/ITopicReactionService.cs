using ciberforo.Dtos;
using ciberforo.Entities;

namespace ciberforo.Services;

public interface ITopicReactionService
{
    public Task<TopicReactionDto> Create(TopicReactionCreateDto reaction);
    public Task<TopicReactionDto?> FindById(int id);
    public Task<bool> Delete(int id);
    public Task<string> toggleReaction(TopicReactionCreateDto dto);
}
