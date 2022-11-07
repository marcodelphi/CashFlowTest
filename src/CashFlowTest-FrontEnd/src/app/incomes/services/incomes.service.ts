import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddIncomeCommand } from 'src/app/commands/income/add-income.command';
import { Income } from 'src/app/models/income/income.model';
import { BaseCrudService } from 'src/app/services/core/base-crud.service';

@Injectable({
  providedIn: 'root'
})
export class IncomesService extends BaseCrudService<Income, AddIncomeCommand> {
  constructor(
    protected override readonly http: HttpClient
  ) {
    super('Incomes', http);
  }

  protected openAddDialog(): void {
    throw new Error('Method not implemented.');
  }
}
