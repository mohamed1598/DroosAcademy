import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SellerTransactionComponent } from './seller-transaction.component';

describe('SellerTransactionComponent', () => {
  let component: SellerTransactionComponent;
  let fixture: ComponentFixture<SellerTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SellerTransactionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SellerTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
