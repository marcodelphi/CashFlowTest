import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BehaviorSubject, Observable, take } from 'rxjs';
import { AddExpenseCommand } from 'src/app/commands/expense/add-expense.command';
import { ObservablesHelper } from 'src/app/crosscutting/helpers/observables.helper';
import { Expense } from 'src/app/models/expense/expense.model';
import { environment } from 'src/environments/environment';
import { ExpenseAddComponent } from '../expense-add/expense-add.component';

@Injectable({
  providedIn: 'root'
})
export class ExpensesService {
  private readonly expensesSubject$: BehaviorSubject<Expense[]>;
  public readonly expenses$: Observable<Expense[]>;

  public get expenses(): Expense[] {
    return this.expensesSubject$.value;
  }

  constructor(
    private readonly dialog: MatDialog,
    private readonly http: HttpClient
  ) {
    [this.expensesSubject$, this.expenses$] = ObservablesHelper.createBehaviorStreams<Expense[]>([]);
  }

  public openAddExpenseDialog(): void {
    const dialogRef = this.dialog.open(ExpenseAddComponent);

    dialogRef.afterClosed().pipe(take(1)).subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  public getAllExpenses(): void {
    this.http.get<Expense[]>(`${environment.api}/Expenses`).subscribe({
      next: (response) => {
        this.expensesSubject$.next(response);
      }
    })
  }

  public addExpense(expense: Partial<AddExpenseCommand>, addedCallback: (expense: Expense) => void): void {
    this.http.post<Expense>(`${environment.api}/Expenses`, expense).subscribe({
      next: (response) => {
        this.insertExpense(response);

        addedCallback(response);
      }
    })
  }

  public deleteExpense(expense: Expense): void {
    this.http.delete(`${environment.api}/Expenses/${expense.id}`).subscribe({
      next: (response) => {
        debugger;
        this.removeExpense(expense);
      }
    });
  }

  public getTotalExpenses(): number {
    return this.expenses.map(expense => expense.value).reduce((acc, value) => acc + value, 0);
  }

  private insertExpense(expense: Expense): void {
    this.expensesSubject$.next([...this.expenses, expense]);
  }

  private removeExpense(expense: Expense) {
    this.expensesSubject$.next([...this.expenses.filter(x => x.id !== expense.id)]);
  }
}
