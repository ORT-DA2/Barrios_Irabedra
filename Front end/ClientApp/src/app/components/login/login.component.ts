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

  constructor(loginService:LoginService) {
    this.loginService = loginService;
   }

  ngOnInit(): void {
  }

  onClick(){
    console.log("paso 1");
    let token= this.loginService.login(this.loginForm.value.email, this.loginForm.value.password);
    console.log(token);
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
