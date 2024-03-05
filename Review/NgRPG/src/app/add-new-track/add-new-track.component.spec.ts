import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewTrackComponent } from './add-new-track.component';

describe('AddNewTrackComponent', () => {
  let component: AddNewTrackComponent;
  let fixture: ComponentFixture<AddNewTrackComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddNewTrackComponent]
    });
    fixture = TestBed.createComponent(AddNewTrackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
