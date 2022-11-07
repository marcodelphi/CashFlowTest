import { HttpClient } from "@angular/common/http";
import { Directive } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Command } from "../../commands/command.model";
import { ObservablesHelper } from "../../crosscutting/helpers/observables.helper";
import { Entity } from "../../models/entity.model";

@Directive()
export abstract class BaseCrudService<TEntity extends Entity, TAddCommand extends Command> {
  private readonly apiUrl: string;
  private readonly dataSubject$: BehaviorSubject<TEntity[]>;
  public readonly data$: Observable<TEntity[]>;

  public get data(): TEntity[] {
    return this.dataSubject$.value;
  }

  constructor(
    protected readonly controllerUrl: string,
    protected readonly http: HttpClient
  ) {
    this.apiUrl = `${environment.api}/${this.controllerUrl}`;
    [this.dataSubject$, this.data$] = ObservablesHelper.createBehaviorStreams<TEntity[]>([]);
  }

  protected abstract openAddDialog(): void;

  public getAll(): void {
    this.http.get<TEntity[]>(this.apiUrl).subscribe({
      next: (response) => {
        this.dataSubject$.next(response);
      }
    })
  }

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