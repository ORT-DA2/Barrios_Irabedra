import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';


import { HttpParams, HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, Subject, throwError } from 'rxjs';
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



 get(regionName:string, categoryNames:string[]){
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

  this.http
  .get(this.uri, {params})
  .pipe(
    map((responseData : TouristSpotReadModel[]) => {
      const touristSpotsArray: TouristSpotReadModel[] = []; 
      this.loadedTouristSpots = [];
      for(let i = 0; i < responseData.length; i++){
        this.loadedTouristSpots.push(responseData[i]);
        touristSpotsArray.push(responseData[i]);
      }
      return touristSpotsArray;
    })
  ).subscribe(touristSpots => {}, error => {console.log(this.handleError(error));
    this.error.next(error)})
}

  getAll() {
    this.http
    .get(this.uri + '?category=all') //lo podriamos sacar porque si no recibe args automaticamente recibe /?category=all
    //lograr pasar params a la query
    //para poder efectivamente cumplir con el ReqFun
    //empezar a ver formularios tambien para hacer el POST
    .pipe(
      map((responseData : TouristSpotReadModel[]) => {
        const touristSpotsArray: TouristSpotReadModel[] = []; 
        this.loadedTouristSpots = [];
        for(let i = 0; i < responseData.length; i++){
          this.loadedTouristSpots.push(responseData[i]);
          touristSpotsArray.push(responseData[i]);
        }
        return touristSpotsArray;
      })
    ).subscribe(touristSpots => {}, error => {console.log(this.handleError(error))})
  }

    register (ts: TouristSpotWriteModel) {
    this.http.post(this.uri, ts).subscribe(responseData => {console.log(responseData)}, error => {
    this.error.next(error.message)})
  }
  

  update(ts: TouristSpotWriteModel)
  {    
    console.log("entre 2");
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    this.http.put(environment.URI_BASE + '/regions', {TouristSpotName: ts.name, RegionName : ts.regionName}, options).subscribe();
  }
  /*----------------------HAY QUE VER ESTO MAS ADELANTE----------------*/
  /***********************
   * *****************************
   * ******************************************
   * *************************************************
   * ************************************************************
   * ********************************************************************
   * ****************************************************************************
   * *********************************************************************************
   * ********************************************************************************************
   */

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
