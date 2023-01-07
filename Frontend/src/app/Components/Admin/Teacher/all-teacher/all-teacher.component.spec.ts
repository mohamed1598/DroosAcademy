import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllTeacherComponent } from './all-teacher.component';

describe('AllTeacherComponent', () => {
  let component: AllTeacherComponent;
  let fixture: ComponentFixture<AllTeacherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllTeacherComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllTeacherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
