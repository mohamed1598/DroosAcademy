import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherCodesComponent } from './teacher-codes.component';

describe('TeacherCodesComponent', () => {
  let component: TeacherCodesComponent;
  let fixture: ComponentFixture<TeacherCodesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeacherCodesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TeacherCodesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
