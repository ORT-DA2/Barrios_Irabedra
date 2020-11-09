import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CategoryReadModel } from '../models/readModels/category-read-model'; 
import { HttpParams, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map, min, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  public loadedCategories : CategoryReadModel[] = [];
  private uri = environment.URI_BASE+'/categories';

  constructor(private http: HttpClient) { }

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

}
