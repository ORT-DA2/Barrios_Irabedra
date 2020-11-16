import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm, FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { AdminWriteModel } from 'src/app/models/writeModels/admin-write-model';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-admin-register',
  templateUrl: './admin-register.component.html',
  styleUrls: ['./admin-register.component.css']
})
export class AdminRegisterComponent implements OnInit {

  public adminService:AdminService;
  public submittedObject : AdminWriteModel = new AdminWriteModel();
  @ViewChild('form') registerForm:NgForm;

  constructor(adminService:AdminService) { 
    this.adminService = adminService;
  }


  ngOnInit(): void {
  }

  onSubmit(){
    this.adminService.register(this.submittedObject);
  }
}


