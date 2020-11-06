using Obligatorio.Domain;
using Obligatorio.Domain.AuxiliaryObjects;
using System.Collections.Generic;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface IAccommodationRepository
    {
        List<Accommodation> GetAll();
        List<Accommodation> GetByTouristSpot(int touristSpotId);
        void Add(Accommodation accommodation);
        void UpdateCapacity(int accommodationId, bool fullCapacity);
        void AddImages(int accommodationId, List<ImageWrapper> images);
        Accommodation GetById(int accommodationId);
        bool AlreadyExistsByName(string name);
    }
}
