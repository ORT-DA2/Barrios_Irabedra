using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Obligatorio.DataAccess.CustomExceptions;
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
            this.touristSpots = context.Set<TouristSpot>(); 
        }

        public IEnumerable<TouristSpot> GetAll()
        {
            return this.touristSpots;
        }

        public TouristSpot Get(int id)
        {
            var touristSpot = touristSpots.Find(id);
            if(touristSpot is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return touristSpot;
        }

        public void Add(TouristSpot newEntity)
        {
            if(AlreadyExists(newEntity))
            {
                throw new RepeatedObjectException();
            }
            else
            {
                touristSpots.Add(newEntity);
                myContext.SaveChanges();
            }
        }

        private bool AlreadyExists(TouristSpot newEntity)
        {
            return (touristSpots.Find(newEntity.Id) is null);
        }
    }
}