import { Component, OnInit } from '@angular/core';
import { ReservationReadModel } from 'src/app/models/readModels/reservation-read-model';
import { ReviewWriteModel } from 'src/app/models/writeModels/review-write-model';
import { ReservationService } from 'src/app/services/reservation.service';
import { ReviewService } from 'src/app/services/review.service';

@Component({
  selector: 'app-review-component',
  templateUrl: './review-component.component.html',
  styleUrls: ['./review-component.component.css']
})
export class ReviewComponent implements OnInit {

  clicked=false;
  errorOcurred=false;
  success1=false;
  success2=false;
  errorMsg;
  code:number;
  accommodationName:string;
  reservationService:ReservationService;
  rating:number;
  text:string;
  name:string;
  lastName:string;
  review:ReviewWriteModel = new ReviewWriteModel;
  reviewService:ReviewService;

  constructor(reservationService:ReservationService, reviewService:ReviewService) { 
    this.reservationService=reservationService;
    this.reviewService=reviewService;
  }

  onClicked(){
    this.clicked=true;
    this.reservationService.get(this.code).subscribe(
      (res:ReservationReadModel) => {
        this.errorOcurred = false;
        this.success1 = true;
        let tokens = res.informativeText.split(',');
        let informative = tokens[0].split(':');
        this.accommodationName = informative[1].trim();
        this.name=res.name;
        this.lastName=res.lastName;
      },
      err => {
        this.success1=false;
        this.errorOcurred = true;
        this.errorMsg=err.error;
        
      })
  }

  onClicked2(){
    this.review.accommodationName=this.accommodationName;
    this.review.lastName=this.lastName;
    this.review.name=this.name;
    this.review.text=this.text;
    this.review.rating=parseInt(String(this.rating));
    this.reviewService.create(this.review).subscribe(
      res => {
        this.success2=true;
        this.errorOcurred=false;
      },
      err => {
        this.errorOcurred = true;
        this.errorMsg = err.error;
        this.success2=false;
        console.log(err.error);
      },
    )
  }

  ngOnInit(): void {
  }

}
