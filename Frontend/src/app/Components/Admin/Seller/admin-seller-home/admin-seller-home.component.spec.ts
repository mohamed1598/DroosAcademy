import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSellerHomeComponent } from './admin-seller-home.component';

describe('AdminSellerHomeComponent', () => {
  let component: AdminSellerHomeComponent;
  let fixture: ComponentFixture<AdminSellerHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminSellerHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminSellerHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
