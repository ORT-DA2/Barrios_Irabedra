import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';


import { HttpParams, HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, of, Subject, throwError } from 'rxjs';
import { catchError, map, min, tap } from 'rxjs/operators';
import { TouristSpotReadModel } from '../models/readModels/tourist-spot-read-model';
import {TouristSpotWriteModel} from '../models/writeModels/tourist-spot-write-model';
import { tokenName } from '@angular/compiler';


@Injectable({
  providedIn: 'root'
})

export class TouristSpotService {


  public loadedTouristSpots : TouristSpotReadModel[] = [];
  private uri = environment.URI_BASE+'/touristSpots';
  error = new Subject<string>();
  

  constructor(private http: HttpClient) { }



 public get  (regionName:string, categoryNames:string[]) : Observable<any> {
   let params = new HttpParams();


   if( regionName === null && !(categoryNames === null)){
    for(var i = 0; i < categoryNames.length; i++){
    params = params.append('category',  categoryNames[i]);
      if(!(i === categoryNames.length - 2)){
      }
    }
   }


   if( !(regionName === null) && (categoryNames === null)){
    params = params.append('region', regionName );
  }



  if( !(regionName === null) && !(categoryNames === null)){
    for(var i = 0; i < categoryNames.length; i++){
      params = params.append('category',  categoryNames[i] );
    }
    params = params.append('region',   regionName );
  }

  return this.http
  .get<TouristSpotReadModel[]>(this.uri, {params})
  .pipe(
    map((responseData : TouristSpotReadModel[]) => {
      const touristSpotsArray: TouristSpotReadModel[] = []; 
      this.loadedTouristSpots = [];
      for(let i = 0; i < responseData.length; i++){
        this.loadedTouristSpots.push(responseData[i]);
        touristSpotsArray.push(responseData[i]);
      }
      console.log(touristSpotsArray);
      return touristSpotsArray;
    }),
    catchError(err => {
      return throwError(err);
    })
  )
}






  getAll() : Observable<any> {
    return this.http
    .get<TouristSpotReadModel[]>(this.uri + '?category=all') 
    .pipe(
      map((responseData : TouristSpotReadModel[]) => {
        const touristSpotsArray: TouristSpotReadModel[] = []; 
        this.loadedTouristSpots = [];
        for(let i = 0; i < responseData.length; i++){
          this.loadedTouristSpots.push(responseData[i]);
          touristSpotsArray.push(responseData[i]);
        }
        return touristSpotsArray;
      }),
      catchError(err => {
        return throwError(err);
      })
    )
  }
    
  register (ts: TouristSpotWriteModel) {
    return this.http.post(this.uri, ts).pipe(
      res => {return res},
      catchError(err => {
        return throwError(err);
      })
    )
  }
  

  public update(ts: TouristSpotWriteModel)
  {    
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    return this.http.put(environment.URI_BASE + '/regions', {TouristSpotName: ts.name, RegionName : ts.regionName}, { headers : headers, responseType: 'text' as 'json'}).pipe(
      res => {return res},
      catchError(err => {
        return throwError(err);
      })
    )
  }


  private handleError(error: HttpErrorResponse){
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
    }
}
