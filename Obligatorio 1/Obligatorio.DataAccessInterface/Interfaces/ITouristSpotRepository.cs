using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface ITouristSpotRepository : ILogic<TouristSpot>
    {
        IEnumerable<TouristSpot> GetByCategory(string value);
        void Update(TouristSpot touristSpot);
        void Add(TouristSpot touristSpot, TouristSpotCategory touristSpotCategory);
    }
}
