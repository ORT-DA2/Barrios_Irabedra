import { exception } from 'console';
import { Accommodation } from '../accommodation/accommodation.model';

export class Reservation {
    public id: number;
    public checkIn: Date;
    public checkOut: Date;
    public totalGuests: number;
    public babies: number;
    public kids: number;
    public adults: number;
    public guestName: string;
    public guestLastName: string;
    public email: string;
    public phoneNumber: number;
    public information: string;
    public accommodation: Accommodation;
    public reservationStatus: string;

    public reservationStatusIsValid() {
        return (this.reservationStatus === 'Created' ||
            this.reservationStatus === 'Pending' ||
            this.reservationStatus === 'Accepted' ||
            this.reservationStatus === 'Denied' ||
            this.reservationStatus === 'Expired')
    }

    constructor(id: number,checkIn: Date,checkOut: Date,
        totalGuests: number,babies: number,kids: number,adults: number,
        guestName: string,guestLastName: string,email: string,
        phoneNumber: number,information: string,accommodation: Accommodation,reservationStatus: string){
            this.accommodation = accommodation;
            this.adults = adults;
            this.babies = babies;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.email = email;
            this.guestLastName = guestLastName;
            this.guestName = guestName;
            this.id = id;
            this.information = information;
            this.kids = kids;
            this.phoneNumber = phoneNumber;
            this.reservationStatus = reservationStatus;
            this.totalGuests = totalGuests;

            if(!this.reservationStatusIsValid()){
                throw exception("The reservation status isn't correct. Please check if there are any mistakes.")
            }
    }


}

