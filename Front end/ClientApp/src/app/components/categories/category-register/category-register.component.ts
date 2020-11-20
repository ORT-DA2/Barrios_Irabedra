import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-register',
  templateUrl: './category-register.component.html',
  styleUrls: ['./category-register.component.css']
})
export class CategoryRegisterComponent implements OnInit {

  public 
  public name:string;
  public show : boolean = false;
  public categoryService : CategoryService;
  private errorSub: Subscription;
  error = null;
  errorOcurred = false;
  errorMsg : string = null;
  success = false;
  constructor(categoryService : CategoryService) {
    this.categoryService = categoryService;
   }
  ngOnInit(): void {
    this.errorSub = this.categoryService.error.subscribe(errorMessage =>{
      this.error = errorMessage;
    })
  }


  onSubmit(){
    if(this.error !== null){
      this.show = !this.show;
    }
    this.categoryService.register(this.name).subscribe(res => {
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



  ngOnDestroy(): void {
    this.errorSub.unsubscribe();
  }
}
