import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TouristSpotQueryComponent } from './tourist-spot-query.component';

describe('TouristSpotQueryComponent', () => {
  let component: TouristSpotQueryComponent;
  let fixture: ComponentFixture<TouristSpotQueryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TouristSpotQueryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TouristSpotQueryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
