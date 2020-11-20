import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginService:LoginService;
  @ViewChild('form') loginForm : NgForm;
  public email : string;
  public password : string;
  errorOcurred = false;
  errorMsg : string = null;

  constructor(loginService:LoginService) {
    this.loginService = loginService;
   }

  ngOnInit(): void {
  }

  onClick(){
    this.loginService.login(this.loginForm.value.email, this.loginForm.value.password).subscribe(
      res =>{
        let token : string = res;
        console.log(token);
        if(token.includes('admin')){
          sessionStorage.setItem('admin', this.loginForm.value.email);
      }
      },
      err => {
        this.errorOcurred = true;
        this.errorMsg = err.error;
      },
  
    )
  }

  checkAdminToken(){
   if(sessionStorage.getItem('admin') !== null){
     return true;
   }
   else{
     return false;
   }
  }

  logout(){
    sessionStorage.removeItem('admin');
  }
}
