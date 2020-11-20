import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-admin-deletion',
  templateUrl: './admin-deletion.component.html',
  styleUrls: ['./admin-deletion.component.css']
})
export class AdminDeletionComponent implements OnInit {

  
  @ViewChild('form') registerForm:NgForm;
  public email:string="";
  public adminService:AdminService;
  errorOcurred = false;
  errorMsg : string = null;
  success = false;

  constructor(adminService:AdminService) { 
    this.adminService=adminService;
  }

  ngOnInit(): void {
  }


  onSubmit(){
    this.adminService.delete(this.email).subscribe(res => {
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
}
