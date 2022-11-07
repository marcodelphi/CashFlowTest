import { Command } from "../command.model";

export interface AddIncomeCommand extends Command {
  description: string;
  note: string;
  value: number;
  createdDate: string;
  incomeDate: string;
}