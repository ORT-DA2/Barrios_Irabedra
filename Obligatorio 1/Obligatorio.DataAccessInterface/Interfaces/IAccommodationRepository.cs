using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface IAccommodationRepository
    {
        List<Accommodation> GetAll();
        List<Accommodation> GetByTouristSpot(int touristSpotName);
        void Add(Accommodation accommodation);
    }
}
