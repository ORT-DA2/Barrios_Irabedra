import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccommodationDeletionComponent } from './accommodation-deletion.component';

describe('AccommodationDeletionComponent', () => {
  let component: AccommodationDeletionComponent;
  let fixture: ComponentFixture<AccommodationDeletionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccommodationDeletionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AccommodationDeletionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
