using Obligatorio.Domain;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface ITouristSpotRegionLogic
    {
        IEnumerable<TouristSpot> FindByRegion(string sortingRegion);
    }
}
