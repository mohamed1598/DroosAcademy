import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherPaymentoperationsComponent } from './teacher-paymentoperations.component';

describe('TeacherPaymentoperationsComponent', () => {
  let component: TeacherPaymentoperationsComponent;
  let fixture: ComponentFixture<TeacherPaymentoperationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeacherPaymentoperationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TeacherPaymentoperationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
