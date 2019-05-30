import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LineMapComponent } from './line-map.component';

describe('LineMapComponent', () => {
  let component: LineMapComponent;
  let fixture: ComponentFixture<LineMapComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LineMapComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LineMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
