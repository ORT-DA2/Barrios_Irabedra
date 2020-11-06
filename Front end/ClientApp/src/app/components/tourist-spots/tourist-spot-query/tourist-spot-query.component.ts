import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Input, OnInit } from '@angular/core';
import { TouristSpotReadModel } from 'src/app/models/readModels/tourist-spot-read-model';
import { TouristSpotService } from 'src/app/services/tourist-spot.service';

@Component({
  selector: 'app-tourist-spot-query',
  templateUrl: './tourist-spot-query.component.html',
  styleUrls: ['./tourist-spot-query.component.css']
})
export class TouristSpotQueryComponent implements OnInit {

  @Input() queryResponse: TouristSpotReadModel[] = [];

  touristSpotService: TouristSpotService;
  constructor(touristSpotService: TouristSpotService) {
    this.touristSpotService = touristSpotService;
   }

  ngOnInit(): void {
  }

  onSubmit(){
    this.touristSpotService.getAll();
    console.log(this.touristSpotService.loadedTouristSpots);
  }
}
