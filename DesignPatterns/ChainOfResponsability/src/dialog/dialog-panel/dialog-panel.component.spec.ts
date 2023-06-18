import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogPanelComponent } from './dialog-panel.component';

describe('DialogPanelComponent', () => {
  let component: DialogPanelComponent;
  let fixture: ComponentFixture<DialogPanelComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DialogPanelComponent]
    });
    fixture = TestBed.createComponent(DialogPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
