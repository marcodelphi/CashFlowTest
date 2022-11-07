import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { take } from 'rxjs';
import { AddExpenseCommand } from 'src/app/commands/expense/add-expense.command';
import { Expense } from 'src/app/models/expense/expense.model';
import { BaseCrudService } from 'src/app/services/core/base-crud.service';
import { ExpenseAddComponent } from '../expense-add/expense-add.component';

@Injectable({
  providedIn: 'root'
})
export class ExpensesService extends BaseCrudService<Expense, AddExpenseCommand> {
  constructor(
    private readonly dialog: MatDialog,
    protected override readonly http: HttpClient
  ) {
    super('Expenses', http);
  }

  public openAddDialog(): void {
    const dialogRef = this.dialog.open(ExpenseAddComponent);

    dialogRef.afterClosed().pipe(take(1)).subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  public getTotalExpenses(): number {
    return this.data.map(expense => expense.value).reduce((acc, value) => acc + value, 0);
  }
}
