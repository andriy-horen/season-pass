import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SkiResortListComponent } from './ski-resort-list.component';

describe('SkiResortListComponent', () => {
  let component: SkiResortListComponent;
  let fixture: ComponentFixture<SkiResortListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SkiResortListComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SkiResortListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
