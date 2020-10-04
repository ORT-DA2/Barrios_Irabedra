using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Domain;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IRegionLogic : ILogic<Region>
    {
        Region Get(string name);
        void AddTouristSpotToRegion(string regionName, int touristSpotId);
        void ModifyTouristSpotRegion(string regionName, int touristSpotId);
    }
}