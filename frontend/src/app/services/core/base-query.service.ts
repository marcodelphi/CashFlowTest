import { HttpClient } from "@angular/common/http";
import { Directive } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { ObservablesHelper } from "../../crosscutting/helpers/observables.helper";
import { Entity } from "../../models/entity.model";


@Directive()
export abstract class BaseQueryService<TEntity extends Entity> {
  protected readonly apiUrl: string;
  protected readonly dataSubject$: BehaviorSubject<TEntity[]>;
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

  public getAll(): void {
    this.http.get<TEntity[]>(this.apiUrl).subscribe({
      next: (response) => {
        this.dataSubject$.next(response);
      }
    });
  }
}
