import { TouristSpot } from '../touristSpot/tourist-spot.model';

export class Accommodation {

    public id: number;
    public name: string;
    public rating: number;
    public address: string;
    public description: string;
    public images: string[];
    public pricePerNight: number;
    public fullCapacityReached: boolean;
    public touristSpot: TouristSpot;

    public Accommodation( id: number, name: string, rating: number, address: string,
         description: string, images: string[], pricePerNight: number, fullCapacityReached: boolean, touristSpot: TouristSpot){
            this.name = name;
            this.images = images;
            this.pricePerNight = pricePerNight;
            this.rating = rating;
            this.address = address;
            this.description = description;
            this.touristSpot = touristSpot;
            this.id = id;
            this.fullCapacityReached = fullCapacityReached;
    }
}
