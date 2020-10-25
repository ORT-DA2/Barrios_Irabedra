using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogic.Logics
{
    public class TouristSpotRegionLogic : ITouristSpotRegionLogic
    {
        private readonly IRegionRepository regionRepository;

        public TouristSpotRegionLogic(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        public IEnumerable<TouristSpot> FindByRegion(string sortingRegion)
        {
            try
            {
                Region regionToCompare = this.regionRepository.Get(sortingRegion);
                List<TouristSpot> touristSpotsToReturn = regionToCompare.TouristSpots;
                return touristSpotsToReturn;
            }
            catch (ObjectNotFoundInDatabaseException)
            {
                return new List<TouristSpot>();
            }
        }
    }
}
