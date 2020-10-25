using Obligatorio.Domain;
using System;
using System.Collections.Generic;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface ITouristSpotRepository
    {
        TouristSpot Get(int id);
        IEnumerable<TouristSpot> GetAll();
        IEnumerable<TouristSpot> GetAllByCondition(Func<TouristSpot, bool> predicate);
        void Add(TouristSpot newEntity);
        void Update(int id, TouristSpot newEntity);
        void Delete(int id);
        void Update(TouristSpot touristSpot);
        void Add(TouristSpot touristSpot, TouristSpotCategory touristSpotCategory);
    }
}
