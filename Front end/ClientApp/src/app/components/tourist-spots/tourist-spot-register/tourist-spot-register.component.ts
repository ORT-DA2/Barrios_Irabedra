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
  regions=["Region metropolitana", "Region este", "Region litoral norte", "Region corredor pajaros pintados", "Region centro sur"];
  private errorSub: Subscription;
  error = null;

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
    this.Inactive=true;
  }
  
  loadData(){
    this.touristSpotService.getAll();
  }

   onSubmitRegister(){
    this.show = !this.show;
    this.touristSpotService.register(this.submittedObject);
  }
  
  onSubmitUpdate(){
    this.show = !this.show;
    this.touristSpotService.update(this.submittedObject);
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


