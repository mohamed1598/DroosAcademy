import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchForSellerComponent } from './search-for-seller.component';

describe('SearchForSellerComponent', () => {
  let component: SearchForSellerComponent;
  let fixture: ComponentFixture<SearchForSellerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchForSellerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchForSellerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
