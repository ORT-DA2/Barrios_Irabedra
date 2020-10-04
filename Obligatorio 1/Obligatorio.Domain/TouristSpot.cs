using System.Collections.Generic;
using System.Security.Cryptography;

namespace Obligatorio.Domain
{
    public class TouristSpot
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string Image { set; get; } //stringbase64
        public int Id { get; set; }
        public ICollection<TouristSpotCategory> TouristSpotCategories { get; set; }

        public TouristSpot()
        {
            Name = "Default Name";
            Description = "Default Description";
            Image = "Default Image";
            TouristSpotCategories = new List<TouristSpotCategory>();
        }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is TouristSpot touristSpot)
            {
                result = this.Id == touristSpot.Id & this.Name.Equals(touristSpot.Name);
            }
            return result;
        }

        public bool Validate()
        {
            return this.Description.Length <= 2000;
        }

        public override string ToString()
        {
            string s = string.Format("Tourist Spot called {0}, and its description is {1}.",
                Name, Description);
            if (Image == "Default Image")
            {
                s += "And has no image.";
            }
            else 
            {
                s += "And has an image.";
            }
            return s;
        }
    }
}