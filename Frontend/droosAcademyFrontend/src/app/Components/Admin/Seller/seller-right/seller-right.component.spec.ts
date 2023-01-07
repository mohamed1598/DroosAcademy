import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SellerRightComponent } from './seller-right.component';

describe('SellerRightComponent', () => {
  let component: SellerRightComponent;
  let fixture: ComponentFixture<SellerRightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SellerRightComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SellerRightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
