import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminStudentTransactionComponent } from './admin-student-transaction.component';

describe('AdminStudentTransactionComponent', () => {
  let component: AdminStudentTransactionComponent;
  let fixture: ComponentFixture<AdminStudentTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminStudentTransactionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminStudentTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
