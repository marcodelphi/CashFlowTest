import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AddExpenseCommand } from 'src/app/commands/expense/add-expense.command';
import { BaseAddDialogComponent } from 'src/app/components/base-add-dialog/base-add-dialog.component';
import { FormFieldsLengthConstants } from 'src/app/crosscutting/constants/form-fields-lengh.constants';
import { Expense } from 'src/app/models/expense/expense.model';
import { ExpenseCategoryService } from '../../services/expense-category.service';
import { ExpensesService } from '../../services/expenses.service';

export interface FormAddExpense {
  description: FormControl<string | null>;
  value: FormControl<number | null>;
  expenseDate: FormControl<Date | null>;
  expenseCategoryId: FormControl<string | null>;
}

const DESCRIPTION_MIN_LENGTH = 10;

@Component({
  selector: 'app-expense-add',
  templateUrl: './expense-add.component.html',
  styleUrls: ['./expense-add.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExpenseAddComponent extends BaseAddDialogComponent<Expense, AddExpenseCommand, FormAddExpense> implements OnInit {
  constructor(
    protected override readonly fb: FormBuilder,
    protected override readonly service: ExpensesService,
    public readonly expenseCategoryService: ExpenseCategoryService
  ) {
    super(fb, service);
  }

  public ngOnInit(): void {
    this.expenseCategoryService.loadExpenseCategories();
  }

  protected override createForm(): FormGroup<FormAddExpense> {
    return this.fb.group<FormAddExpense>({
      description: new FormControl('', [Validators.required, Validators.minLength(DESCRIPTION_MIN_LENGTH), Validators.maxLength(FormFieldsLengthConstants.EXPENSE_CATEGORY_DESCRIPTION_MAX_LENGTH)]),
      value: new FormControl(0, [Validators.required, Validators.min(0.1)]),
      expenseDate: new FormControl(new Date(), [Validators.required]),
      expenseCategoryId: new FormControl('', Validators.required)
    });
  }

  public getErrorDescription(): string {
    return this.form.controls['description'].hasError('required') ? 'Favor adicionar uma descri????o v??lida' :
      this.form.controls['description'].hasError('minlength') ? `Descri????o muito pequena. Minima permitida: ${DESCRIPTION_MIN_LENGTH} caracteres` :
        this.form.controls['description'].hasError('maxlength') ? `Descri????o muito grande. M??xima permitida: ${FormFieldsLengthConstants.EXPENSE_CATEGORY_DESCRIPTION_MAX_LENGTH} caracteres` : '';
  }

}
