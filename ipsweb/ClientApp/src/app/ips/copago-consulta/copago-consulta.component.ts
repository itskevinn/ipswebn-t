import { Component, OnInit } from '@angular/core';
import { Copago } from '../models/copago';
import { CopagoService } from 'src/app/services/copago.service';

@Component({
  selector: 'app-copago-consulta',
  templateUrl: './copago-consulta.component.html',
  styleUrls: ['./copago-consulta.component.css']
})
export class CopagoConsultaComponent implements OnInit {
  copagos: Copago[];
  copago : Copago;
  idABuscar: string;
  constructor(private copagoService: CopagoService) { }

  ngOnInit(): void {
    this.copagoService.gets().subscribe(result => {
      this.copagos = result;
    })
  }
  buscarCopago() {
    this.copagoService.get(this.idABuscar).subscribe(resultado => {
      this.copago = resultado;
    })
  }

}
