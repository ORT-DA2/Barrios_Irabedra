import { Component, OnInit } from '@angular/core';
import { AccommodationReadModel } from 'src/app/models/readModels/accommodation-read-model';
import { AccommodationService } from 'src/app/services/accommodation.service';

@Component({
  selector: 'app-accommodation-deletion',
  templateUrl: './accommodation-deletion.component.html',
  styleUrls: ['./accommodation-deletion.component.css']
})
export class AccommodationDeletionComponent implements OnInit {

  public accommodationService: AccommodationService;
  public selectedAccommodationName : string = '';
  errorOcurred = false;
  errorMsg : string = null;
  success = false;

  constructor(accommodationService: AccommodationService) { 
    this.accommodationService = accommodationService;
    this.accommodationService.getAll();
  }

  ngOnInit(): void {
  }


  onSubmit(){
    this.accommodationService.delete(this.selectedAccommodationName).subscribe(res => {
      this.errorOcurred = false;
      this.success = true;
    },
    err => {
      this.success=false;
      this.errorOcurred = true;
      console.log(err.error);
      this.errorMsg = err.error;
    })
  }
}
