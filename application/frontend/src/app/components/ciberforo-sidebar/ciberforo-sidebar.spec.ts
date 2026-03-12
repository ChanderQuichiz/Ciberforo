import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CiberforoSidebar } from './ciberforo-sidebar';

describe('CiberforoSidebar', () => {
  let component: CiberforoSidebar;
  let fixture: ComponentFixture<CiberforoSidebar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CiberforoSidebar]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CiberforoSidebar);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
