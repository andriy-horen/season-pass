import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BottomNavComponent } from './bottom-nav/bottom-nav.component';
import { MainNavComponent } from './main-nav/main-nav.component';

@Component({
  selector: 'sp-app',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterOutlet, MainNavComponent, BottomNavComponent],
})
export class AppComponent {
  constructor() {}
}
