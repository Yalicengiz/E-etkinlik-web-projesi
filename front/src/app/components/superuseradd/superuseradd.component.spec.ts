import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuperuseraddComponent } from './superuseradd.component';

describe('SuperuseraddComponent', () => {
  let component: SuperuseraddComponent;
  let fixture: ComponentFixture<SuperuseraddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuperuseraddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SuperuseraddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
