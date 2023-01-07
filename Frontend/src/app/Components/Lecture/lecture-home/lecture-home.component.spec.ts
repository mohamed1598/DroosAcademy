import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LectureHomeComponent } from './lecture-home.component';

describe('LectureHomeComponent', () => {
  let component: LectureHomeComponent;
  let fixture: ComponentFixture<LectureHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LectureHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LectureHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
