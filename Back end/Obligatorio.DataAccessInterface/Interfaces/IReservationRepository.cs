using Obligatorio.Domain.DomainEntities;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface IReservationRepository
    {
        Reservation Add(Reservation reservation);
        Reservation GetById(int id);
        void Update(Reservation reservation);
    }
}
