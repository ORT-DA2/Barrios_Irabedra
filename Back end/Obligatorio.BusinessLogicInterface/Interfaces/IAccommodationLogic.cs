using Obligatorio.Domain;
using Obligatorio.Domain.DomainEntities;
using Obligatorio.Model.Dtos;
using Obligatorio.Model.DTOS;
using Obligatorio.Model.Models.In;
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
        void AddReview(Review reviewRegistrationModelIn);
        void Delete(string name);
        List<AccommodationQueryOut> GetAll();
        Accommodation GetByName(string name);
        List<Accommodation> GetAllByTouristSpotName(string touristSpotName);
    }
}
