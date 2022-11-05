using CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Services.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowTest.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class ExpenseCategoriesController : ControllerBase
{
    private readonly IExpenseCategoryService _expenseCategoryService;

    public ExpenseCategoriesController(IExpenseCategoryService expenseCategoryService)
    {
        _expenseCategoryService = expenseCategoryService;
    }

    [HttpGet]
    public async Task<ExpenseCategoryDto[]> Get(CancellationToken cancellationToken)
    {
        return await _expenseCategoryService.GetAllExpenseCategoriesAsync(cancellationToken);
    }


    [HttpGet("{id}", Name = "GetExpenseCategoryLink")]
    public async Task<IncomeDto> Get(Guid id, CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken);
        return null;
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddExpenseCategoryCommand command, CancellationToken cancellationToken)
    {
        ExpenseCategoryDto expenseCategory = await _expenseCategoryService.AddAsync(command, cancellationToken);

        return CreatedAtRoute("GetExpenseCategoryLink", new { id = expenseCategory.Id }, expenseCategory);
    }

    [HttpPut]
    public async Task<ActionResult<ExpenseCategoryDto>> Put(UpdateExpenseCategoryCommand command, CancellationToken cancellationToken)
    {
        ExpenseCategoryDto expenseCategory = await _expenseCategoryService.UpdateAsync(command, cancellationToken);

        if (expenseCategory is null)
            return NotFound();

        return expenseCategory;
    }

    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id, CancellationToken cancellationToken) 
        => await _expenseCategoryService.DeleteAsync(new DeleteExpenseCategoryCommand(id), cancellationToken);

}
