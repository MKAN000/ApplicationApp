import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationTextComponent } from './application-text.component';

describe('ApplicationTextComponent', () => {
  let component: ApplicationTextComponent;
  let fixture: ComponentFixture<ApplicationTextComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ApplicationTextComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ApplicationTextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
