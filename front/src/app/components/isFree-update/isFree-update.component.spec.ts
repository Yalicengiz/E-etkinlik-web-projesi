import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IsFreeUpdateComponent } from './isFree-update.component';

describe('IsFreeUpdateComponent', () => {
  let component: IsFreeUpdateComponent;
  let fixture: ComponentFixture<IsFreeUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IsFreeUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IsFreeUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
