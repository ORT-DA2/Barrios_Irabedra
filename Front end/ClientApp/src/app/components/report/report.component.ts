import { Component, OnInit } from '@angular/core';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { ReportService } from 'src/app/services/report.service';
import { TouristSpotService } from 'src/app/services/tourist-spot.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  create=false;
  toDate:NgbDate;
  fromDate:NgbDate;
  touristSpotName:string;
  touristSpotService:TouristSpotService;
  reportService:ReportService;
  errorOcurred=false;
  success=false;
  errorMsg;
  constructor( touristSpotService:TouristSpotService, reportService:ReportService) {
    this.touristSpotService = touristSpotService;
    this.reportService = reportService;
   }

  ngOnInit(): void {
    this.touristSpotService.getAll().subscribe();
  }

  wannaCreate(){
    this.create=true;
  }

  onSubmit(){
    this.reportService.createReport(this.toDate, this.fromDate, this.touristSpotName).subscribe(res => {
      this.errorOcurred = false;
      this.success = true;
      console.log(res);
      if(res.length === 0){
        this.errorOcurred=true;
        this.errorMsg='None were found';
      }
    },
    err => {
      this.success=false;
      this.errorOcurred = true;
      this.errorMsg='None were found.'
    })
  }

  
  toDateHandler($event : any){
    this.toDate = $event;
  }

  fromDateHandler($event : any){
    this.fromDate = $event;
  }

  checkAdminToken(){
    if(sessionStorage.getItem('admin') !== null){
      return true;
    }
    else{
      return false;
    }
   }

   onOk(){
     this.create=false;
     this.success=false;
     this.errorOcurred=false;
     this.errorMsg = null;

   }

   ngOnDestroy(): void {
     //Called once, before the instance is destroyed.
     //Add 'implements OnDestroy' to the class.
     
   }
}
