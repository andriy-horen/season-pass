import { TestBed } from '@angular/core/testing';

import { SkiResortListEndpoint } from './list-all-endpoint.service';

describe('SkiResortListEndpoint', () => {
  let service: SkiResortListEndpoint;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SkiResortListEndpoint);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
