export interface AddExpenseCommand {
  description: string | null;
  value: number | null;
  expenseDate: Date | null;
  expenseCategoryId: string | null;
}