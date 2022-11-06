import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { take } from 'rxjs';
import { AddExpenseCommand } from 'src/app/commands/expense/add-expense.command';
import { Expense } from 'src/app/models/expense/expense.model';
import { environment } from 'src/environments/environment';
import { ExpenseAddComponent } from '../expense-add/expense-add.component';

@Injectable({
  providedIn: 'root'
})
export class ExpensesService {
  constructor(
    private readonly dialog: MatDialog,
    private readonly http: HttpClient) {
  }

  public openAddExpenseDialog(): void {
    const dialogRef = this.dialog.open(ExpenseAddComponent);

    dialogRef.afterClosed().pipe(take(1)).subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  public addExpense(expense: Partial<AddExpenseCommand>, addedCallback: (expense: Expense) => void): void {
    this.http.post<Expense>(`${environment.api}/Expenses`, expense).subscribe({
      next: (response) => {
        addedCallback(response);
      }
    })
  }

}
