import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject, throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

 @Injectable({
    providedIn: 'root'
  })
 export class ImportService {
      
  
    private uri = environment.URI_BASE+'/imports';
    public token : string;
    public loadedImplementations: string[] = [];
    error = new Subject<string>();
  
    constructor(private http: HttpClient) { 
  
    }

    getImplementations(xmlPath:string, jsonPath:string){
        let headers = new HttpHeaders().append("jsonPath", jsonPath).append("xmlPath", xmlPath);
        let options = { headers: headers };
        this.http
        .get(this.uri, options)
        .pipe(
          map((responseData : string[]) => {
            const implementationsArray: string[] = []; 
            this.loadedImplementations = [];
            for(let i = 0; i < responseData.length; i++){
              this.loadedImplementations.push(responseData[i]);
              implementationsArray.push(responseData[i]);
            }
            return implementationsArray;
          })
        ).subscribe(response => {}, error => {console.log(this.handleError(error));
          this.error.next(error)})
    }

    import(format:string, myPath:string){
      
        console.log("entered");
        format = format.toLowerCase();
        if(format.toLowerCase().includes("xml")){
            console.log(format);
            let localuri:string = this.uri + "/xml";
            console.log(myPath);
            this.http.post(localuri, {path : myPath}).subscribe(response => {}, error => {console.log(this.handleError(error));
              this.error.next(error)});
        }
        if(format.toLowerCase().includes("json")){
            console.log(format);
            let localuri:string = this.uri + "/json";
            console.log(myPath);
            this.http.post(localuri,  {path : myPath}).subscribe(response => {}, error => {console.log(this.handleError(error));
              this.error.next(error)});
        }

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