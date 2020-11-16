using Obligatorio.Domain;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IRegionLogic
    {
        Region Get(int id);
        IEnumerable<Region> GetAll();
        void Add(Region newEntity);
        Region Get(string name);
        void AddTouristSpotToRegion(string regionName, string touristSpotName);
        void ModifyTouristSpotRegion(string regionName, int touristSpotId);
    }
}