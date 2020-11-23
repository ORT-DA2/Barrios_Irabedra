import { Component, OnInit } from '@angular/core';
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
  errorOcurred = false;
  errorMsg : string = null;
  success = false;

  constructor(importService: ImportService) {
    this.importService=importService;
   }


  onSubmit(){
    console.log(this.format);
    console.log(this.jsonPath);
    console.log(this.xmlPath);
    if(this.format.toLowerCase().includes('xml')){
      this.importService.import(this.xmlPath, this.format, this.Filepath).subscribe( 
        res => {
          this.errorOcurred=false;
          console.log(res);
          this.success = true;
        },
        err => {
          this.success = false;
          this.errorOcurred = true;
          this.errorMsg = err.error;
        },
      )
    }
    else{
      this.importService.import(this.jsonPath, this.format, this.Filepath).subscribe( 
        res => {
          this.errorOcurred=false;
          console.log(res);
          this.success = true;
        },
        err => {
          this.success = false;
          this.errorOcurred = true;
          this.errorMsg = err.error;
        },
      )
    }


  }
   
  loadAssemblies(){
    this.importService.getImplementations( this.xmlPath, this.jsonPath).subscribe( 
      res => {
        console.log(res);
      },
      err => {
        this.errorOcurred = true;
        this.errorMsg = err.error;
      },
    )
  }

  ngOnInit(): void {
  }

  
}
