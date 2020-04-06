import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from './@base/handle-http-error.service';
import { Copago } from '../ips/models/copago'
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CopagoService {
  baseUrl: string;

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  post(copago: Copago): Observable<Copago> {
    return this.http.post<Copago>(this.baseUrl + 'api/Copago', copago)
      .pipe(
        tap(_ => this.handleErrorService.log('Datos enviados al BackEnd')),
        catchError(this.handleErrorService.handleError<Copago>('Registrar Copago', null)),
      )
  }
  get(): Observable<Copago[]> {
    return this.http.get<Copago[]>(this.baseUrl + 'api/Copago')
      .pipe(
        tap(_ => this.handleErrorService.log('Datos traídos del BackEnd')),
        catchError(this.handleErrorService.handleError<Copago[]>('Consultar Copago', null)),
      )
  }
}
