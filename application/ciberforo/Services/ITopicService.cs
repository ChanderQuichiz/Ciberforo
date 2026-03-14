using ciberforo.Dtos;

namespace ciberforo.Services;

public interface ITopicService
{
    Task<TopicDto> Create(TopicCreateDto dto);
    Task<TopicDto?> FindById(int id);
    Task<TopicDto?> Update(TopicUpdateDto dto);
    Task<bool> Delete(int id);
    Task<List<TopicDto>> findByTitleContaining(string title);
}
