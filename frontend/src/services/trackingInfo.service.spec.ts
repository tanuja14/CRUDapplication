/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TrackingInfoService } from './trackingInfo.service';

describe('Service: TrackingInfo', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TrackingInfoService]
    });
  });

  it('should ...', inject([TrackingInfoService], (service: TrackingInfoService) => {
    expect(service).toBeTruthy();
  }));
});
