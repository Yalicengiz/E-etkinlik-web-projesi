import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IsFreeAddComponent } from './isFree-add.component';

describe('IsFreeAddComponent', () => {
  let component: IsFreeAddComponent;
  let fixture: ComponentFixture<IsFreeAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IsFreeAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IsFreeAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
