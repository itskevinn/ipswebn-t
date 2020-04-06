import { TestBed } from '@angular/core/testing';

import { CopagoService } from './copago.service';

describe('CopagoService', () => {
  let service: CopagoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CopagoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
