import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AccommodationWriteModel } from 'src/app/models/writeModels/accommodation-write-model';
import { AccommodationService } from 'src/app/services/accommodation.service';
import { TouristSpotService } from 'src/app/services/tourist-spot.service';

@Component({
  selector: 'app-accommodation-register',
  templateUrl: './accommodation-register.component.html',
  styleUrls: ['./accommodation-register.component.css']
})
export class AccommodationRegisterComponent implements OnInit {
  
  @ViewChild('form') registerForm : NgForm;
  public selectedTouristSpot : string;
  public accommodationService : AccommodationService;
  public touristSpotService : TouristSpotService;
  public submittedObject: AccommodationWriteModel = new AccommodationWriteModel();

  constructor(accommodationService : AccommodationService, touritSpotService : TouristSpotService) 
  {
    this.accommodationService = accommodationService;
    this.touristSpotService = touritSpotService;
  }

  loadData(){
    this.accommodationService.getAll();
    this.touristSpotService.getAll();
  }

  onSubmit(){
    console.log("PIJAAAAAAAAAAAAAAAAAAAAA");
    this.submittedObject.Name = this.registerForm.value.name;
    this.submittedObject.Rating = parseInt(this.registerForm.value.rating);
    this.submittedObject.Description = this.registerForm.value.description;
    this.submittedObject.PricePerNight = this.registerForm.value.price;
    this.submittedObject.FullCapacity = this.registerForm.value.fullCapacity;
    this.submittedObject.TouristSpotName = this.registerForm.value.touristSpotPicker;
    this.submittedObject.FullCapacity = false;
    console.log(this.submittedObject);
    this.accommodationService.register(this.submittedObject);
  }

  ngOnInit(): void {
    
  }

}
