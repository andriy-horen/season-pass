import { AsyncPipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { OperationInfo, SlopeInfo } from '@typings/ski-resort-module';
import { CardModule } from 'primeng/card';
import { ChipModule } from 'primeng/chip';
import { map } from 'rxjs/operators';
import { SkiResortListEndpoint } from '../api/ski-resort-list-endpoint.service';

@Component({
  selector: 'sp-ski-resort-list',
  standalone: true,
  imports: [CardModule, ChipModule, AsyncPipe],
  templateUrl: './ski-resort-list.component.html',
  styleUrl: './ski-resort-list.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SkiResortListComponent {
  private readonly listEndpoint = inject(SkiResortListEndpoint);

  readonly resorts$ = this.listEndpoint
    .resorts({ pageSize: 1000, reference: 0 })
    .pipe(
      map((response) =>
        response.records.map((r) => ({ ...r, name: r.name.replaceAll('/', ', ') })),
      ),
    );

  buildLogoUrl(logoUrl: string) {
    return `assets/resorts/logos/${logoUrl}`;
  }

  slopeInfo(slopes: SlopeInfo | undefined) {
    if (!slopes) {
      return null;
    }

    const beginner = slopes.blackSlopesLength ?? 0;
    const intermediate = slopes.redSlopesLength ?? 0;
    const expert = slopes.blackSlopesLength ?? 0;
    const skiroutes = slopes.skiroutesLength ?? 0;

    const total = Math.round((beginner + intermediate + expert + skiroutes) * 100) / 100;

    return {
      beginner,
      intermediate,
      expert,
      skiroutes,
      total,
    };
  }

  openHours(operationInfo: OperationInfo | undefined) {
    if (!operationInfo?.openHour || !operationInfo?.closeHour) {
      return null;
    }

    const { openHour, closeHour } = operationInfo;

    return `${openHour} - ${closeHour}`;
  }
}
