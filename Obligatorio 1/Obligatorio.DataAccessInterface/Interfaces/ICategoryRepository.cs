using Obligatorio.Domain;
using System.Collections.Generic;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category Get(string name);
        void Add(Category newEntity);
        Category Find(string categoryName);
        void Update(Category category);
        void Add(Category category, TouristSpotCategory touristSpotCategory);
    }
}
