using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;

namespace Obligatorio.BusinessLogic.Logics
{
    public class TouristSpotLogic : ITouristSpotLogic
    {
       private readonly ITouristSpotRepository touristSpotRepository;

        public TouristSpotLogic(ITouristSpotRepository touristSpotRepository)
        {
            this.touristSpotRepository = touristSpotRepository;
        }
    }
}
