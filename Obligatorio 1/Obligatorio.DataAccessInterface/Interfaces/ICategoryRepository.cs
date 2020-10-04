using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
