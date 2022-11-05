using CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Services.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowTest.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class ExpenseCategoriesController : ControllerBase
{
    private readonly IExpenseCategoryService expenseCategoryService;

    public ExpenseCategoriesController(IExpenseCategoryService expenseCategoryService)
    {
        this.expenseCategoryService = expenseCategoryService;
    }

    [HttpGet]
    public async Task<ExpenseCategoryDto[]> Get(CancellationToken cancellationToken)
    {
        return await expenseCategoryService.GetAllExpenseCategoriesAsync(cancellationToken);
    }


    [HttpGet("{id}", Name = "ExpenseCategoryLink")]
    public async Task<ExpenseCategoryDto> Get(Guid id, CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken);
        return null;
    }

    [HttpPost]
    public async Task<IActionResult> Post(string description, CancellationToken cancellationToken)
    {
        ExpenseCategoryDto expenseCategory = await expenseCategoryService.AddExpenseCategoryAsync(new AddExpenseCategoryCommand(description), cancellationToken);

        return CreatedAtRoute("ExpenseCategoryLink", new { id = expenseCategory.Id }, expenseCategory);
    }

    [HttpPut("{id:guid}", Name = "UpdateCategoryLink")]
    public async Task<ActionResult<ExpenseCategoryDto>> Put(Guid id, string description, CancellationToken cancellationToken)
    {
        ExpenseCategoryDto expenseCategory = await expenseCategoryService.UpdateExpenseCategoryAsync(new UpdateExpenseCategoryCommand(id, description), cancellationToken);

        if (expenseCategory is null)
            return NotFound();

        return expenseCategory;
    }

    [HttpDelete("{id:guid}", Name = "DeleteCategoryLink")]
    public async Task Delete(Guid id, CancellationToken cancellationToken) 
        => await expenseCategoryService.DeleteExpenseCategoryAsync(new DeleteExpenseCategoryCommand(id), cancellationToken);

}
