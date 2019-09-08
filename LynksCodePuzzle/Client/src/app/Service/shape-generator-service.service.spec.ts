import { TestBed } from '@angular/core/testing';

import { ShapeGeneratorServiceService } from './shape-generator-service.service';

describe('ShapeGeneratorServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ShapeGeneratorServiceService = TestBed.get(ShapeGeneratorServiceService);
    expect(service).toBeTruthy();
  });
});
