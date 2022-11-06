import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CoreFunctions } from '../crosscutting/core-functions';
import { ExpensesService } from './services/expenses.service';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExpensesComponent implements OnInit {
  public notImplemented = CoreFunctions.notImplemented;

  public displayedColumns: string[] = ['createdDate', 'expenseDate', 'description', 'value', 'expenseCategory', 'actions'];

  constructor(public readonly expenseService: ExpensesService) { }

  public ngOnInit(): void {
    this.expenseService.getAllExpenses();
  }
}
