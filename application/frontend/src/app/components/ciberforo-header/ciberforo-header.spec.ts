import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CiberforoHeader } from './ciberforo-header';

describe('CiberforoHeader', () => {
  let component: CiberforoHeader;
  let fixture: ComponentFixture<CiberforoHeader>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CiberforoHeader]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CiberforoHeader);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
