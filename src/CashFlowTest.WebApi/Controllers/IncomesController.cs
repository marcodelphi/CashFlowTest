using CashFlowTest.Command.Abstractions.Commands.IncomeCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Services.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomesController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet]
        public async Task<IncomeDto[]> Get(CancellationToken cancellationToken)
            => await _incomeService.GetAllIncomesAsync(cancellationToken);

        [HttpGet("{id}", Name = "GetIncomeLink")]
        public async Task<IncomeDto> Get(Guid id, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddIncomeCommand command, CancellationToken cancellationToken)
        {
            IncomeDto income = await _incomeService.AddAsync(command, cancellationToken);

            return CreatedAtRoute("GetIncomeLink", new { id = income.Id }, income);
        }

        [HttpPut]
        public async Task<ActionResult<IncomeDto>> Put(UpdateIncomeCommand command, CancellationToken cancellationToken)
        {
            IncomeDto income = await _incomeService.UpdateAsync(command, cancellationToken);

            if (income is null)
                return NotFound();
            return income;
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
            => await _incomeService.DeleteAsync(new DeleteIncomeCommand(id), cancellationToken);

    }
}
