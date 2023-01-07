import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminTeacherTransactionsComponent } from './admin-teacher-transactions.component';

describe('AdminTeacherTransactionsComponent', () => {
  let component: AdminTeacherTransactionsComponent;
  let fixture: ComponentFixture<AdminTeacherTransactionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminTeacherTransactionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminTeacherTransactionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
