import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RideLocationsComponent } from './ride-locations.component';

describe('RideLocationsComponent', () => {
  let component: RideLocationsComponent;
  let fixture: ComponentFixture<RideLocationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RideLocationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RideLocationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
