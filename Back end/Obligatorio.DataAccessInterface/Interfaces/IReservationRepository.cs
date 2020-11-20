using Obligatorio.Domain.DomainEntities;
using System.Collections.Generic;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface IReservationRepository
    {
        Reservation Add(Reservation reservation);
        Reservation GetById(int id);
        void Update(Reservation reservation);
        List<Reservation> GetAll();
    }
}
