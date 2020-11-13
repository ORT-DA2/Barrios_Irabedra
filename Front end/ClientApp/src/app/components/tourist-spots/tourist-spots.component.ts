import { Component, OnInit, ViewChild } from '@angular/core';
import { AddCategoryToTouristSpotComponent } from './add-category-to-tourist-spot/add-category-to-tourist-spot.component';
import { TouristSpotQueryComponent } from './tourist-spot-query/tourist-spot-query.component';
import { TouristSpotRegisterComponent } from './tourist-spot-register/tourist-spot-register.component';

@Component({
  selector: 'app-tourist-spots',
  templateUrl: './tourist-spots.component.html',
  styleUrls: ['./tourist-spots.component.css'],
})
export class TouristSpotsComponent implements OnInit {


  constructor() {
   }

  ngOnInit(): void {
    
  }

  checkAdminToken(){
    if(sessionStorage.getItem('admin') !== null){
      return true;
    }
    else{
      return false;
    }
   }
}
