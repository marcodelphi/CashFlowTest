import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ObservablesHelper } from 'src/app/crosscutting/helpers/observables.helper';
import { ExpenseCategory } from 'src/app/models/expense-category/expense.category.model';
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ExpenseCategoryService {
  private readonly expenseCategoriesSubject$: BehaviorSubject<ExpenseCategory[]>;
  public readonly expenseCategories$: Observable<ExpenseCategory[]>;

  constructor(private readonly http: HttpClient) {
    [this.expenseCategoriesSubject$, this.expenseCategories$] = ObservablesHelper.createBehaviorStreams<ExpenseCategory[]>([]);
  }

  public loadExpenseCategories(): void {
    this.http.get<ExpenseCategory[]>(`${environment.api}/ExpenseCategories`).subscribe({
      next: (response) => {
        this.expenseCategoriesSubject$.next(response);
      }
    });
  }

}
