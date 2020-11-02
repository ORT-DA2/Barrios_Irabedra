export class TouristSpotReadModel {
    public name: string;
    public description: string;
    public image: string;
    public id: number;

    constructor(name: string, description: string, image: string, id: number){
        this.name = name;
        this.description = description;
        this.image = image;
        this.id = id;
    }
}
