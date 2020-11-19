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
        void UpdateCapacity(string name, bool fullCapacity);
        void AddImages(string name, List<ImageWrapper> images);
        Accommodation GetById(int accommodationId);
        bool AlreadyExistsByName(string name);
        void Delete(string name);
        Accommodation GetByName(string name);
        List<Accommodation> GetAllAvailableByTouristSpotName(string touristSpotName);
    }
}
