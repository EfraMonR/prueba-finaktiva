import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventlogViewerComponent } from './eventlog-viewer.component';

describe('EventlogViewerComponent', () => {
  let component: EventlogViewerComponent;
  let fixture: ComponentFixture<EventlogViewerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EventlogViewerComponent]
    });
    fixture = TestBed.createComponent(EventlogViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
