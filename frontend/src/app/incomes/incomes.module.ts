import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MaterialModule } from '../material.module';
import { IncomeAddModule } from './components/income-add/income-add.module';
import { IncomesComponent } from './incomes.component';

@NgModule({
  imports: [
    CommonModule,
    IncomeAddModule,
    MaterialModule
  ],
  declarations: [IncomesComponent],
  exports: [IncomesComponent]
})
export class IncomesModule { }
