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

  touristSpotService: TouristSpotService;
  categoryService: CategoryService;



  constructor(touristSpotService: TouristSpotService, categoryService: CategoryService) {
    this.touristSpotService = touristSpotService;
    this.categoryService = categoryService;
    }

  ngOnInit(): void {
    this.categoryService.getAll();
    this.touristSpotService.getAll();
    this.categories = this.categoryService.loadedCategories;
    this.touristSpots = this.touristSpotService.loadedTouristSpots;
  }

  loadData(){
    this.categoryService.getAll();
    this.touristSpotService.getAll();
    this.categories = this.categoryService.loadedCategories;
    this.touristSpots = this.touristSpotService.loadedTouristSpots;
  }

onSubmit(){
  console.log(this.registerForm.value.touristSpotPicker);
  console.log(typeof this.registerForm.value.touristSpotPicker)
  console.log(this.registerForm.value.categoryPicker);
  console.log(typeof this.registerForm.value.categoryPicker)
  this.categoryService.addCategoryToTouristSpot(this.registerForm.value.touristSpotPicker, this.registerForm.value.categoryPicker);
}

  /*
  onSubmit(touristSpot:TouristSpotReadModel, category:CategoryReadModel){
    console.log(touristSpot.name);
    console.log(category.name);
    this.categoryService.addCategoryToTouristSpot(touristSpot.name, category.name);
  }*/

  onRefreshActivation(){
    this.categories = this.categoryService.loadedCategories;
    this.categoriesString = this.toStringArray(this.categories);
    console.log(this.categories);
    console.log(this.categoriesString);
  }

  toStringArray(categoryList : CategoryReadModel[] ){
    let ret : string[] = [];
    for(var i = 0; i< categoryList.length; i++){
      ret.push(categoryList[i].name);
    }
    return ret;
  }
}
