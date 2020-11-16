import { Component, OnInit } from '@angular/core';
import { AdminWriteModel } from 'src/app/models/writeModels/admin-write-model';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-admin-update',
  templateUrl: './admin-update.component.html',
  styleUrls: ['./admin-update.component.css']
})
export class AdminUpdateComponent implements OnInit {

  public admin:AdminWriteModel= new AdminWriteModel();
  public adminService:AdminService;

  constructor(adminService:AdminService) { 
    this.adminService=adminService;
  }


  ngOnInit(): void {
  }

  onSubmit(){
    this.adminService.update(this.admin);
  }
}
