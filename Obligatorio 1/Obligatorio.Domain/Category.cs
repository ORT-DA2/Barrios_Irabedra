using System.Collections.Generic;

namespace Obligatorio.Domain
{
    public class Category
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<TouristSpotCategory> TouristSpotCategories { get; set; } 
        public Category()
        {
            Name = "Default Name";
            TouristSpotCategories = new List<TouristSpotCategory>();
        }

        public override bool Equals(object obj)
        {
            return obj is Category category &&
                   Name == category.Name;
        }
    }
}