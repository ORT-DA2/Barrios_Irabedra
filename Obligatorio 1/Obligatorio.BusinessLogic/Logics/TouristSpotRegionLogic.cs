using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio.BusinessLogic.Logics
{
    public class TouristSpotRegionLogic : ITouristSpotRegionLogic
    {
        private readonly ITouristSpotRepository touristSpotRepository;//ts logic
        private readonly IRegionRepository regionRepository; //region logic

        public TouristSpotRegionLogic(ITouristSpotRepository touristSpotRepository, IRegionRepository regionRepository)
        {
            this.touristSpotRepository = touristSpotRepository;
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
