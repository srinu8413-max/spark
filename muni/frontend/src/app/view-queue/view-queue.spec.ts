import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewQueue } from './view-queue';

describe('ViewQueue', () => {
  let component: ViewQueue;
  let fixture: ComponentFixture<ViewQueue>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewQueue]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewQueue);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
