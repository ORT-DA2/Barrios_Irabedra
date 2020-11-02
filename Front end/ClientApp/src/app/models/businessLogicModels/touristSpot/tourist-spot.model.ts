import { Category } from '../category/category.model';

export class TouristSpot {
    public name: string;
    public description: string;
    public image: string;
    public categories: Category[];

    constructor(name: string, description: string,
         image: string, categories: Category[]){
        this.categories = categories;
        this.description = description;
        this.image = image;
        this.name = name;
    }
}
