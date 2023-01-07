import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentTeachersComponent } from './student-teachers.component';

describe('StudentTeachersComponent', () => {
  let component: StudentTeachersComponent;
  let fixture: ComponentFixture<StudentTeachersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentTeachersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentTeachersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
