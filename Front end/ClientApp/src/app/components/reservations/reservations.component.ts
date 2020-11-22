import { Component, OnInit } from '@angular/core';
import { ReservationReadModel } from 'src/app/models/readModels/reservation-read-model';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.css']
})
export class ReservationsComponent implements OnInit {

  clicked=false;
  errorOcurred=false;
  success=false;
  errorMsg;
  code:number;
  returned:ReservationReadModel =  new ReservationReadModel;
  reservationService:ReservationService;

  constructor(reservationService:ReservationService) { 
    this.reservationService = reservationService;
  }

  ngOnInit(): void {
  }

  onClicked(){
    this.clicked=true;
    this.reservationService.get(this.code).subscribe(
      res => {
        this.returned = res;
        this.errorOcurred = false;
        this.success = true;
      },
      err => {
        this.success=false;
        this.errorOcurred = true;
        this.errorMsg=err.error;
        
      })
  }
}
