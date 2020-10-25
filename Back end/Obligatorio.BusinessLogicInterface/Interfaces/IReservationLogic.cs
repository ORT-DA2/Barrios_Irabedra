using Obligatorio.Domain.DomainEntities;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IReservationLogic
    {
        Reservation Add(Reservation reservation, int accommodationId);
        Reservation Get(int id);
        void Update(Reservation reservationToUpdate);
    }
}
