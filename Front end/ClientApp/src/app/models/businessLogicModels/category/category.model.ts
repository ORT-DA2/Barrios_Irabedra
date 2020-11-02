import { TouristSpot } from '../touristSpot/tourist-spot.model';

export class Category {
    
    public name : string;
    public id: number;
    public touristSpots: TouristSpot[];

    constructor(name : string, id: number, touristSpots: TouristSpot[]) {
        this.id = id;
        this.name = name;
        this.touristSpots = touristSpots;
    }
}
