import { Command } from "../command.model";

export interface AddIncomeCommand extends Command {
  description: string | null;
  note: string | null;
  value: number | null;
  incomeDate: Date | null;
}