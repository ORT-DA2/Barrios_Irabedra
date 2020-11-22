import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ReviewWriteModel } from '../models/writeModels/review-write-model';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  private uri = environment.URI_BASE+'/reviews';
  local:ReviewWriteModel[] = [];

  constructor(private http: HttpClient) { }

  get(name:string):Observable<any>{
    let headers =new HttpParams();
    headers= headers.append('name', name);
    console.log(name);
    return this.http.get<ReviewWriteModel[]>(this.uri, {params:headers}).pipe(
      map(res=>{
        if(res.length===0){
          return [];
        }
        const ret = [];
        for(let i = 0; i < res.length; i++){
          ret.push(res[i]);
        }
        return ret;
      }),
      catchError(err => {
        return throwError(err);
      })
    )
  
  }

  create(review:ReviewWriteModel){
    console.log(review);
    review.accommodationName = String(review.accommodationName);
    return this.http.post(this.uri, review).pipe(
      res => {
        return res;
      },
      catchError(err => {
        return throwError(err);
      })
    )
  }
}
