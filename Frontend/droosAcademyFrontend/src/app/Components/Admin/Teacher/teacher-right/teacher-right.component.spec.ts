import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherRightComponent } from './teacher-right.component';

describe('TeacherRightComponent', () => {
  let component: TeacherRightComponent;
  let fixture: ComponentFixture<TeacherRightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeacherRightComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TeacherRightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
