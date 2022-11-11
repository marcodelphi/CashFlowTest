import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MaterialModule } from '../material.module';
import { DailyFlowComponent } from './daily-flow.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule
  ],
  declarations: [DailyFlowComponent],
  exports: [DailyFlowComponent]
})
export class DailyFlowModule { }
