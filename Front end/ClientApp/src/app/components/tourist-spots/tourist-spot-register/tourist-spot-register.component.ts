import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import {TouristSpotWriteModel} from '../../../models/writeModels/tourist-spot-write-model';
import { TouristSpotService } from 'src/app/services/tourist-spot.service';

@Component({
  selector: 'app-tourist-spot-register',
  templateUrl: './tourist-spot-register.component.html',
  styleUrls: ['./tourist-spot-register.component.css']
})
export class TouristSpotRegisterComponent implements OnInit {

  @ViewChild('form') registerForm : NgForm;
  public submittedObject: TouristSpotWriteModel = new TouristSpotWriteModel("", "", null, "");
  touristSpotService: TouristSpotService;

  constructor(touristSpotService: TouristSpotService) {
    this.touristSpotService = touristSpotService;
   }

  ngOnInit(): void {
  }

  
  loadData(){
    this.touristSpotService.getAll();
  }

  onSubmit(){
    this.submittedObject.name = this.registerForm.value.name;
    this.submittedObject.description = this.registerForm.value.description;
    this.submittedObject.regionName = this.registerForm.value.regionPicker;
    console.log(this.submittedObject);
    this.touristSpotService.post(this.submittedObject);
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
}


