using Obligatorio.Domain;

namespace Obligatorio.Model.Models.In
{
    public class AccommodationRegisterModelIn
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double PricePerNight { get; set; }
        public bool FullCapacity { get; set; }
        public string TouristSpotName { get; set; }

        public AccommodationRegisterModelIn()
        {
            this.Name = "Default Name";
            this.Address = "Default Address";
            this.Description = "Default description";
            this.FullCapacity = false;
        }

        public Accommodation ToEntity()
        {
            Accommodation accommodation = new Accommodation();
            accommodation.Name = this.Name;
            accommodation.Rating = this.Rating;
            accommodation.Address = this.Address;
            accommodation.Description = this.Description;
            accommodation.PricePerNight = this.PricePerNight;
            accommodation.FullCapacity = this.FullCapacity;
            return accommodation;
        }

        public AccommodationRegisterModelIn(Accommodation accommodation)
        {
            this.Name = accommodation.Name ;
            this.Rating = accommodation.Rating;
            this.Address = accommodation.Address;
            this.Description = accommodation.Description;
            this.PricePerNight = accommodation.PricePerNight;
            this.FullCapacity = accommodation.FullCapacity;
        }
    }
}
