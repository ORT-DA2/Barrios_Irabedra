import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AccommodationReadModel } from '../models/readModels/accommodation-read-model';
import { AccommodationPutWriteModel } from '../models/writeModels/accommodation-put-write-model';
import { AccommodationQueryOutModel } from '../models/writeModels/accommodation-query-out-model';
import { AccommodationWriteModel } from '../models/writeModels/accommodation-write-model';

@Injectable({
  providedIn: 'root'
})
export class AccommodationService {
  public loadedAccommodations : AccommodationReadModel[] = [];
  private uri = environment.URI_BASE+'/accommodations';
  public queryResponse : AccommodationReadModel[];
  
  constructor(private http: HttpClient) { }

 

  find(name:string){
    this.getAll(); 
    for(let i = 0; i < this.loadedAccommodations.length; i++){
      if(this.loadedAccommodations[i].name === name){
        return this.loadedAccommodations[i];
      }
    }
    return null;
  }

  getForQuery(accommodation : AccommodationQueryOutModel){
    let params = new HttpParams();
    params = params.append('touristSpotName' , accommodation.TouristSpotName);
    params = params.append('checkInYear', String(accommodation.CheckInYear));
    params = params.append('checkOutYear', String(accommodation.CheckOutYear));
    params = params.append('checkInMonth', String(accommodation.CheckInMonth));
    params = params.append('checkInDay', String(accommodation.CheckInDay));
    params = params.append('checkOutMonth', String(accommodation.CheckOutMonth));
    params = params.append('checkOutDay', String(accommodation.CheckOutDay));
    params = params.append('babies', String(accommodation.Babies));
    params = params.append('retirees', String(accommodation.Retirees));
    params = params.append('kids', String(accommodation.Kids));
    params = params.append('adults', String(accommodation.Adults));
    params = params.append('totalGuests', String(accommodation.TotalGuests));
    this.http
    .get(this.uri, {params})
    .pipe(
      map((responseData : AccommodationReadModel[]) => {
        const accommodationArray: AccommodationReadModel[] = []; 
        this.queryResponse = [];
        for(let i = 0; i < responseData.length; i++){
          this.queryResponse.push(responseData[i]);
        }
        return this.queryResponse;
      })
    ).subscribe(accs => {
      console.log(this.queryResponse);
    })
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

  register(submittedObject: AccommodationWriteModel) : Observable<any> {
    console.log(submittedObject);
    return this.http.post(this.uri, submittedObject).pipe(
      res => {return res} ,
      catchError(err => {
        return throwError(err);
      })
    )
  }


  update(name:string, data:AccommodationPutWriteModel) : Observable<any>{
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
    return this.http.put(this.uri , {Name: name,  FullCapacity: capacity, Images: data.images, WantToChangeCapacity: "true"}, {headers:headers , responseType: 'text' as 'json'}).pipe(
      res => {return res} ,
      catchError(err => {
        return throwError(err);
      })
    )
  }

  delete(name:string) : Observable<any>{
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    name = name.replace(' ', '%20');
    return this.http.delete(this.uri+ '/' + name, {headers:headers , responseType: 'text' as 'json'}).pipe(
      res => {return res} ,
      catchError(err => {
        return throwError(err);
      })
    )
  }
}
