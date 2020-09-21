using System.Security.Cryptography;

namespace Obligatorio.Domain
{
    public class TouristSpot
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }
        public Region Region { get; set; }
        public int Id { get; set; }

        public TouristSpot()
        {
            Name = "Default Name";
            Description = "Default Description";
            Image = "Default Image";
        }

        public override bool Equals(object obj)
        {
            return obj is TouristSpot spot &&
                   Name == spot.Name;
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