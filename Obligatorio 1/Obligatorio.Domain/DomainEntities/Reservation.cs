using Obligatorio.Domain.AuxiliaryObjects;
using System;

namespace Obligatorio.Domain.DomainEntities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int TotalGuests { get; set; }
        public int Babies { get; set; }
        public int Kids { get; set; }
        public int Adults { get; set; }
        public string GuestName { get; set; }
        public string GuestLastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Information { get; set; }
        public string NewStatusDescription { get; set; }
        public Accommodation AccommodationForReservation { get; set; }
        public ReservationStatus ActualReservationStatus { get; set; }

        public Reservation()
        {
            this.TotalGuests = 0;
            this.Babies = 0;
            this.Kids = 0;
            this.Adults = 0;
            this.GuestName = "Default Guest Name";
            this.GuestLastName = "Default Guest LastName";
            this.Email = "Default Email";
            this.PhoneNumber = 0;
            this.Information = "Default Information";
            this.NewStatusDescription = "No changes were made";
            this.ActualReservationStatus = ReservationStatus.Created;
        }

        public void SetInfoText()
        {
            this.Information = String.Format("Accommodation name: {0}, Total Guests: {1}."
                , this.AccommodationForReservation.Name, this.TotalGuests);
        }

        public void SetPhoneNumber()
        {
            this.PhoneNumber = 0;
        }
    }
}
