using System;

namespace ciberforo.Services;

public interface IReportService
{
    public Task<Dtos.ReportDto> create(Dtos.ReportCreateDto dto);
    public Task<Dtos.ReportDto?> findById(int id);
    
}
