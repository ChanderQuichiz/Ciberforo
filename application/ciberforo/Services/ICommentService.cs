using System;

namespace ciberforo.Services;

public interface ICommentService
{
    public Task<Dtos.CommentDto> create(Dtos.CommentCreateDto dto);
    public Task<Dtos.CommentDto?> findById(int id);
    public Task<Dtos.CommentDto?> update(Dtos.CommentUpdateDto dto);
    public Task<bool> delete(int id);
}
