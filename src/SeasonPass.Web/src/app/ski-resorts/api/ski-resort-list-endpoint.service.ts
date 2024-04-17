import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { PagedResponse } from '@typings/common-module';
import { SkiResort, SkiResortListRequest } from '@typings/ski-resort-module';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SkiResortListEndpoint {
  private readonly http = inject(HttpClient);

  resorts(request: SkiResortListRequest): Observable<PagedResponse<SkiResort>> {
    // TODO: extract casting logic
    const params = new HttpParams({
      fromObject: request as Record<
        keyof SkiResortListRequest,
        string | number | boolean | readonly (string | number | boolean)[]
      >,
    });

    return this.http.get<PagedResponse<SkiResort>>('api/resorts', { params });
  }
}
