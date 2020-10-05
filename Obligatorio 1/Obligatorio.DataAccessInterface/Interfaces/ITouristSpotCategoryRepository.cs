using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface ITouristSpotCategoryRepository
    {
        IEnumerable<TouristSpotCategory> GetAll();
        void UpdateCategoryAndTouristSpot(Category category, TouristSpot touristSpot);
        void Add(Category category, TouristSpot touristSpot);
    }
}
