using Obligatorio.Domain.DomainEntities;
using System;

namespace Obligatorio.Model.Models.In
{
    public class ReservationModelIn
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int TotalGuests { get; set; }
        public int Babies { get; set; }
        public int Kids { get; set; }
        public int Adults { get; set; }
        public int Retirees { get; set; }
        public string GuestName { get; set; }
        public string GuestLastName { get; set; }
        public string Email { get; set; }
        public int AccommodationId { get; set; }

        public ReservationModelIn()
        {
            this.TotalGuests = 0;
            this.Babies = 0;
            this.Kids = 0;
            this.Retirees = 0;
            this.Adults = 0;
            this.GuestName = "Default Guest Name";
            this.GuestLastName = "Default Guest LastName";
            this.Email = "Default Email";
        }

        public Reservation ToEntity()
        {
            Reservation reservationToReturn = new Reservation();
            reservationToReturn.Adults = this.Adults;
            reservationToReturn.Babies = this.Babies;
            reservationToReturn.CheckIn = this.CheckIn;
            reservationToReturn.Retirees = this.Retirees;
            reservationToReturn.CheckOut = this.CheckOut;
            reservationToReturn.Email = this.Email;
            reservationToReturn.GuestLastName = this.GuestLastName;
            reservationToReturn.GuestName = this.GuestName;
            reservationToReturn.Kids = this.Kids;
            reservationToReturn.TotalGuests = this.TotalGuests;
            return reservationToReturn;
        }
    }
}
