using Obligatorio.Domain.AuxiliaryObjects;
using Obligatorio.Domain.DomainEntities;
using System.Collections.Generic;

namespace Obligatorio.Domain
{
    public class Accommodation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public List<ImageWrapper> Images { get; set; }
        public double PricePerNight { get; set; }
        public bool FullCapacity { get; set; }
        public TouristSpot TouristSpot { get; set; }
        public List<Review> Reviews { get; set; }
        public Accommodation()
        {
            this.Name = "Default Name";
            this.Rating = -1;
            this.Address = "Default Address";
            this.Description = "Default Description";
            this.Images = new List<ImageWrapper>();
            this.PricePerNight = -1;
            this.FullCapacity = false;
            this.Reviews = new List<Review>();
        }

        public bool IsAvailable() 
        {
            return !this.FullCapacity;
        }
    }
}
