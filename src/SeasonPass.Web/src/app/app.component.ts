import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BottomNavComponent } from './bottom-nav/bottom-nav.component';
import { MainNavComponent } from './main-nav/main-nav.component';
import { SkiResortListComponent } from './ski-resorts/ski-resort-list/ski-resort-list.component';

@Component({
  selector: 'sp-app',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterOutlet, MainNavComponent, BottomNavComponent, SkiResortListComponent],
})
export class AppComponent {
  constructor() {}
}
