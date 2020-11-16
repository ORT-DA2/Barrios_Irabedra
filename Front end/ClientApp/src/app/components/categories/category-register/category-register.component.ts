import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-register',
  templateUrl: './category-register.component.html',
  styleUrls: ['./category-register.component.css']
})
export class CategoryRegisterComponent implements OnInit {

  public name:string;
  public categoryService : CategoryService;
  constructor(categoryService : CategoryService) {
    this.categoryService = categoryService;
   }

  ngOnInit(): void {
  }


  onSubmit(){
    this.categoryService.register(this.name);
  }
}
