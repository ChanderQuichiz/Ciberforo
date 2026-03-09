using ciberforo.Data;
using ciberforo.Dtos;
using ciberforo.Entities;
using Microsoft.EntityFrameworkCore;

namespace ciberforo.Services;

public class TopicService : ITopicService
{
    private readonly CiberforoContext context;

    public TopicService(CiberforoContext context)
    {
        this.context = context;
    }

    public async Task<TopicDto> Create(TopicCreateDto dto)
    {
        Topic entity = new()
        {
            Title = dto.Title,
            Content = dto.Content,
            UserId = dto.UserId,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await context.Topics.AddAsync(entity);
        await context.SaveChangesAsync();

        return new TopicDto(
            Id: entity.Id,
            Title: entity.Title,
            Content: entity.Content,
            IsDeleted: entity.IsDeleted,
            CreatedAt: entity.CreatedAt,
            UpdatedAt: entity.UpdatedAt,
            UserId: entity.UserId,
            Userdto: null
        );
    }

    public async Task<bool> Delete(int id)
    {
        var topic = await context.Topics.FirstOrDefaultAsync(t => t.Id == id);
        if (topic != null)
        {
            topic.IsDeleted = true;
            topic.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<TopicDto?> FindById(int id)
    {
        var topic = await context.Topics.FirstOrDefaultAsync(t => t.Id == id);
        if (topic != null)
        {
            return new TopicDto(
                Id: topic.Id,
                Title: topic.Title,
                Content: topic.Content,
                IsDeleted: topic.IsDeleted,
                CreatedAt: topic.CreatedAt,
                UpdatedAt: topic.UpdatedAt,
                UserId: topic.UserId,
                Userdto: null
            );
        }
        return null;
    }

    public async Task<TopicDto?> Update(TopicUpdateDto dto)
    {
        var topic = await context.Topics.FirstOrDefaultAsync(t => t.Id == dto.Id);
        if (topic != null)
        {
            topic.Title = dto.Title;
            topic.Content = dto.Content;
            topic.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();

            return new TopicDto(
                Id: topic.Id,
                Title: topic.Title,
                Content: topic.Content,
                IsDeleted: topic.IsDeleted,
                CreatedAt: topic.CreatedAt,
                UpdatedAt: topic.UpdatedAt,
                UserId: topic.UserId,
                Userdto: null
            );
        }
        return null;
    }
}
