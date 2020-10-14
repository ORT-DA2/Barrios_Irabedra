using Obligatorio.Domain;
using System.Collections.Generic;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface ITouristSpotCategoryRepository
    {
        IEnumerable<TouristSpotCategory> GetAll();
        void UpdateCategoryAndTouristSpot(Category category, TouristSpot touristSpot);
        void Add(Category category, TouristSpot touristSpot);
    }
}
