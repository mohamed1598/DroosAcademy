import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LectureNavbarComponent } from './lecture-navbar.component';

describe('LectureNavbarComponent', () => {
  let component: LectureNavbarComponent;
  let fixture: ComponentFixture<LectureNavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LectureNavbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LectureNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
