using System;

namespace Obligatorio.Model.Models.In
{
    public class AccommodationModelIn
    {
        public int TouristSpotId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int TotalGuests { get; set; }
        public int Babies { get; set; }
        public int Kids { get; set; }
        public int Adults { get; set; }

        public AccommodationModelIn()
        {
        }
    }
}
