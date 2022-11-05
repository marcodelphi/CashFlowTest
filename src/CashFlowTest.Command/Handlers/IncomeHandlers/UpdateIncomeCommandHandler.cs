﻿using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.IncomeCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Crosscutting.Constants;
using CashFlowTest.Domain.Model.Entities;
using FluentValidation;

namespace CashFlowTest.Command.Handlers.IncomeHandlers;

internal sealed class UpdateIncomeCommandHandler : EntityValidationCommandHandler<UpdateIncomeCommand, Income>
{
    private readonly IIncomeRepository _repository;

    public UpdateIncomeCommandHandler(IIncomeRepository respository)
    {
        _repository = respository;
    }

    protected override async Task<Income> HandleValidatedCommandAsync(UpdateIncomeCommand command, CancellationToken cancellationToken)
        => await _repository.UpdateAsync(command.Id, command.Description, command.Note, command.Value, command.IncomeDate, cancellationToken);

    protected override void SetupRules()
    {
        RuleFor(command => command.Description)
            .NotEmpty()
            .MaximumLength(DatabaseFieldsLengthConstants.INCOME_DESCRIPTION_MAX_LENGTH);

        RuleFor(command => command.Value)
            .GreaterThan(0);
    }
}
