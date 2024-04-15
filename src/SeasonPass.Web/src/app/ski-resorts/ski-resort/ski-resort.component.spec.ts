import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SkiResortComponent } from './ski-resort.component';

describe('SkiResortComponent', () => {
  let component: SkiResortComponent;
  let fixture: ComponentFixture<SkiResortComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SkiResortComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SkiResortComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
