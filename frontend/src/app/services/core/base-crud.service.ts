import { Directive } from "@angular/core";
import { Command } from "../../commands/command.model";
import { Entity } from "../../models/entity.model";
import { BaseQueryService } from "./base-query.service";

@Directive()
export abstract class BaseCrudService<TEntity extends Entity, TAddCommand extends Command> extends BaseQueryService<TEntity> {
  protected abstract openAddDialog(): void;

  public addData(data: Partial<TAddCommand>, addedCallback: (data: TEntity) => void): void {
    this.http.post<TEntity>(this.apiUrl, data).subscribe({
      next: (response) => {
        this.insertData(response);

        addedCallback(response);
      }
    })
  }

  public deleteData(data: TEntity): void {
    this.http.delete(`${this.apiUrl}/${data.id}`).subscribe({
      next: () => {
        this.removeData(data);
      }
    });
  }

  private insertData(data: TEntity): void {
    this.dataSubject$.next([...this.data, data]);
  }

  private removeData(data: TEntity) {
    this.dataSubject$.next([...this.data.filter(x => x.id !== data.id)]);
  }
}