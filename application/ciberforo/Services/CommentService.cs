using System;
using ciberforo.Data;
using ciberforo.Dtos;
using ciberforo.Entities;
using Microsoft.EntityFrameworkCore;

namespace ciberforo.Services;

public class CommentService : ICommentService
{
    private readonly CiberforoContext context;
    
    public CommentService(CiberforoContext context)
    {
        this.context = context;
    }
    
    public async Task<bool> delete(int id)
    {
        var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (comment != null)
        {
            comment.IsDeleted = true;
            comment.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<CommentDto?> findById(int id)
    {
        var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (comment != null)
        {
            return new CommentDto(
                Id: comment.Id,
                Content: comment.Content,
                IsDeleted: comment.IsDeleted,
                CreatedAt: comment.CreatedAt,
                UpdatedAt: comment.UpdatedAt,
                UserId: comment.UserId,
                TopicId: comment.TopicId,
                Userdto: null,
                TopicDto: null
            );
        }
        return null;
    }

    public async Task<CommentDto> create(CommentCreateDto dto)
    {
        Comment entity = new()
        {
            Content = dto.Content,
            UserId = dto.UserId,
            TopicId = dto.TopicId,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await context.Comments.AddAsync(entity);
        await context.SaveChangesAsync();

        return new CommentDto(
            Id: entity.Id,
            Content: entity.Content,
            IsDeleted: entity.IsDeleted,
            CreatedAt: entity.CreatedAt,
            UpdatedAt: entity.UpdatedAt,
            UserId: entity.UserId,
            TopicId: entity.TopicId,
            Userdto: null,
            TopicDto: null
        );
    }

    public async Task<CommentDto?> update(CommentUpdateDto dto)
    {
        var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == dto.Id);
        if (comment != null)
        {
            comment.Content = dto.Content;
            comment.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            CommentDto updatedComment = new CommentDto(
                Id: comment.Id,
                Content: comment.Content,
                IsDeleted: comment.IsDeleted,
                CreatedAt: comment.CreatedAt,
                UpdatedAt: comment.UpdatedAt,
                UserId: comment.UserId,
                TopicId: comment.TopicId,
                Userdto: null,
                TopicDto: null
            );
            return updatedComment;
        }
        return null;
    }
}
