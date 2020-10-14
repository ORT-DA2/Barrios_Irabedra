using Microsoft.EntityFrameworkCore;
using Obligatorio.DataAccess.CustomExceptions;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;

namespace Obligatorio.DataAccess.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DbContext myContext;
        private readonly DbSet<Reservation> reservations;

        public ReservationRepository(DbContext context)
        {
            this.myContext = context;
            this.reservations = context.Set<Reservation>();
        }

        public Reservation Add(Reservation reservation)
        {
            reservations.Add(reservation);
            myContext.SaveChanges();
            return reservation;
        }

        public Reservation GetById(int id)
        {
            var reservation = reservations.Find(id);
            if (reservation is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return reservation;
        }
    }
}
