import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';


import { HttpParams, HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
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
  ).subscribe(touristSpots => {
    
  })
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
    ).subscribe(touristSpots => {
      
    })
  }

  post(ts: TouristSpotWriteModel){
    this.http.post(this.uri, ts).subscribe(responseData => {
      console.log(responseData);
    })
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
    let message: string;

    if(error.error instanceof ErrorEvent){
      //Error de conexion del lado del cliente

      message = "Error: do it again";
    }else{
      //El backend respondio con status code de error
      //el body de la response debe de dar mas informacion

      if(error.status == 0){
        message = "The server is shutdown";
      }else{
        //Depende de como me mande la api la response del error es lo que tengo que agarrar
        message = error.error.message;
      }
    }
    //Retornamos un Observable de tipo error para el que usa el servicio
    return throwError(message);
  }
}
