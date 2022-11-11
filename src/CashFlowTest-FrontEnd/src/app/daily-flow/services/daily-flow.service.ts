import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Summary } from 'src/app/models/daily-flow/summary.model';
import { BaseQueryService } from 'src/app/services/core/base-query.service';

@Injectable({
  providedIn: 'root'
})
export class DailyFlowService extends BaseQueryService<Summary> {
  constructor(protected override readonly http: HttpClient) {
    super('Report', http);
  }

  public getTotalExpenses(): number {
    return this.data.map(summary => summary.totalExpense).reduce((acc, value) => acc + value, 0);
  }  

  public getTotalIncomes(): number {
    return this.data.map(summary => summary.totalIncome).reduce((acc, value) => acc + value, 0);
  }  

  public getTotalBalance(): number {
    return this.data.map(summary => summary.balance).reduce((acc, value) => acc + value, 0);
  }  
}
