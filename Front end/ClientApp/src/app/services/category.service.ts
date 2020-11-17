import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CategoryReadModel } from '../models/readModels/category-read-model'; 
import { HttpParams, HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, Subject, throwError } from 'rxjs';
import { catchError, map, min, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  public loadedCategories : CategoryReadModel[] = [];
  private uri = environment.URI_BASE+'/categories';
  error = new Subject<string>();

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
    this.http.post(this.uri, {Name:categoryName}, options).subscribe(responseData => {console.log(responseData)}, error => {
      console.log(this.error);
      this.error.next(error)})
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
