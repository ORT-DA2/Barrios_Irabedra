import { Component, OnInit } from '@angular/core';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { AccommodationReadModel } from 'src/app/models/readModels/accommodation-read-model';
import { AccommodationQueryOutModel } from 'src/app/models/writeModels/accommodation-query-out-model';
import { AccommodationService } from 'src/app/services/accommodation.service';
import { TouristSpotService } from 'src/app/services/tourist-spot.service';

@Component({
  selector: 'app-accommodation-query',
  templateUrl: './accommodation-query.component.html',
  styleUrls: ['./accommodation-query.component.css']
})
export class AccommodationQueryComponent implements OnInit {

  public touristSpotService : TouristSpotService;
  public visible = false;
  public accommodationService : AccommodationService;
  public toDate : NgbDate;//: NgbDate;
  public fromDate : NgbDate;
  public submittedObject : AccommodationQueryOutModel = new AccommodationQueryOutModel();
  public queryResponse : AccommodationReadModel[];
  public selectedByUser : AccommodationReadModel;

  constructor(accommodationService : AccommodationService, touristSpotService : TouristSpotService) {
    this.accommodationService = accommodationService;
    this.touristSpotService = touristSpotService;
   }

  ngOnInit(): void {
    this.touristSpotService.getAll();
  }

  toDateHandler($event : any){
    this.toDate = $event;
  }

  fromDateHandler($event : any){
    this.fromDate = $event;
  }

  onSubmit(){
    this.submittedObject.CheckInDay = this.fromDate.day;
    this.submittedObject.CheckInMonth = this.fromDate.month;
    this.submittedObject.CheckInYear = this.fromDate.year;
    this.submittedObject.CheckOutDay = this.fromDate.day;
    this.submittedObject.CheckOutMonth = this.fromDate.month;
    this.submittedObject.CheckOutYear = this.fromDate.year;
    this.submittedObject.TotalGuests = this.submittedObject.Retirees + this.submittedObject.Adults + this.submittedObject.Kids + this.submittedObject.Babies;
    console.log(this.submittedObject);
    this.accommodationService.getForQuery(this.submittedObject);
    this.queryResponse = this.accommodationService.queryResponse;
    this.visible = true;
  }
}
