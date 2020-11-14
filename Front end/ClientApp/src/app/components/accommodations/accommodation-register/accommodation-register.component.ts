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
  public submittedObject: AccommodationWriteModel = new AccommodationWriteModel("", -1, "", "", -1, false, "");

  constructor(accommodationService : AccommodationService, touritSpotService : TouristSpotService) 
  {
    this.accommodationService = accommodationService;
    this.touristSpotService = touritSpotService;
  }

  loadData(){
    this.accommodationService.getAll();
  }

  onSubmit(){
    this.submittedObject.name = this.registerForm.value.name;
    this.submittedObject.rating = this.registerForm.value.rating;
    this.submittedObject.description = this.registerForm.value.description;
    this.submittedObject.pricePerNight = this.registerForm.value.pricePerNight;
    this.submittedObject.fullCapacity = this.registerForm.value.fullCapacity;
    this.submittedObject.touristSpotName = this.registerForm.value.touristSpotName;
    console.log(this.submittedObject);
    this.accommodationService.register(this.submittedObject);
  }

  ngOnInit(): void {
  }

}
