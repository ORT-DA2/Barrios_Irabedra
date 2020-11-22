import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ReportReadModel } from '../models/readModels/report-read-model';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  private uri = environment.URI_BASE+'/reports';
  lines: ReportReadModel[] = [];


  constructor(private http: HttpClient) { }

  createReport(toDate : NgbDate, fromDate : NgbDate, touristSpotName : string) : Observable<any>{
    let headers = new HttpHeaders().append("Authorization", "admin");
    let params = new HttpParams();
    params = params.append('touristSpotName', touristSpotName);
    params = params.append('endDateYear' , String(toDate.year));
    params = params.append('endDateMonth', String(toDate.month));
    params = params.append('endDateDay' , String(toDate.day));
    params = params.append('startDateYear' , String(fromDate.year));
    params = params.append('startDateMonth', String(fromDate.month));
    params = params.append('startDateDay' , String(fromDate.day));
    return this.http.get<ReportReadModel[]>(this.uri, {headers:headers, params : params}).pipe(
      map((responseData : ReportReadModel[]) => {
        const linesArray: ReportReadModel[] = []; 
        this.lines = [];
        for(let i = 0; i < responseData.length; i++){
          this.lines.push(responseData[i]);
          linesArray.push(responseData[i]);
        }
        return linesArray;
      }),
      catchError(err => {
        return throwError(err);
      })
    )
  }
}
