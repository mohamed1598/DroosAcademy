import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LectureExamComponent } from './lecture-exam.component';

describe('LectureExamComponent', () => {
  let component: LectureExamComponent;
  let fixture: ComponentFixture<LectureExamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LectureExamComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LectureExamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
