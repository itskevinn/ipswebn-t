import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CopagoRegistroComponent } from './ips/copago-registro/copago-registro.component';
import { CopagoConsultaComponent } from './ips/copago-consulta/copago-consulta.component';

const routes: Routes = [
  {
    path: 'copagoRegistro',
    component: CopagoRegistroComponent,
  },
  {
    path: 'copagoConsulta',
    component: CopagoConsultaComponent,
  }
];
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule],
})
export class AppRoutingModule { }
