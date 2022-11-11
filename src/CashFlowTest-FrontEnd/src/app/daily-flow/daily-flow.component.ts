import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { DailyFlowService } from './services/daily-flow.service';

@Component({
  selector: 'app-daily-flow',
  templateUrl: './daily-flow.component.html',
  styleUrls: ['./daily-flow.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DailyFlowComponent implements OnInit {
  public displayedColumns: string[] = ['date', 'totalExpense', 'totalIncome', 'balance'];

  constructor(public readonly service: DailyFlowService) { }

  public ngOnInit() {
    this.service.getAll();
  }
}
