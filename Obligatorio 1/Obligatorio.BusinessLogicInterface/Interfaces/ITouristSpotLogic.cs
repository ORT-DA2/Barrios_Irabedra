using Obligatorio.Domain;
using System;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface ITouristSpotLogic : ILogic<TouristSpot>
    {
        IEnumerable<TouristSpot> FindByCategory(string value);
        IEnumerable<TouristSpot> FindByRegion(string sortingRegion);
        void Add(TouristSpot touristSpot, TouristSpotCategory touristSpotCategory);
    }
}