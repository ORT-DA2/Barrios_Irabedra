import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AdminReadModel } from '../models/readModels/admin-read-model';
import { AdminWriteModel } from '../models/writeModels/admin-write-model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  
  public loadedAdmins : AdminReadModel[] = [];
  private uri = environment.URI_BASE+'/admins';
  

  constructor(private http: HttpClient) { }

  register(admin : AdminWriteModel){
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    this.http.post( this.uri, admin, options ).subscribe();
  }

  delete(email:string){
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    this.http.delete(this.uri+'/'+email, options).subscribe();
  }

  update(admin:AdminWriteModel){
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    this.http.put(this.uri+'/'+admin.Email, admin, options).subscribe();
  }
}
