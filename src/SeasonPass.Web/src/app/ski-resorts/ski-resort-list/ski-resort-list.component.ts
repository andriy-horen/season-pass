import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'sp-ski-resort-list',
  standalone: true,
  imports: [],
  templateUrl: './ski-resort-list.component.html',
  styleUrl: './ski-resort-list.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SkiResortListComponent {}
