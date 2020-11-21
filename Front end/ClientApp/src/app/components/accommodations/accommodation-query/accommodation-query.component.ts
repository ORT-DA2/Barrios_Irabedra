import { Component, OnInit } from '@angular/core';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { AccommodationReadModel } from 'src/app/models/readModels/accommodation-read-model';
import { ReservationReadModel } from 'src/app/models/readModels/reservation-read-model';
import { TouristSpotReadModel } from 'src/app/models/readModels/tourist-spot-read-model';
import { AccommodationQueryOutModel } from 'src/app/models/writeModels/accommodation-query-out-model';
import { ReservationWriteModel } from 'src/app/models/writeModels/reservation-write-model';
import { AccommodationService } from 'src/app/services/accommodation.service';
import { ReservationService } from 'src/app/services/reservation.service';
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
  public queryResponse : AccommodationReadModel[] = [];
  public reservation : ReservationWriteModel = new ReservationWriteModel();
  public reservationResult:ReservationReadModel;
  public reservationService:ReservationService;
  public selectedTouristSpot;
  errorOcurred = false;
  errorMsg : string = null;
  success1 = false;
  success2=false;
  numerito:number;

  constructor(accommodationService : AccommodationService, touristSpotService : TouristSpotService, reservationService : ReservationService) {
    this.accommodationService = accommodationService;
    this.reservationService = reservationService;
    this.touristSpotService = touristSpotService;
    this.touristSpotService.getAll().subscribe();
    this.accommodationService.getAll();
   }

  ngOnInit(): void {

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
    console.log(this.submittedObject.TouristSpotName);
    this.accommodationService.getForQuery(this.submittedObject).subscribe(res => {
      this.queryResponse = res;
      this.errorOcurred = false;
      this.success1 = true;
    },
    err => {
      this.success1=false;
      this.errorOcurred = true;
      console.log(err.error);
      this.errorMsg = err.error;
    })
    this.queryResponse = this.accommodationService.queryResponse;
    this.visible = true;
  }

  onChange2(value){
    this.reservation.AccommodationName = value;
  }

  onSubmit2(){
    this.reservation.CheckIn = new Date(this.fromDate.year + '-'+ this.fromDate.month + '-' + this.fromDate.day); 
    this.reservation.CheckOut =new Date (this.toDate.year + '-'+ this.toDate.month + '-' + this.toDate.day); 

    this.reservation.Adults = this.submittedObject.Adults;
    this.reservation.Retirees = this.submittedObject.Retirees;
    this.reservation.Kids = this.submittedObject.Kids;
    this.reservation.Babies = this.submittedObject.Babies;
    this.reservation.TotalGuests = this.submittedObject.Retirees + this.submittedObject.Adults + this.submittedObject.Kids + this.submittedObject.Babies;
    console.log(this.reservation);
    this.reservationService.createReservation(this.reservation).subscribe((res:number)=> {
      console.log("valor inicial", res);
      console.log("lo parseo como tres veces", parseInt(res.toString()));
      this.numerito = parseInt(res.toString());
      console.log("imprimo despues de asignar a variable", this.numerito);
      this.errorOcurred = false;
      this.success2 = true;
       },
    err => {
      this.success2=false;
      this.errorOcurred = true;
      console.log(err.error);
      this.errorMsg = err.error;
    })
  }

  onChange(value) {
    this.submittedObject.TouristSpotName=value;
}
}
