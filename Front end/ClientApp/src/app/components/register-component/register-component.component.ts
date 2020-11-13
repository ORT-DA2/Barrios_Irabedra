import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-register-component',
  templateUrl: './register-component.component.html',
  styleUrls: ['./register-component.component.css']
})
export class RegisterComponentComponent implements OnInit {

  loginService:LoginService;
  @ViewChild('form') loginForm : NgForm;
  public email : string;
  public password : string;

  constructor(loginService:LoginService) {
    this.loginService=loginService;
   }

  ngOnInit(): void {
  }

  onClick(){
    this.loginService.register(this.email, this.password);
  }
}


