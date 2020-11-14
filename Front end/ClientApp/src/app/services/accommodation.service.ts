import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AccommodationReadModel } from '../models/readModels/accommodation-read-model';
import { AccommodationWriteModel } from '../models/writeModels/accommodation-write-model';

@Injectable({
  providedIn: 'root'
})
export class AccommodationService {
  public loadedAccommodations : AccommodationReadModel[] = [];
  private uri = environment.URI_BASE+'/accommodations';
  
  constructor(private http: HttpClient) { }

  getAll() {
    this.http
    .get(this.uri, [] ,null)
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
    ).subscribe(touristSpots => {
      
    })
  }

  register(submittedObject: AccommodationWriteModel)
  {

  }


}
