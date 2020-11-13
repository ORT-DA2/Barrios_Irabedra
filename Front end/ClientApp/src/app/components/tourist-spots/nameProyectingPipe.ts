import { Pipe, PipeTransform } from '@angular/core';
import { TouristSpotReadModel } from 'src/app/models/readModels/tourist-spot-read-model';

@Pipe({name: 'nameProyectingPipe'})
export class NameProyectingPipe implements PipeTransform {
  transform(ts : TouristSpotReadModel): string {
    let newStr = ts.name;
    return newStr;
  }
}