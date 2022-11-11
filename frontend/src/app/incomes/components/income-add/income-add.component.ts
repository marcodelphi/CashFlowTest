import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AddIncomeCommand } from 'src/app/commands/income/add-income.command';
import { BaseAddDialogComponent } from 'src/app/components/base-add-dialog/base-add-dialog.component';
import { FormFieldsLengthConstants } from 'src/app/crosscutting/constants/form-fields-lengh.constants';
import { Income } from 'src/app/models/income/income.model';
import { IncomesService } from '../../services/incomes.service';

export interface FormAddIncome {
  description: FormControl<string | null>;
  note: FormControl<string | null>;
  value: FormControl<number | null>;
  incomeDate: FormControl<Date | null>;
}

const DESCRIPTION_MIN_LENGTH = 10;

@Component({
  selector: 'app-income-add',
  templateUrl: './income-add.component.html',
  styleUrls: ['./income-add.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class IncomeAddComponent extends BaseAddDialogComponent<Income, AddIncomeCommand, FormAddIncome> {
  constructor(
    protected override readonly fb: FormBuilder,
    protected override readonly service: IncomesService
  ) {
    super(fb, service);
  }

  protected override createForm(): FormGroup<FormAddIncome> {
    return this.fb.group<FormAddIncome>({
      description: new FormControl('', [Validators.required, Validators.minLength(DESCRIPTION_MIN_LENGTH), Validators.maxLength(FormFieldsLengthConstants.INCOME_DESCRIPTION_MAX_LENGTH)]),
      note: new FormControl('', [Validators.maxLength(FormFieldsLengthConstants.INCOME_NOTE_MAX_LENGTH)]),
      value: new FormControl(0, [Validators.required, Validators.min(0.1)]),
      incomeDate: new FormControl(new Date(), [Validators.required]),
    });
  }

  public getErrorDescription(): string {
    return this.form.controls['description'].hasError('required') ? 'Favor adicionar uma descrição válida' :
      this.form.controls['description'].hasError('minlength') ? `Descrição muito pequena. Minima permitida: ${DESCRIPTION_MIN_LENGTH} caracteres` :
        this.form.controls['description'].hasError('maxlength') ? `Descrição muito grande. Máxima permitida: ${FormFieldsLengthConstants.INCOME_DESCRIPTION_MAX_LENGTH} caracteres` : '';
  }
}
