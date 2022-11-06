import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExpenseAddComponent } from './expense-add.component';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  imports: [
    CommonModule,
    MatDialogModule
  ],
  declarations: [ExpenseAddComponent],
  exports: [ExpenseAddComponent]
})
export class ExpenseAddModule { }
