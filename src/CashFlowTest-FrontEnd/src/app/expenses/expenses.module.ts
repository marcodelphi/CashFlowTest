import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExpensesComponent } from './expenses.component';
import { ExpenseAddModule } from './components/expense-add/expense-add.module';
import { MaterialModule } from '../material.module';

@NgModule({
  imports: [
    CommonModule,
    ExpenseAddModule,
    MaterialModule
  ],
  declarations: [ExpensesComponent],
  exports: [ExpensesComponent]
})
export class ExpensesModule { }
