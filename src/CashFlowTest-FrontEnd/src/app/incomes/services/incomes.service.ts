import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { take } from 'rxjs';
import { AddIncomeCommand } from 'src/app/commands/income/add-income.command';
import { Income } from 'src/app/models/income/income.model';
import { BaseCrudService } from 'src/app/services/core/base-crud.service';
import { IncomeAddComponent } from '../components/income-add/income-add.component';

@Injectable({
  providedIn: 'root'
})
export class IncomesService extends BaseCrudService<Income, AddIncomeCommand> {
  constructor(
    private readonly dialog: MatDialog,
    protected override readonly http: HttpClient
  ) {
    super('Incomes', http);
  }


  public openAddDialog(): void {
    const dialogRef = this.dialog.open(IncomeAddComponent);

    dialogRef.afterClosed().pipe(take(1)).subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  public getTotalIncomes(): number {
    return this.data.map(income => income.value).reduce((acc, value) => acc + value, 0);
  }
}
