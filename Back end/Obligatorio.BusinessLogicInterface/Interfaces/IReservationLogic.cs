using Obligatorio.Domain.DomainEntities;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IReservationLogic
    {
        Reservation Add(Reservation reservation, string accommodationName);
        Reservation Get(int id);
        void Update(Reservation reservationToUpdate);
        List<Reservation> GetAll();
    }
}
