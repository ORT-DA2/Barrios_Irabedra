import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminDeletionComponent } from './admin-deletion.component';

describe('AdminDeletionComponent', () => {
  let component: AdminDeletionComponent;
  let fixture: ComponentFixture<AdminDeletionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminDeletionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminDeletionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
