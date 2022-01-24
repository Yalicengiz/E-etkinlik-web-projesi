import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivityTypeUpdateComponent } from './activityType-update.component';

describe('ActivityTypeUpdateComponent', () => {
  let component: ActivityTypeUpdateComponent;
  let fixture: ComponentFixture<ActivityTypeUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActivityTypeUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActivityTypeUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
