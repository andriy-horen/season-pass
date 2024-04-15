import { CommonModule, NgTemplateOutlet } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { SpeedDialModule } from 'primeng/speeddial';
import { ToolbarModule } from 'primeng/toolbar';

interface BottomNavItem {
  id: string;
}

class LinkItem implements BottomNavItem {
  constructor(
    readonly id: string,
    readonly icon: string,
    readonly title: string,
    readonly routerLink: string[],
  ) {}
}

class AddItem implements BottomNavItem {
  constructor(
    readonly id: string,
    readonly subItems: MenuItem[],
  ) {}
}

@Component({
  selector: 'sp-bottom-nav',
  standalone: true,
  imports: [CommonModule, ToolbarModule, ButtonModule, SpeedDialModule, NgTemplateOutlet],
  templateUrl: './bottom-nav.component.html',
  styleUrl: './bottom-nav.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class BottomNavComponent {
  isAddItemExpanded = false;

  readonly items: BottomNavItem[] = [
    new LinkItem('bottom-nav-home', 'home', 'Home', ['#']),
    new LinkItem('bottom-nav-season', 'ac_unit', 'Season', ['#']),
    new AddItem('bottom-nav-add', [{ icon: 'today' }, { icon: 'date_range' }]),
    new LinkItem('bottom-nav-resorts', 'landscape_2', 'Resorts', ['#']),
    new LinkItem('bottom-nav-you', 'downhill_skiing', 'You', ['#']),
  ];

  isLinkItem(item: BottomNavItem): item is LinkItem {
    return item instanceof LinkItem;
  }

  isAddItem(item: BottomNavItem): item is AddItem {
    return item instanceof AddItem;
  }

  // items = [
  //   {
  //     icon: 'pi pi-pencil',
  //     command: () => {},
  //   },
  //   {
  //     icon: 'pi pi-refresh',
  //     command: () => {},
  //   },
  //   {
  //     icon: 'pi pi-trash',
  //     command: () => {},
  //   },
  //   {
  //     icon: 'pi pi-upload',
  //     routerLink: ['/fileupload'],
  //   },
  //   {
  //     icon: 'pi pi-external-link',
  //     target: '_blank',
  //     url: 'http://angular.io',
  //   },
  // ];
}
