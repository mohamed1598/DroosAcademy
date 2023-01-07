import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamquestionComponent } from './examquestion.component';

describe('ExamquestionComponent', () => {
  let component: ExamquestionComponent;
  let fixture: ComponentFixture<ExamquestionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExamquestionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExamquestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
