import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentBalanceComponent } from './student-balance.component';

describe('StudentBalanceComponent', () => {
  let component: StudentBalanceComponent;
  let fixture: ComponentFixture<StudentBalanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentBalanceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentBalanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
