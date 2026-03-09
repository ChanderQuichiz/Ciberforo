using ciberforo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ciberforo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService reportService;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dtos.ReportDto>> GetReport(int id)
        {
            var report = await reportService.findById(id);
            return report != null ? Ok(report) : NotFound("Reporte no encontrado");
        }

        [HttpPost("create")]
        public async Task<ActionResult<Dtos.ReportDto>> create([FromBody] Dtos.ReportCreateDto dto)
        {
            var report = await reportService.create(dto);
            if (report == null)
            {
                return BadRequest("Error al crear el reporte");
            }
            return CreatedAtAction(nameof(GetReport), new { id = report.Id }, report);
        }
    }
}
