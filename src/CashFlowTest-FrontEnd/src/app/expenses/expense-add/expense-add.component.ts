import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AddExpenseCommand } from 'src/app/commands/expense/add-expense.command';
import { ExpenseCategoryService } from '../services/expense-category.service';
import { ExpensesService } from '../services/expenses.service';

export interface FormAddExpense {
  description: FormControl<string | null>;
  value: FormControl<number | null>;
  expenseDate: FormControl<Date | null>;
  expenseCategoryId: FormControl<string | null>;
}

const DESCRIPTION_MIN_LENGTH = 10;
const DESCRIPTION_MAX_LENGTH = 200;

@Component({
  selector: 'app-expense-add',
  templateUrl: './expense-add.component.html',
  styleUrls: ['./expense-add.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExpenseAddComponent implements OnInit {
  public form: FormGroup<FormAddExpense>;

  constructor(
    private readonly fb: FormBuilder,
    private readonly expensesService: ExpensesService,
    public readonly expenseCategoryService: ExpenseCategoryService
  ) {
    this.form = this.createForm();
  }

  public ngOnInit(): void {
    this.expenseCategoryService.loadExpenseCategories();
  }

  private createForm(): FormGroup {
    return this.fb.group<FormAddExpense>({
      description: new FormControl('', [Validators.required, Validators.minLength(DESCRIPTION_MIN_LENGTH), Validators.maxLength(DESCRIPTION_MAX_LENGTH)]),
      value: new FormControl(0, [Validators.required, Validators.min(0.1)]),
      expenseDate: new FormControl(new Date(), [Validators.required]),
      expenseCategoryId: new FormControl('', Validators.required)
    });
  }

  public getErrorDescription(): string {
    return this.form.controls['description'].hasError('required') ? 'Favor adicionar uma descrição válida' :
      this.form.controls['description'].hasError('minlength') ? `Descrição muito pequena. Minima permitida: ${DESCRIPTION_MIN_LENGTH} caracteres` :
        this.form.controls['description'].hasError('maxlength') ? `Descrição muito grande. Máxima permitida: ${DESCRIPTION_MAX_LENGTH} caracteres` : '';
  }

  public onSubmit(expenseCommand: Partial<AddExpenseCommand>): void {
    this.expensesService.addExpense(expenseCommand, (expense) => {
      console.log(expense);
    });
  }
}
