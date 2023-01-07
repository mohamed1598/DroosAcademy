import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminStudentHomeComponent } from './admin-student-home.component';

describe('AdminStudentHomeComponent', () => {
  let component: AdminStudentHomeComponent;
  let fixture: ComponentFixture<AdminStudentHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminStudentHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminStudentHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
