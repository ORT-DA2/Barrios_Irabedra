using Obligatorio.Domain;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface IRegionRepository :ILogic<Region>
    {
        Region Get(string name);
        void AddTouristSpotToRegion(string regionName, int touristSpotId);
        void ModifyTouristSpotRegion(string regionName, int touristSpotId);
    }
}