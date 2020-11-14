export class AccommodationPutWriteModel {

    public images : string[];
    public wantToChangeCapacity : boolean;
    public fullCapacity : boolean;

    constructor ()
    {
        this.images = [];
        this.wantToChangeCapacity = false;
        this.fullCapacity = false;
    }
}
