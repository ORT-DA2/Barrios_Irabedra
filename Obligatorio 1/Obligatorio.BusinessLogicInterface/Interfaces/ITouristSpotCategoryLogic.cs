using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface ITouristSpotCategoryLogic
    {
        void AddTouristSpotToCategory(string categoryName, int touristSpotId);
        IEnumerable<TouristSpot> FindByCategory(string value);
        IEnumerable<TouristSpotCategory> GetAllData();
    }
}
