using Obligatorio.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface IReservationRepository
    {
        Reservation Add(Reservation reservation);
        Reservation GetById(int id);
        void Update(Reservation reservation);
    }
}
