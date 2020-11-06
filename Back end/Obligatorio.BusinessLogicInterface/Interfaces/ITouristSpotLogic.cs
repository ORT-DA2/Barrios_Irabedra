using Obligatorio.Domain;
using System;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface ITouristSpotLogic
    {
        TouristSpot Get(int id);
        IEnumerable<TouristSpot> GetAll();
        IEnumerable<TouristSpot> GetAllByCondition(Func<TouristSpot, bool> predicate);
        void Add(TouristSpot newEntity);
        void Update(int id, TouristSpot newEntity);
        void Delete(int id);
        TouristSpot GetByName(string name);
        IEnumerable<TouristSpot> FindByCategory(string value);
        IEnumerable<TouristSpot> FindByRegion(string sortingRegion);
        void Add(TouristSpot touristSpot, TouristSpotCategory touristSpotCategory);
        bool AlreadyExistsByName(string image);
        int Get(string name);
    }
}