import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { TouristSpotReadModel } from '../models/readModels/tourist-spot-read-model';
@Injectable({
  providedIn: 'root'
})

export class TouristSpotService {

  public loadedTouristSpots : TouristSpotReadModel[] = [];
  private uri = environment.URI_BASE+"touristSpots";

  constructor(private http: HttpClient) { }

 

  getAll() {
    this.http
    .get(this.uri+"?category=all") //lo podriamos sacar porque si no recibe args automaticamente recibe /?category=all
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
