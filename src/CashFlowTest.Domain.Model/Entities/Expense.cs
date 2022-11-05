﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlowTest.Domain.Model.Entities;

public sealed class Expense: BaseEntity, IAggregateRoot<Expense>
{
    public string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ExpenseDate { get; set; }
    public Guid ExpenseCategoryId { get; set; }

    [ForeignKey("ExpenseCategoryId")]
    public ExpenseCategory ExpenseCategory { get; set; }
}
