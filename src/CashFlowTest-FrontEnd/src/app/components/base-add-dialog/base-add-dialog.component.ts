import { Directive } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';
import { Command } from 'src/app/commands/command.model';
import { Entity } from 'src/app/models/entity.model';
import { BaseCrudService } from 'src/app/services/core/base-crud.service';

@Directive()
export abstract class BaseAddDialogComponent<TEntity extends Entity, TAddCommand extends Command, TForm extends { [K in keyof TForm]: AbstractControl<any>; } = any> {
  public form: FormGroup<TForm>;

  constructor(
    protected readonly fb: FormBuilder,
    protected readonly service: BaseCrudService<TEntity, TAddCommand>
  ) {
    this.form = this.createForm();
  }

  protected abstract createForm(): FormGroup<TForm>;

  public onSubmit(addCommand: Partial<TAddCommand>): void {
    this.service.addData(addCommand, (data) => {
      console.log(data);
    });
  }
}
