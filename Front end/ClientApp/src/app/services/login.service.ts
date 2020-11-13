import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private uri = environment.URI_BASE+'/sessions';
  public token : string;

  constructor(private http: HttpClient) { 

  }


  login(email:string, password:string){
    let headers = new HttpHeaders();
    headers = headers.set('email', email).set('password',password);
    this.http.get(this.uri, {headers : headers}).subscribe(((response: {message:string})=> {
      this.token=response.message;
      console.log(response.message);
      if(this.token === 'admin'){
        sessionStorage.setItem(this.token, email);
      }
    }))
  }


  //*******************************************************VER HTTP HEADERS******************/
  register(email:string, password:string){
    this.http.post(this.uri, {email, password}).subscribe(responseData => {
      console.log(responseData);
    })
  }
}
