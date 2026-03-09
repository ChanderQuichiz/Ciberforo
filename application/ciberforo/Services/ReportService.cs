using ciberforo.Data;
using ciberforo.Dtos;
using ciberforo.Entities;
using ciberforo.enums;
using Microsoft.EntityFrameworkCore;

namespace ciberforo.Services;

public class ReportService : IReportService
{
    private readonly CiberforoContext context;

    public ReportService(CiberforoContext context)
    {
        this.context = context;
    }

    public async Task<ReportDto> create(ReportCreateDto dto)
    {
        Report entity = new()
        {
            ReportType = dto.ReportType,
            Reason = dto.Reason,
            Status = ReportStatus.PENDING,
            CreatedAt = DateTime.UtcNow,
            UserId = dto.UserId,
            TopicId = dto.TopicId,
            CommentId = dto.CommentId
        };

        await context.Reports.AddAsync(entity);
        await context.SaveChangesAsync();

        return new ReportDto(
            Id: entity.Id,
            ReportType: entity.ReportType,
            Reason: entity.Reason,
            Status: entity.Status,
            CreatedAt: entity.CreatedAt,
            UserId: entity.UserId,
            User: null,
            TopicId: entity.TopicId,
            Topic: null,
            CommentId: entity.CommentId,
            Comment: null
        );
    }

    public async Task<ReportDto?> findById(int id)
    {
        var report = await context.Reports.FirstOrDefaultAsync(r => r.Id == id);
        if (report != null)
        {
            return new ReportDto(
                Id: report.Id,
                ReportType: report.ReportType,
                Reason: report.Reason,
                Status: report.Status,
                CreatedAt: report.CreatedAt,
                UserId: report.UserId,
                User: null,
                TopicId: report.TopicId,
                Topic: null,
                CommentId: report.CommentId,
                Comment: null
            );
        }
        return null;
    }
}
