import { ChangeDetectionStrategy, Component, Input } from '@angular/core';

interface SkiResort {
  id: number;
  name: string;
  rating?: number;
  website?: string;
  logoUrl?: string;
}

@Component({
  selector: 'sp-ski-resort',
  standalone: true,
  imports: [],
  templateUrl: './ski-resort.component.html',
  styleUrl: './ski-resort.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SkiResortComponent {
  @Input() skiResort!: SkiResort;
}
