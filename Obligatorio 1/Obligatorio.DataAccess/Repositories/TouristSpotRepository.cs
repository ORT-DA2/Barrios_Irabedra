using Microsoft.EntityFrameworkCore;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccess.Repositories
{
    public class TouristSpotRepository : ITouristSpotRepository
    {
        private readonly DbSet<TouristSpot> touristSpots;
        private readonly DbContext myContext;
        public TouristSpotRepository(DbContext context)
        {
            this.myContext = context;
            this.touristSpots = context.Set<TouristSpot>(); //creemos que esto trae a memoria todo magicamente.
        }

        public IEnumerable<TouristSpot> GetAll()
        {
            return this.touristSpots;
        }
    }
}