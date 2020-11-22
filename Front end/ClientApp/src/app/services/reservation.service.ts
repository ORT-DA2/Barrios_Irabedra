import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { isExpressionWithTypeArguments } from 'typescript';
import { ReservationReadModel } from '../models/readModels/reservation-read-model';
import { ReservationWriteModel } from '../models/writeModels/reservation-write-model';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  private uri = environment.URI_BASE+'/reservations';
  public token : string;
  public returned : ReservationReadModel = new ReservationReadModel;

  constructor(private http: HttpClient) { 
  }

  createReservation(reservation:ReservationWriteModel) : Observable<number>{
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    return this.http.post<number>(this.uri, reservation,{ headers : headers /*, responseType : 'text' as 'json'*/}).pipe(
      map((res:number) => {
        console.log(res);
        let numero : number = res;
        console.log(numero);
        this.http.get<ReservationReadModel>(this.uri + '/' + res).subscribe(ret => {
        this.returned.actualReservationStatus = ret.actualReservationStatus;
        this.returned.informativeText = ret.informativeText;
        this.returned.newStatusDescription = ret.newStatusDescription;
        this.returned.phoneNumber = ret.phoneNumber;
      });
        return res;
      }),
      catchError(err => {
        return throwError(err);
      })
    )
  }

  get(code:number):Observable<any>{
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    return this.http.get<ReservationReadModel>(this.uri+ '/' + code, options).pipe(
      res => {
        return res;
      },
      catchError(err => {
        return throwError(err);
      })
    )
  }
}
