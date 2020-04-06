import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CopagoRegistroComponent } from './copago-registro.component';

describe('CopagoRegistroComponent', () => {
  let component: CopagoRegistroComponent;
  let fixture: ComponentFixture<CopagoRegistroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CopagoRegistroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CopagoRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
