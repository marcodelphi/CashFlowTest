import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { take } from 'rxjs';
import { ExpenseAddComponent } from '../expense-add/expense-add.component';

@Injectable({
  providedIn: 'root'
})
export class ExpensesService {
  constructor(private readonly dialog: MatDialog) {

  }

  public openAddExpenseDialog(): void {
    const dialogRef = this.dialog.open(ExpenseAddComponent);

    dialogRef.afterClosed().pipe(take(1)).subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

}
