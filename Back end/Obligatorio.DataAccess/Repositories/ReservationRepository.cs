using Microsoft.EntityFrameworkCore;
using Obligatorio.DataAccess.CustomExceptions;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
using System.Collections.Generic;
using System.Linq;

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

        public List<Reservation> GetAll()
        {
            List<Reservation> reservationsToReturn = this.reservations.ToList();
            return reservationsToReturn;
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

        public void Update(Reservation reservation)
        {
            myContext.Entry(reservation).State = EntityState.Modified;
            myContext.SaveChanges();
        }
    }
}
