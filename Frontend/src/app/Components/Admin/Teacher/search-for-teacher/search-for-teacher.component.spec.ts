import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchForTeacherComponent } from './search-for-teacher.component';

describe('SearchForTeacherComponent', () => {
  let component: SearchForTeacherComponent;
  let fixture: ComponentFixture<SearchForTeacherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchForTeacherComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchForTeacherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
