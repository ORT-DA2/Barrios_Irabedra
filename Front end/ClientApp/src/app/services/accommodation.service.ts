import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AccommodationReadModel } from '../models/readModels/accommodation-read-model';
import { AccommodationPutWriteModel } from '../models/writeModels/accommodation-put-write-model';
import { AccommodationWriteModel } from '../models/writeModels/accommodation-write-model';

@Injectable({
  providedIn: 'root'
})
export class AccommodationService {
  public loadedAccommodations : AccommodationReadModel[] = [];
  private uri = environment.URI_BASE+'/accommodations';
  
  constructor(private http: HttpClient) { }

  buildQueryString(){

  }

  find(name:string){
    this.getAll(); 
    for(let i = 0; i < this.loadedAccommodations.length; i++){
      if(this.loadedAccommodations[i].name === name){
        return this.loadedAccommodations[i];
      }
    }
    return null;
  }

  getAll() {
    let params = new HttpParams();
    this.http
    .get(this.uri, {params})
    .pipe(
      map((responseData : AccommodationReadModel[]) => {
        const accommodationArray: AccommodationReadModel[] = []; 
        this.loadedAccommodations = [];
        for(let i = 0; i < responseData.length; i++){
          this.loadedAccommodations.push(responseData[i]);
          accommodationArray.push(responseData[i]);
        }
        return accommodationArray;
      })
    ).subscribe(accs => {
      
    })
  }

  register(submittedObject: AccommodationWriteModel)
  {
    console.log(submittedObject);
    this.http.post(this.uri, submittedObject).subscribe();
  }


  update(name:string, data:AccommodationPutWriteModel){
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    let capacity:string;
    console.log(data.fullCapacity);
    if(data.fullCapacity){
      capacity = "true";
    }
    else{
      capacity="false";
    }
    this.http.put(this.uri , {Name: name,  FullCapacity: capacity, Images: data.images, WantToChangeCapacity: "true"}, options).subscribe();
  }

  delete(name:string){
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    name = name.replace(' ', '%20');
    this.http.delete(this.uri+ '/' + name, options).subscribe();
  }
}
