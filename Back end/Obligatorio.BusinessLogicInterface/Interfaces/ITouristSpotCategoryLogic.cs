using Obligatorio.Domain;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface ITouristSpotCategoryLogic
    {
        void AddTouristSpotToCategory(string categoryName, int touristSpotId);
        IEnumerable<TouristSpot> FindByCategory(string value);
        IEnumerable<TouristSpotCategory> GetAllData();
    }
}
