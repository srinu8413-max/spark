import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddQueue } from './add-queue';

describe('AddQueue', () => {
  let component: AddQueue;
  let fixture: ComponentFixture<AddQueue>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddQueue]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddQueue);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
