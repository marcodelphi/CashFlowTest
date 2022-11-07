import { Command } from "../command.model";

export interface AddExpenseCommand extends Command {
  description: string | null;
  value: number | null;
  expenseDate: Date | null;
  expenseCategoryId: string | null;
}