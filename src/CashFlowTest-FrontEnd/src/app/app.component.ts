import { Component } from '@angular/core';
import { ExpensesService } from './expenses/services/expenses.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'CashFlowTest-FrontEnd';

  constructor(public readonly expenseService: ExpensesService) { }
}
