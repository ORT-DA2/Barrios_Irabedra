using Microsoft.EntityFrameworkCore;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;

namespace Obligatorio.DataAccess.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DbContext myContext;
        private readonly DbSet<Reservation> admins;

        public ReservationRepository(DbContext context)
        {
            this.myContext = context;
            this.admins = context.Set<Reservation>();
        }
    }
}
