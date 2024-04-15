import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { SkiResort } from '@typings/ski-resort-module';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SkiResortListEndpoint {
  private readonly http = inject(HttpClient);

  resorts(): Observable<SkiResort[]> {
    return this.http.get<SkiResort[]>('api/resorts');
  }
}
