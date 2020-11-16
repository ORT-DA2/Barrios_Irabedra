import { Component, OnInit, Input } from '@angular/core';
import { AccommodationReadModel } from 'src/app/models/readModels/accommodation-read-model';
import { AccommodationPutWriteModel } from 'src/app/models/writeModels/accommodation-put-write-model';
import { AccommodationService } from 'src/app/services/accommodation.service';

@Component({
  selector: 'app-accommodation-update',
  templateUrl: './accommodation-update.component.html',
  styles: [
  ]
})
export class AccommodationUpdateComponent implements OnInit {

  public accommodationService: AccommodationService;
  public loadedAccommodations: AccommodationReadModel[];
  public selectedAccommodationName : string;
  public newData: AccommodationPutWriteModel = new AccommodationPutWriteModel();
  public selectedAccommodation : AccommodationReadModel;
  constructor(accommodationService: AccommodationService) { 
    this.accommodationService = accommodationService;
    this.accommodationService.getAll();
    this.loadedAccommodations = this.accommodationService.loadedAccommodations;
  }

  ngOnInit(): void {
    this.accommodationService.getAll();
  }

  onAccommodationSelect(){
    this.selectedAccommodation = this.accommodationService.find(this.selectedAccommodationName);

  }
  
  changeListener($event) : void {
    this.readThis($event.target);
  }
  
  readThis(inputValue: any): void {
    var file:File = inputValue.files[0];
    var myReader:FileReader = new FileReader();
  
    myReader.onloadend = (e) => {
      this.newData.images.push(myReader.result.toString());
    }
    myReader.readAsDataURL(file);

 
  }

 
 

  onSubmit(){
    this.accommodationService.update(this.selectedAccommodationName, this.newData);
    this.newData.images = [];
  }
}
