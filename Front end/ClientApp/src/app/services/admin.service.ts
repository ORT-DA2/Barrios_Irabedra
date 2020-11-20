import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AdminReadModel } from '../models/readModels/admin-read-model';
import { AdminWriteModel } from '../models/writeModels/admin-write-model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  
  public loadedAdmins : AdminReadModel[] = [];
  private uri = environment.URI_BASE+'/admins';
  

  constructor(private http: HttpClient)  { }

  public register(admin : AdminWriteModel) : Observable<any> {
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    return this.http.post<string>( this.uri, admin, {headers:headers, responseType: 'text' as 'json'}).pipe(
      res => {return res} ,
      catchError(err => {
        return throwError(err);
      })
    )
  }

  delete(email:string) : Observable<any>{
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    return this.http.delete(this.uri+'/'+email, { headers : headers,  responseType: 'text' as 'json'}).pipe(
      res => {return res} ,
      catchError(err => {
        return throwError(err);
      })
    )
  }

  update(admin:AdminWriteModel) : Observable<any>{
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    return this.http.put(this.uri+'/'+admin.Email, admin, { headers : headers,  responseType: 'text' as 'json'}).pipe(
      res => {return res} ,
      catchError(err => {
        return throwError(err);
      })
    )
  }
}
