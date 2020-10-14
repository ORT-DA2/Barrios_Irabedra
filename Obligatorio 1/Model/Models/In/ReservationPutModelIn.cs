﻿using Obligatorio.Domain.AuxiliaryObjects;
using Obligatorio.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Model.Models.In
{
    public class ReservationPutModelIn
    {
        public ReservationStatus State { get; set; }
        public string Description { get; set; }

        public Reservation ToEntity(int id)
        {
            Reservation reservationToReturn = new Reservation();
            reservationToReturn.Id = id;
            reservationToReturn.ActualReservationStatus = State;
            reservationToReturn.ChangeDescription = Description;
            return reservationToReturn;
        }
    }
}
