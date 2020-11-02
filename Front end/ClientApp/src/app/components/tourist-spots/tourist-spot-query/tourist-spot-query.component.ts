import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { TouristSpotService } from 'src/app/services/tourist-spot.service';

@Component({
  selector: 'app-tourist-spot-query',
  templateUrl: './tourist-spot-query.component.html',
  styleUrls: ['./tourist-spot-query.component.css']
})
export class TouristSpotQueryComponent implements OnInit {

  touristSpotService: TouristSpotService;
  constructor(touristSpotService: TouristSpotService) {
    this.touristSpotService = touristSpotService;
   }

  ngOnInit(): void {
  }

  onSubmit(){
    this.touristSpotService.getAll()
  }
}
