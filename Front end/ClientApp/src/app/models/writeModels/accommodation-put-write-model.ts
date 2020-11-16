export class AccommodationPutWriteModel {

    public images : string[];
    public wantToChangeCapacity : boolean;
    public fullCapacity : boolean;

    constructor ()
    {
        this.images = [];
        this.wantToChangeCapacity = true;
        this.fullCapacity = false;
    }
}
