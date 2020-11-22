using Obligatorio.Domain.AuxiliaryObjects;
using Obligatorio.Domain.DomainEntities;

namespace Obligatorio.Model.Models.Out
{
    public class ReservationModelOut
    {
        public int PhoneNumber { get; set; }
        public string InformativeText { get; set; }
        public int UnicCode { get; set; }
        public string ActualReservationStatus { get; set; }
        public string NewStatusDescription {get;set;}
        public string Name { get; set; }
        public string LastName { get; set; }

        public ReservationModelOut(Reservation reservation)
        {
            this.PhoneNumber = reservation.PhoneNumber;
            this.InformativeText = reservation.Information;
            this.UnicCode = reservation.Id;
            this.ActualReservationStatus = reservation.EnumToString();
            this.NewStatusDescription = reservation.NewStatusDescription;
            this.Name = reservation.GuestName;
            this.LastName = reservation.GuestLastName;
        }
    }
}
