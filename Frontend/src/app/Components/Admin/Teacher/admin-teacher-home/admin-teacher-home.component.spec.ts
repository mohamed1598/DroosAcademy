import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminTeacherHomeComponent } from './admin-teacher-home.component';

describe('AdminTeacherHomeComponent', () => {
  let component: AdminTeacherHomeComponent;
  let fixture: ComponentFixture<AdminTeacherHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminTeacherHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminTeacherHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
