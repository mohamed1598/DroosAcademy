import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentRightComponent } from './student-right.component';

describe('StudentRightComponent', () => {
  let component: StudentRightComponent;
  let fixture: ComponentFixture<StudentRightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentRightComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentRightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
