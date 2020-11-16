import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CategoryReadModel } from '../models/readModels/category-read-model'; 
import { HttpParams, HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map, min, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  public loadedCategories : CategoryReadModel[] = [];
  private uri = environment.URI_BASE+'/categories';

  constructor(private http: HttpClient) { }

  addCategoryToTouristSpot(touristSpotName:string, categoryName:string){
    console.log(touristSpotName);
    console.log(categoryName);
    this.http.put(this.uri, {"TouristSpotName":touristSpotName, "CategoryName":categoryName}).subscribe(responseData => {
      console.log(responseData);
    })
  }

  getAll() {
    this.http
    .get(this.uri)
    .pipe(
      map((responseData : CategoryReadModel[]) => {
        const categoriesArray: CategoryReadModel[] = []; 
        this.loadedCategories = [];
        for(let i = 0; i < responseData.length; i++){
          this.loadedCategories.push(responseData[i]);
          categoriesArray.push(responseData[i]);
        }
        this.loadedCategories = categoriesArray;
        return categoriesArray;
      })
    ).subscribe(categories => {
      
    })
  }


  register(categoryName : string){
    let headers = new HttpHeaders().append("Authorization", "admin");
    let options = { headers: headers };
    this.http.post(this.uri, {Name:categoryName}, options).subscribe();
  }
}
