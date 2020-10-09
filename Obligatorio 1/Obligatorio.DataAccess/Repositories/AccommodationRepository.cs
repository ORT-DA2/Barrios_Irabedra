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

        public List<Accommodation> GetAll()
        {
            return this.accommodations.ToList();
        }

        public List<Accommodation> GetByTouristSpot(string touristSpotName)
        {
            List<Accommodation> totalAccommodations = this.accommodations.ToList();
            List<Accommodation> accommodationsToReturn = new List<Accommodation>();
            foreach (var item in totalAccommodations)
            {
                if (item.TouristSpot.Name.Equals(touristSpotName)) 
                {
                    accommodationsToReturn.Add(item);
                }
            }
            return accommodationsToReturn;
        }
    }
}
