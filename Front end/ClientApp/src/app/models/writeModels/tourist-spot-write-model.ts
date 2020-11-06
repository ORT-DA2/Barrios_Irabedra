

export class TouristSpotWriteModel {
  public name: string;
  public description: string;
  public image: File;
  public regionName: string; 

  constructor(name: string, description: string, image: File,  regionName: string) {
    this.description = description;
    this.image = image;
    this.name = name;
    this.regionName = regionName;
   }

}
