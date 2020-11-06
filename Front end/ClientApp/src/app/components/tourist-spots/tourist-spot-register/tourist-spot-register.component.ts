import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import {TouristSpotWriteModel} from '../../../models/writeModels/tourist-spot-write-model';

@Component({
  selector: 'app-tourist-spot-register',
  templateUrl: './tourist-spot-register.component.html',
  styleUrls: ['./tourist-spot-register.component.css']
})
export class TouristSpotRegisterComponent implements OnInit {

  @ViewChild('form') registerForm : NgForm;
  public submittedObject: TouristSpotWriteModel = new TouristSpotWriteModel("", "", null, "");


  ngOnInit(): void {
  }

  handleFileInput(files: FileList) {
    this.submittedObject.image = files.item(0);
}

  onSubmit(){
    console.log("TRIGGERED!");
    this.submittedObject.name = this.registerForm.value.name;
    this.submittedObject.description = this.registerForm.value.description;
    this.submittedObject.regionName = this.registerForm.value.regionPicker;
    console.log(this.submittedObject);
  }
}
