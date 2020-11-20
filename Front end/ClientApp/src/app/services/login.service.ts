import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private uri = environment.URI_BASE+'/sessions';
  public token : string;

  constructor(private http: HttpClient) { 

  }


  login(email:string, password:string) : Observable<any>{
    let headers = new HttpHeaders();
    headers = headers.set('email', email).set('password',password);
    return this.http.get<string>(this.uri, {headers : headers,  responseType: 'text' as 'json'}).pipe(
       res => {return res},
      catchError(err => {
        return throwError(err);
      })
    )
  }


  //*******************************************************VER HTTP HEADERS******************/
  register(email:string, password:string) :Observable<any>{
    return this.http.post(this.uri, {email, password}, {responseType: 'text' as 'json'}).pipe(
      res => {return res} ,
      catchError(err => {
        return throwError(err);
      })
    )
  }
}
