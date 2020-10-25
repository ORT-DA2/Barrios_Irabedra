using Obligatorio.Domain;
using Obligatorio.Model.Dtos;
using Obligatorio.Model.DTOS;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IAccommodationLogic
    {
        List<AccommodationQueryOut> GetByTouristSpot(AccommodationQueryIn accommodationQueryIn);
        void Add(Accommodation accommodation, int touristSpotId);
        void Update(AccommodationPutQueryIn accommodationPutQueryIn);
        Accommodation GetById(int accommodationId);
    }
}
