import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MaterialModule } from '../material.module';
import { IncomesComponent } from './incomes.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule
  ],
  declarations: [IncomesComponent],
  exports: [IncomesComponent]
})
export class IncomesModule { }
