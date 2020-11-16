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
  public loadedAccommodations: AccommodationReadModel[];
  public selectedAccommodationName : string;

  constructor(accommodationService: AccommodationService) { 
    this.accommodationService = accommodationService;
    this.accommodationService.getAll();
    this.loadedAccommodations = this.accommodationService.loadedAccommodations;
  }

  ngOnInit(): void {
  }


  onSubmit(){
    this.accommodationService.delete(this.selectedAccommodationName);
  }
}
