import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-accommodation-update',
  templateUrl: './accommodation-update.component.html',
  styles: [
  ]
})
export class AccommodationUpdateComponent implements OnInit {

  @Input('accommodationName') accommodationName: string;
  constructor() { }

  ngOnInit(): void {
  }

  public onAccommodationSelect(selectedAccommodation: HTMLInputElement){
    this.accommodationName=selectedAccommodation.value;
  }
}
