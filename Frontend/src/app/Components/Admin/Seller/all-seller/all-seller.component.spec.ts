import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllSellerComponent } from './all-seller.component';

describe('AllSellerComponent', () => {
  let component: AllSellerComponent;
  let fixture: ComponentFixture<AllSellerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllSellerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllSellerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
