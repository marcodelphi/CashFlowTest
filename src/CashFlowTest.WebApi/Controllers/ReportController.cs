using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Services.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ICashFlowService _cashFlowService;

        public ReportController(ICashFlowService cashFlowService)
        {
            _cashFlowService = cashFlowService;
        }


        [HttpGet]
        public async Task<SummaryDto[]> Get(CancellationToken cancellationToken)
            => await _cashFlowService.GetDailyReportAsync(cancellationToken);
    }
}
