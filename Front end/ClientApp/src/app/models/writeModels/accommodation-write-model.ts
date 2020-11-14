export class AccommodationWriteModel 
{
    public name : string ;
    public rating : number ;
    public address : string;
    public description : string;
    public pricePerNight : number ;
    public fullCapacity :boolean ;
    public touristSpotName : string;

    constructor(name : string, rating : number, address : string, description : string, pricePerNight : number, fullCapacity :boolean, touristSpotName : string)
    {
        this.name = name;
        this.rating = rating;
        this.description = description;
        this.pricePerNight = pricePerNight;
        this.fullCapacity = fullCapacity;
        this.touristSpotName = touristSpotName;
    }

}
