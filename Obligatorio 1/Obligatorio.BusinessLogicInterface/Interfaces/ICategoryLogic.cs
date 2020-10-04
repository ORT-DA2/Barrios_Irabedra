using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface ICategoryLogic
    {
        IEnumerable<Category> GetAll();
        Category Get(string nameWithSpaces);
        void Add(Category category);
        void AddTouristSpotToCategory(string categoryName, int touristSpotId);
    }
}
