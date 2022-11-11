import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CoreFunctions } from '../crosscutting/core-functions';
import { IncomesService } from './services/incomes.service';

@Component({
  selector: 'app-incomes',
  templateUrl: './incomes.component.html',
  styleUrls: ['./incomes.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class IncomesComponent implements OnInit {
  public notImplemented = CoreFunctions.notImplemented;

  public displayedColumns: string[] = ['createdDate', 'incomeDate', 'description', 'note', 'value', 'actions'];

  constructor(public readonly incomeService: IncomesService) { }

  public ngOnInit(): void {
    this.incomeService.getAll();
  }
}
