import { Component, OnInit } from '@angular/core';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-accommodation-query',
  templateUrl: './accommodation-query.component.html',
  styleUrls: ['./accommodation-query.component.css']
})
export class AccommodationQueryComponent implements OnInit {

  public toDate;//: NgbDate;
  public fromDate;
  constructor() { }

  ngOnInit(): void {
  }

  toDateHandler($event : any){
    this.toDate = $event;
  }

  fromDateHandler($event : any){
    this.fromDate = $event;
  }

  onSubmit(){
    console.log(this.toDate);
    console.log(this.fromDate);
  }
}
