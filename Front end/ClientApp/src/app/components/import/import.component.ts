import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ImportService } from 'src/app/services/import.service';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.css']
})
export class ImportComponent implements OnInit {

  public Filepath : string;
  public xmlPath:string;
  public jsonPath:string;
  public format : string;
  public importService: ImportService;
  private errorSub: Subscription;
  error = null;
  show = false;

  constructor(importService: ImportService) {
    this.importService=importService;
   }


  onSubmit(){
    this.importService.import(this.format, this.Filepath);
    this.error = null;
  }
   
  loadAssemblies(){
    this.importService.getImplementations( this.xmlPath, this.jsonPath);
  }

  ngOnInit(): void {
    this.errorSub = this.importService.error.subscribe(errorMessage =>{
      this.error = errorMessage;
      console.log("reached");
      this.show=true;
    })
  }

  ngOnDestroy(): void {
    this.errorSub.unsubscribe();
  }
  
}
