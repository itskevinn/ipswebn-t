import { Component, OnInit } from '@angular/core';
import { CopagoService } from 'src/app/services/copago.service';
import { Copago } from '../models/copago';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-Copago-registro',
  templateUrl: './Copago-registro.component.html',
  styleUrls: ['./Copago-registro.component.css']
})
export class CopagoRegistroComponent implements OnInit {
  formGroup: FormGroup;
  copago: Copago;
  constructor(private copagoService: CopagoService, private formBuilder: FormBuilder) { }
  ngOnInit(): void {
    this.copago = new Copago();
    this.buildForm();
  }
  private buildForm() {
    this.copago = new Copago();
    this.copago.identificacionPaciente = "";
    this.copago.valorServicio = 0;
    this.copago.salarioTrabajador = 0;

    this.formGroup = this.formBuilder.group({
      identificacionPaciente: [this.copago.identificacionPaciente, Validators.required],
      valorServicio: [this.copago.valorServicio, [Validators.required, Validators.min(1)]],
      salarioTrabajador: [this.copago.salarioTrabajador, [Validators.required, Validators.min(1)]],
    });
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.registrar();
  }

  registrar() {
    this.copago = this.formGroup.value;
    this.copagoService.post(this.copago).subscribe(p => {
      if (p != null) {
        alert('Copago Registrado!');
        this.copago = p;
      }
    });
  }
  get control() { return this.formGroup.controls; }


}