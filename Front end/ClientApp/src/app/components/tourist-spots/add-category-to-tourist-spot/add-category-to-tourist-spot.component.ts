import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnInit, Pipe, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

import { CategoryReadModel } from 'src/app/models/readModels/category-read-model';
import { TouristSpotReadModel } from 'src/app/models/readModels/tourist-spot-read-model';
import { CategoryService } from 'src/app/services/category.service';
import { TouristSpotService } from 'src/app/services/tourist-spot.service';

@Component({
  selector: 'app-add-category-to-tourist-spot',
  templateUrl: './add-category-to-tourist-spot.component.html',
  styleUrls: ['./add-category-to-tourist-spot.component.css']
})
export class AddCategoryToTouristSpotComponent implements OnInit {

  @ViewChild('form') registerForm : NgForm;
  categoriesString : string[] = [];
  categories : CategoryReadModel[] = [];
  selectedCategory : CategoryReadModel;
  selectedTouristSpot: TouristSpotReadModel;
  touristSpots: TouristSpotReadModel[];
  errorOcurred = false;
  errorMsg : string = null;
  success = false;


  touristSpotService: TouristSpotService;
  categoryService: CategoryService;



  constructor(touristSpotService: TouristSpotService, categoryService: CategoryService) {
    this.touristSpotService = touristSpotService;
    this.categoryService = categoryService;
    this.touristSpotService.getAll().subscribe();
    this.categoryService.getAll();
    }

  ngOnInit(): void {
  }



onSubmit(){
  this.errorOcurred=false;
  this.success=false;
  this.categoryService.addCategoryToTouristSpot(this.registerForm.value.touristSpotPicker, this.registerForm.value.categoryPicker).subscribe( 
    res => {
      console.log(res);
      this.success = true;
    },
    err => {
      this.errorOcurred = true;
      this.errorMsg = err.error;
    },

  )
  
  
}



  toStringArray(categoryList : CategoryReadModel[] ){
    let ret : string[] = [];
    for(var i = 0; i< categoryList.length; i++){
      ret.push(categoryList[i].name);
    }
    return ret;
  }
}
