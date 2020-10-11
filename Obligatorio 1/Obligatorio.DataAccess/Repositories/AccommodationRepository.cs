using Microsoft.EntityFrameworkCore;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio.DataAccess.Repositories
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly DbContext myContext;
        private readonly DbSet<Accommodation> accommodations;

        public AccommodationRepository(DbContext context)
        {
            this.myContext = context;
            this.accommodations = context.Set<Accommodation>();
        }

        public void Add(Accommodation accommodation)
        {
            if (AlredyExisting(accommodation))
            {
                throw new RepeatedObjectException();
            }
            else 
            {
                this.accommodations.Add(accommodation);
                myContext.SaveChanges();
            }
        }

        private bool AlredyExisting(Accommodation accommodation)
        {
            List<Accommodation> accommodationsToCompare = accommodations.ToList<Accommodation>();
            foreach (var item in accommodations)
            {
                if (accommodation.Name == item.Name) 
                {
                    return true;
                }
            }
            return false;
        }

        public List<Accommodation> GetAll()
        {
            return this.accommodations.ToList();
        }

        public List<Accommodation> GetByTouristSpot(int touristSpotId)
        {
            List<Accommodation> totalAccommodations = this.accommodations.ToList();
            foreach (var item in totalAccommodations)
            {
                myContext.Entry(item).Reference(a => a.TouristSpot).Load();
            }
            List<Accommodation> accommodationsToReturn = new List<Accommodation>();
            foreach (var item in totalAccommodations)
            {
                if (item.TouristSpot.Id.Equals(touristSpotId)) 
                {
                    accommodationsToReturn.Add(item);
                }
            }
            return accommodationsToReturn;
        }
    }
}
