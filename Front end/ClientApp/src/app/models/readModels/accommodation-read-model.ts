export class AccommodationReadModel {
    public address: string;
    public description : string;
    public images : string[];
    public name : string;
    public pricePerNight : number;
    public totalPrice : number;
    public rating : number;

    constructor(address: string, description : string, images : string[], name : string, pricePerNight : number, totalPrice : number, rating : number)
    {
        this.address = address;
        this.description = description;
        this.images = images;
        this.name = name;
        this.pricePerNight = pricePerNight;
        this.rating = rating;
        this.totalPrice = totalPrice;
    }
}
