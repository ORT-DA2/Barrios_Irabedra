using Obligatorio.Domain.DomainEntities;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IReservationLogic
    {
        Reservation Add(Reservation reservation, string accommodationName);
        Reservation Get(int id);
        void Update(Reservation reservationToUpdate);
    }
}
