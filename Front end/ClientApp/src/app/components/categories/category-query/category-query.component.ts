import { Component, OnInit } from '@angular/core';
import { CategoryReadModel } from 'src/app/models/readModels/category-read-model';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-query',
  templateUrl: './category-query.component.html',
  styleUrls: ['./category-query.component.css']
})
export class CategoryQueryComponent implements OnInit {

  public categoryService : CategoryService;
  public loadedCategories : CategoryReadModel[];
  constructor(categoryService : CategoryService) {
    this.categoryService = categoryService;
    this.categoryService.getAll();
    this.loadedCategories=this.categoryService.loadedCategories;
   }


  ngOnInit(): void {
  }

}
