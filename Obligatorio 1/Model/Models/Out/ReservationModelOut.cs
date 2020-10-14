using Obligatorio.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Model.Models.Out
{
    public class ReservationModelOut
    {
        public int PhoneNumber { get; set; }
        public string InformativeText { get; set; }
        public int UnicCode {get;set;}

        public ReservationModelOut(Reservation reservation)
        {
            this.PhoneNumber = reservation.PhoneNumber;
            this.InformativeText = reservation.Information;
            this.UnicCode = reservation.Id;
        }
    }
}
