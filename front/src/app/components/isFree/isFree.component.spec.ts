import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IsFreeComponent } from './isFree.component';

describe('IsFreeComponent', () => {
  let component: IsFreeComponent;
  let fixture: ComponentFixture<IsFreeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IsFreeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IsFreeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
