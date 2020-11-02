import { TouristSpot } from '../touristSpot/tourist-spot.model';

export class Region {
    public name: string;
    public touristSpots: TouristSpot[];
    public id: number;

    constructor(name: string, touristSpots: TouristSpot[], id: number){
        this.id = id;
        this.name = name;
        this.touristSpots = touristSpots;
    }
}
