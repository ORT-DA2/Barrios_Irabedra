import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import {TouristSpotWriteModel} from '../../../models/writeModels/tourist-spot-write-model';
import { TouristSpotService } from 'src/app/services/tourist-spot.service';
import { waitForAsync } from '@angular/core/testing';
import { rejects } from 'assert';
import { HttpErrorResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-tourist-spot-register',
  templateUrl: './tourist-spot-register.component.html',
  styleUrls: ['./tourist-spot-register.component.css']
})
export class TouristSpotRegisterComponent implements OnInit {

  public show : boolean = false;
  public Inactive:boolean = false;
  @ViewChild('form') registerForm : NgForm;
  public submittedObject: TouristSpotWriteModel = new TouristSpotWriteModel();
  touristSpotService: TouristSpotService;
  regionName:string;
  regions=["Region metropolitana", "Region este", "Region litoral norte", "Region corredor de los pajaros pintados", "Region centro sur"];
  private errorSub: Subscription;
  error = null;
  errorOcurred = false;
  errorMsg : string = null;
  success = false;
  constructor(touristSpotService: TouristSpotService) {
    this.touristSpotService = touristSpotService;
   }

   

  ngOnInit(): void {
    this.errorSub = this.touristSpotService.error.subscribe(errorMessage =>{
      this.error = errorMessage;
    })
  }

  setRegion(value : string){
    this.submittedObject.regionName=value;
  }
  
  loadData(){
    this.touristSpotService.getAll();
  }

   onSubmitRegister(){
    this.touristSpotService.register(this.submittedObject).subscribe(res => {
      console.log(res);
      this.show = true;
      this.errorOcurred = false;
    },
    err => {
      this.errorOcurred = true;
      console.log(err.error);
      this.errorMsg = err.error;
    })
  }
  
  onSubmitUpdate(){
    this.touristSpotService.update(this.submittedObject).subscribe(res => {
      console.log(res);
      this.success = true;
    },
    err => {
      this.errorOcurred = true;
      console.log(err.error);
      this.errorMsg = err.error;
    })
  }

  
  changeListener($event) : void {
    this.readThis($event.target);
  }
  
  readThis(inputValue: any): void {
    var file:File = inputValue.files[0];
    var myReader:FileReader = new FileReader();
  
    myReader.onloadend = (e) => {
      this.submittedObject.image = myReader.result.toString();
    }
    myReader.readAsDataURL(file);
  }

  
  checkAdminToken(){
    if(sessionStorage.getItem('admin') !== null){
      return true;
    }
    else{
      return false;
    }
   }

   resetError(){
     this.error=null;
   }

   ngOnDestroy(): void {
     this.errorSub.unsubscribe();
   }
}


