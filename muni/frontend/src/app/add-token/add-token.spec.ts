import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddToken } from './add-token';

describe('AddToken', () => {
  let component: AddToken;
  let fixture: ComponentFixture<AddToken>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddToken]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddToken);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
