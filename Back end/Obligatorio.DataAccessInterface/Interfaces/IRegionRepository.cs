using Obligatorio.Domain;
using System.Collections.Generic;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface IRegionRepository
    {
        Region Get(int id);
        void Add(Region newEntity);
        Region Get(string name);
        IEnumerable<Region> GetAll();
        void AddTouristSpotToRegion(string regionName, string touristSpotName);
        void ModifyTouristSpotRegion(string regionName, int touristSpotId);
    }
}