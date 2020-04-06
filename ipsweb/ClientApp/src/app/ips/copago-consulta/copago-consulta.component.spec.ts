import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CopagoConsultaComponent } from './copago-consulta.component';

describe('CopagoConsultaComponent', () => {
  let component: CopagoConsultaComponent;
  let fixture: ComponentFixture<CopagoConsultaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CopagoConsultaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CopagoConsultaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
