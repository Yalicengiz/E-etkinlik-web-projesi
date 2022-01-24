import { TestBed } from '@angular/core/testing';

import { IsFreeService } from './isFree.service';

describe('IsFreeService', () => {
  let service: IsFreeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IsFreeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
