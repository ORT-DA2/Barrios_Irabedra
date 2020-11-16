using Obligatorio.Domain;
using Obligatorio.Model.Dtos;
using Obligatorio.Model.DTOS;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IAccommodationLogic
    {
        List<AccommodationQueryOut> GetByTouristSpot(AccommodationQueryIn accommodationQueryIn);
        void Add(Accommodation accommodation, string touristSpotName);
        void Update(AccommodationPutQueryIn accommodationPutQueryIn);
        Accommodation GetById(int accommodationId);
        bool AlreadyExistsByName(string name);
        void Delete(string name);
        List<AccommodationQueryOut> GetAll();
        Accommodation GetByName(string name);
    }
}
