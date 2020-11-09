import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Input, OnInit } from '@angular/core';
import { TouristSpotReadModel } from 'src/app/models/readModels/tourist-spot-read-model';
import { CategoryService } from 'src/app/services/category.service';
import { CategoryReadModel } from '../../../models/readModels/category-read-model';
import { TouristSpotService } from 'src/app/services/tourist-spot.service';

@Component({
  selector: 'app-tourist-spot-query',
  templateUrl: './tourist-spot-query.component.html',
  styleUrls: ['./tourist-spot-query.component.css']
})
export class TouristSpotQueryComponent implements OnInit {

  @Input() queryResponse: TouristSpotReadModel[] = [];
  selectedRegionName : string = null;
  selectedCategoryNames : string[] = null;
  categoriesString : string[] = [];
  categories : CategoryReadModel[] = [];

  touristSpotService: TouristSpotService;
  categoryService: CategoryService;


 

  constructor(touristSpotService: TouristSpotService, categoryService: CategoryService) {
    this.touristSpotService = touristSpotService;
    this.categoryService = categoryService;
    }

  ngOnInit(): void {
    this.categoryService.getAll();
  }

  onRefreshActivation(){
    this.categories = this.categoryService.loadedCategories;
    this.categoriesString = this.toStringArray(this.categories);
    console.log(this.categories);
    console.log(this.categoriesString);
  }

  onSubmit(){
    console.log(this.selectedCategoryNames);
    if(this.selectedCategoryNames === null && this.selectedRegionName === null){
      this.touristSpotService.getAll();
      console.log(this.touristSpotService.loadedTouristSpots);
    }
    else{
      this.touristSpotService.get(this.selectedRegionName, this.selectedCategoryNames);
      console.log(this.touristSpotService.loadedTouristSpots);
    }
  }

  toStringArray(categoryList : CategoryReadModel[] ){
    let ret : string[] = [];
    for(var i = 0; i< categoryList.length; i++){
      ret.push(categoryList[i].name);
    }
    return ret;
  }
}
