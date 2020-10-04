using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface ITouristSpotRepository : ILogic<TouristSpot>
    {
        void Add(TouristSpot newEntity);
        void Delete(int id);
        void Update(int id, TouristSpot newEntity);
        IEnumerable<TouristSpot> GetAllByCondition(Func<TouristSpot, bool> predicate);
        IEnumerable<TouristSpot> GetByCategory(string value);
        void Update(TouristSpot touristSpot);
        void Add(TouristSpot touristSpot, TouristSpotCategory touristSpotCategory);
    }
}
