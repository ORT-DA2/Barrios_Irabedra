import { Component, OnInit } from '@angular/core';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { AccommodationReadModel } from 'src/app/models/readModels/accommodation-read-model';
import { ReservationReadModel } from 'src/app/models/readModels/reservation-read-model';
import { TouristSpotReadModel } from 'src/app/models/readModels/tourist-spot-read-model';
import { AccommodationQueryOutModel } from 'src/app/models/writeModels/accommodation-query-out-model';
import { ReservationWriteModel } from 'src/app/models/writeModels/reservation-write-model';
import { ReviewWriteModel } from 'src/app/models/writeModels/review-write-model';
import { AccommodationService } from 'src/app/services/accommodation.service';
import { ReservationService } from 'src/app/services/reservation.service';
import { ReviewService } from 'src/app/services/review.service';
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
  numeritoDeTelefono:number;
  reviewService:ReviewService;
  reviewLists:ReviewWriteModel[]=[];
  headers = ['name', 'description', 'address', 'pricePerNight', 'totalPrice', 'rating']; 
  reviewHeaders = ['text', 'rating', 'name', 'lastName'];

  constructor(accommodationService : AccommodationService, touristSpotService : TouristSpotService, reservationService : ReservationService,  reviewService:ReviewService) {
    this.accommodationService = accommodationService;
    this.reviewService=reviewService;
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

  getReviewsForOneAccommodation(name:string){
    let local = [];
    for(let i = 0; i < this.reviewLists.length; i++){
      if(this.reviewLists[i].name === name){
        local.push(this.reviewLists[i]);
      }
    }
    return local;
  }

  getAllReviews(list:AccommodationReadModel[]){
    console.log("encontradas" , list);
    let localResponse:ReviewWriteModel[] = []
    for(let i = 0; i < list.length; i++){
;
      this.reviewService.get(list[i].name).subscribe((res:ReviewWriteModel[]) => {
        console.log("para la accommodation" , name, "encontre", res);
        for(let j = 0; j < res.length; j++){
          list[i].reviews.push(res[j]);
        }
        console.log("ahora la accommodation" , list[i].name, "encontre", list[i].reviews);
      }),
      err => {
        this.success1=false;
        this.errorOcurred = true;
        console.log(err.error);
        this.errorMsg = err.error;
      }
    }
    
  }

  calculateAverage(list:ReviewWriteModel[]){
    let sum = 0;
    let count = 0;
    for(let i = 0; i < list.length; i++){
      sum = sum + list[i].rating
      count = i + 1;
    }
    return (sum / count);

  }

  fromDateHandler($event : any){
    this.fromDate = $event;
  }

  onSubmit(){
    this.submittedObject.CheckInDay = this.fromDate.day;
    this.submittedObject.CheckInMonth = this.fromDate.month;
    this.submittedObject.CheckInYear = this.fromDate.year;
    this.submittedObject.CheckOutDay = this.toDate.day;
    this.submittedObject.CheckOutMonth = this.toDate.month;
    this.submittedObject.CheckOutYear = this.toDate.year;
    this.submittedObject.TotalGuests = this.submittedObject.Retirees + this.submittedObject.Adults + this.submittedObject.Kids + this.submittedObject.Babies;
    this.accommodationService.getForQuery(this.submittedObject).subscribe(res => {
      this.queryResponse = res;
      this.errorOcurred = false;
      this.success1 = true;
      this.getAllReviews(this.queryResponse);
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
    this.reservationService.createReservation(this.reservation).subscribe((res:number)=> {
      this.numerito = parseInt(res.toString());
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
