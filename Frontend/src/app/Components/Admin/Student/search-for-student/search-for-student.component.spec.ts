import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchForStudentComponent } from './search-for-student.component';

describe('SearchForStudentComponent', () => {
  let component: SearchForStudentComponent;
  let fixture: ComponentFixture<SearchForStudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchForStudentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchForStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
