using Microsoft.EntityFrameworkCore;
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

        public void Add(Accommodation accommodation)
        {
            this.accommodations.Add(accommodation);
            myContext.SaveChanges();
        }

        public List<Accommodation> GetAll()
        {
            return this.accommodations.ToList();
        }

        public List<Accommodation> GetByTouristSpot(int touristSpotId)
        {
            List<Accommodation> totalAccommodations = this.accommodations.ToList();
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
