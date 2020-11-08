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

    public miFun() : boolean{
        return true;
    }

    public getDataUrl(img) {
        // Create canvas
        const canvas = document.createElement('canvas');
        const ctx = canvas.getContext('2d');
        // Set width and height
        canvas.width = img.width;
        canvas.height = img.height;
        // Draw the image
        ctx.drawImage(img, 0, 0);
        return canvas.toDataURL('image/jpeg');
     }
}
