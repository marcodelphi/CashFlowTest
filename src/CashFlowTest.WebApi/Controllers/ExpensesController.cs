using CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Services.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<ExpenseDto[]> Get(CancellationToken cancellationToken)
            => await _expenseService.GetAllExpensesAsync(cancellationToken);

        [HttpGet("{id}", Name = "GetExpenseLink")]
        public async Task<ExpenseDto> Get(Guid id, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddExpenseCommand command, CancellationToken cancellationToken)
        {
            ExpenseDto expense = await _expenseService.AddAsync(command, cancellationToken);

            return CreatedAtRoute("GetExpenseLink", new { id = expense.Id }, expense);
        }

        [HttpPut]
        public async Task<ActionResult<ExpenseDto>> Put(UpdateExpenseCommand command, CancellationToken cancellationToken)
        {
            ExpenseDto expense = await _expenseService.UpdateAsync(command, cancellationToken);

            if (expense is null)
                return NotFound();
            return expense;
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
            => await _expenseService.DeleteAsync(new DeleteExpenseCommand(id), cancellationToken);

    }
}
