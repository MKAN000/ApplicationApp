import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoosingApplicationComponent } from './choosing-application.component';

describe('ChoosingApplicationComponent', () => {
  let component: ChoosingApplicationComponent;
  let fixture: ComponentFixture<ChoosingApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChoosingApplicationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ChoosingApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
