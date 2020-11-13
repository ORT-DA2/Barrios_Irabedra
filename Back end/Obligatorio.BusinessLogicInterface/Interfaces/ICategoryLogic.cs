using Obligatorio.Domain;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface ICategoryLogic
    {
        IEnumerable<Category> GetAll();
        Category Get(string nameWithSpaces);
        void Add(Category category);
        void AddTouristSpotToCategory(string categoryName, int touristSpotId);
        Category Find(string categoryName);
        void Add(Category category, TouristSpotCategory touristSpotCategory);
        void AddTouristSpotToCategory(string categoryName, string touristSpotName);
    }
}
