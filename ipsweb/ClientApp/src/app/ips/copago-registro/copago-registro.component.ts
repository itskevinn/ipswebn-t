import { Component, OnInit } from '@angular/core';
import { Copago } from '../models/copago';
import { CopagoService } from '../../services/copago.service';

@Component({
  selector: 'app-copago-registro',
  templateUrl: './copago-registro.component.html',
  styleUrls: ['./copago-registro.component.css']
})
export class CopagoRegistroComponent implements OnInit {
  copago: Copago;
  idABuscar: string;
  constructor(private copagoService: CopagoService) { }

  ngOnInit(): void {
    this.copago = new Copago();
  }
  buscarCopago() {
    this.copagoService.get(this.idABuscar).subscribe(resultado => {
      this.copago = resultado;
    })
    return this.copago;
  }
  registrarCopago() {
    this.copagoService.post(this.copago).subscribe(p => {
      if (this.buscarCopago() == null) {

        if (p != null) {
          alert("Copago registrado exitosamente!");
          this.copago = p;
        }
      }
      else {
        alert("Persona ya registrada");
      }
    });
  }
}

