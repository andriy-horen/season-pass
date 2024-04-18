import { AsyncPipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { CardModule } from 'primeng/card';
import { map } from 'rxjs/operators';
import { SkiResortListEndpoint } from '../api/ski-resort-list-endpoint.service';

@Component({
  selector: 'sp-ski-resort-list',
  standalone: true,
  imports: [CardModule, AsyncPipe],
  templateUrl: './ski-resort-list.component.html',
  styleUrl: './ski-resort-list.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SkiResortListComponent {
  private readonly listEndpoint = inject(SkiResortListEndpoint);

  readonly resorts$ = this.listEndpoint
    .resorts({ pageSize: 50, reference: 0 })
    .pipe(map((response) => response.records));

  buildLogoUrl(logoUrl: string) {
    return `assets/resorts/logos/${logoUrl}`;
  }
}
